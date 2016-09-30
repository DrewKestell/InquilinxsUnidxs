using DataAccess.Model;
using System;
using System.Linq;
using System.Security.Cryptography;

// password hashing taken from here: http://lockmedown.com/hash-right-implementing-pbkdf2-net/

namespace DataAccess.Service
{
    public class AuthenticationService : Service
    {
        private const int SaltByteLength = 24;
        private const int DerivedKeyLength = 24;
        private const int IterationCount = 24000;

        protected User GetUser(string username)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        protected void Register(string username, string password, string email)
        {
            using (var context = this.GetApplicationContext())
            {
                var hashedPassword = CreatePasswordHash(password);           
                context.Users.Add(new User
                {
                    Username = username,
                    Password = hashedPassword,
                    Email = email
                });
                context.SaveChanges();
            }
        }

        protected bool ValidatePassword(User user, string passwordInput)
        {
            using (var context = this.GetApplicationContext())
            {
                //ingredient #1: password salt byte array
                var salt = new byte[SaltByteLength];

                //ingredient #2: byte array of password
                var actualPasswordByteArray = new byte[DerivedKeyLength];

                //convert actualSavedHashResults to byte array
                var actualSavedHashResultsByteArray = Convert.FromBase64String(user.Password);

                //ingredient #3: iteration count
                var iterationCountLength = actualSavedHashResultsByteArray.Length - (salt.Length + actualPasswordByteArray.Length);
                var iterationCountByteArr = new byte[iterationCountLength];

                Buffer.BlockCopy(actualSavedHashResultsByteArray, 0, salt, 0, SaltByteLength);
                Buffer.BlockCopy(actualSavedHashResultsByteArray, SaltByteLength, actualPasswordByteArray, 0, actualPasswordByteArray.Length);
                Buffer.BlockCopy(actualSavedHashResultsByteArray, (salt.Length + actualPasswordByteArray.Length), iterationCountByteArr, 0, iterationCountLength);
                var passwordGuessByteArray = GenerateHashValue(passwordInput, salt, BitConverter.ToInt32(iterationCountByteArr, 0));
                return ConstantTimeComparison(passwordGuessByteArray, actualPasswordByteArray);
            }
        }

        private static bool ConstantTimeComparison(byte[] passwordGuess, byte[] actualPassword)
        {
            var difference = (uint)passwordGuess.Length ^ (uint)actualPassword.Length;
            for (var i = 0; i < passwordGuess.Length && i < actualPassword.Length; i++)
            {
                difference |= (uint)(passwordGuess[i] ^ actualPassword[i]);
            }
            return difference == 0;
        }

        public string CreatePasswordHash(string password)
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

        private byte[] GenerateRandomSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltByteLength];
            rng.GetBytes(salt);
            return salt;
        }

        private byte[] GenerateHashValue(string password, byte[] salt, int iterationCount)
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