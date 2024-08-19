using library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Services
{
    public class LoginService
    {
        public static User Login(string email, string password)
        {
            if (AuthService.AuthenticateUser(email, password, out var user))
            {
                return user; // Return the logged-in user object
            }
            else
            {
                return null; // Return null if authentication fails
            }
        }

        public static User PerformLogin(string role)
        {

            Console.WriteLine($"Enter email to login as {role}:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            var loggedInUser = LoginService.Login(email, password);
            if (loggedInUser == null)
            {
                Console.WriteLine("Invalid email or password.");
                Console.ReadKey();
                return null;
            }
            else if (loggedInUser.Role == role)
            {
                Console.WriteLine($"Welcome, {loggedInUser.Username}! You are logged in as {loggedInUser.Role}.");
                Console.ReadKey();
                return loggedInUser;
            }
            else
            {
                Console.WriteLine("Invalid credentials or role mismatch.");
                Console.ReadKey();
                return null;
            }
        }
    }

}
