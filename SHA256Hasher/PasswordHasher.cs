using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SHA256Hasher
{
    public class CustomPasswordHasher : IPasswordHasher<IdentityUser>
    {
        public string HashPassword(IdentityUser user, string providedPassword)
        {
            string salt = Guid.NewGuid().ToString();

            string digestedBASE64 = CustomHashPassword(providedPassword, salt);

            return digestedBASE64 + "$" + salt;
        }

        public PasswordVerificationResult VerifyHashedPassword(IdentityUser user, string hashedPassword, string providedPassword)
        {
            // hashedPassword : hashedValue + "$" + salt
            string[] splittedHashedPassword = hashedPassword.Split("$");

            string hasedValue = CustomHashPassword(providedPassword, splittedHashedPassword[1]);

            if (splittedHashedPassword[0] == hasedValue)
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }

        private string CustomHashPassword(string password, string salt)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] hashedPassword = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                string digestedBASE64 = Convert.ToBase64String(hashedPassword);

                return digestedBASE64;
            }
        }
    }
}
