using DataAccess.Context;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Security.Cryptography;

// password hashing taken from here: http://lockmedown.com/hash-right-implementing-pbkdf2-net/

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IGenericRepository<User> userRepository;
        readonly IUnitOfWork unitOfWork;

        const int SaltByteLength = 24;
        const int DerivedKeyLength = 24;
        const int IterationCount = 24000;

        const string authUsernameFailure = "Username does not exist.";
        const string authPasswordFailure = "Incorrect password.";

        public AuthenticationService(IGenericRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Register(string username, string password, string email)
        {
            var hashedPassword = CreatePasswordHash(password);
            userRepository.Add(new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            });
            unitOfWork.Save();
        }

        public UserDTO Authenticate(string username, string passwordInput)
        {
            var user = userRepository.FirstOrDefault(u => u.Username == username);

            if (user == null)
                throw new Exception(message: authUsernameFailure); // FIXME: do we need a custom Exception type?

            ValidatePassword(username, user.Password, passwordInput);

            return new UserDTO(user);
        }

        void ValidatePassword(string username, string actualPassword, string passwordInput)
        {
            //ingredient #1: password salt byte array
            var salt = new byte[SaltByteLength];

            //ingredient #2: byte array of password
            var actualPasswordByteArray = new byte[DerivedKeyLength];

            //convert actualSavedHashResults to byte array
            var actualSavedHashResultsByteArray = Convert.FromBase64String(actualPassword);

            //ingredient #3: iteration count
            var iterationCountLength = actualSavedHashResultsByteArray.Length - (salt.Length + actualPasswordByteArray.Length);
            var iterationCountByteArr = new byte[iterationCountLength];

            Buffer.BlockCopy(actualSavedHashResultsByteArray, 0, salt, 0, SaltByteLength);
            Buffer.BlockCopy(actualSavedHashResultsByteArray, SaltByteLength, actualPasswordByteArray, 0, actualPasswordByteArray.Length);
            Buffer.BlockCopy(actualSavedHashResultsByteArray, (salt.Length + actualPasswordByteArray.Length), iterationCountByteArr, 0, iterationCountLength);
            var passwordGuessByteArray = GenerateHashValue(passwordInput, salt, BitConverter.ToInt32(iterationCountByteArr, 0));
            var authenticated = ConstantTimeComparison(passwordGuessByteArray, actualPasswordByteArray);

            if (!authenticated)
                throw new Exception(message: authPasswordFailure); // FIXME: do we need a custom Exception type?
        }

        string CreatePasswordHash(string password)
        {
            var salt = GenerateRandomSalt();
            var iterationCount = IterationCount;
            var hashValue = GenerateHashValue(password, salt, iterationCount);
            var iterationCountByteArray = BitConverter.GetBytes(iterationCount);
            var valueToSave = new byte[SaltByteLength + DerivedKeyLength + iterationCountByteArray.Length];
            Buffer.BlockCopy(salt, 0, valueToSave, 0, SaltByteLength);
            Buffer.BlockCopy(hashValue, 0, valueToSave, SaltByteLength, DerivedKeyLength);
            Buffer.BlockCopy(iterationCountByteArray, 0, valueToSave, salt.Length + hashValue.Length, iterationCountByteArray.Length);
            return Convert.ToBase64String(valueToSave);
        }

        bool ConstantTimeComparison(byte[] passwordGuess, byte[] actualPassword)
        {
            var difference = (uint)passwordGuess.Length ^ (uint)actualPassword.Length;
            for (var i = 0; i < passwordGuess.Length && i < actualPassword.Length; i++)
            {
                difference |= (uint)(passwordGuess[i] ^ actualPassword[i]);
            }
            return difference == 0;
        }        

        byte[] GenerateRandomSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltByteLength];
            rng.GetBytes(salt);
            return salt;
        }

        byte[] GenerateHashValue(string password, byte[] salt, int iterationCount)
        {
            byte[] hashValue;
            var valueToHash = string.IsNullOrEmpty(password) ? string.Empty : password;
            using (var pbkdf2 = new Rfc2898DeriveBytes(valueToHash, salt, iterationCount))
            {
                hashValue = pbkdf2.GetBytes(DerivedKeyLength);
            }
            return hashValue;
        }
    }
}