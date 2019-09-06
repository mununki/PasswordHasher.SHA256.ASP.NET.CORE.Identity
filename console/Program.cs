using System;
using SHA256Hasher;
using Microsoft.AspNetCore.Identity;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "StrongPassw0rd!";

            IdentityUser user = new IdentityUser();
            CustomPasswordHasher hasher = new CustomPasswordHasher();

            string hashedValue = hasher.HashPassword(user, password);
            Console.WriteLine("HashedValue > " + hashedValue);

            Console.WriteLine("Verify > " + hasher.VerifyHashedPassword(user, hashedValue, password));
        }
    }
}
