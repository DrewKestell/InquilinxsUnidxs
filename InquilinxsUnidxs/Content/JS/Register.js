function validatePassword() {
    console.log("validating password");
    var password = document.getElementById("password");
    var confirmPassword = document.getElementById("confirm-password");

    if (password.value != confirmPassword.value) {
        alert("Passwords to not match. Please retype your password.");
        password.value = "";
        confirmPassword.value = "";
        return false;
    }
}