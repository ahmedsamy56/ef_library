using library.Data;
using library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Services
{
    public class RegisterService
    {
        public static void RegisterUser(string username, string email, string password, string role)
        {
            using (var context = new AppDbContext())
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                var user = new User {
                    Username = username,
                    Email = email, PasswordHash = hashedPassword, 
                    Role = role 
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }


        public static void PerformRegistration(string role)
        {
            Console.WriteLine($"Enter username to register as {role}:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            RegisterService.RegisterUser(username, email, password, role);
            Console.WriteLine($"Registration successful! You are now registered as {role}.");
            Console.ReadLine();
        }
    }
}
