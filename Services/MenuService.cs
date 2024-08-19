using library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Services
{
    public class MenuService
    {
        public static void ShowLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("Login as:");
            Console.WriteLine("1. User");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Please select an option: ");

            var loginChoice = Console.ReadLine();
            switch (loginChoice)
            {
                case "1":
                    var loggedInUser = LoginService.PerformLogin("User");
                    if (loggedInUser != null)
                    {
                        MenuService.ShowUserMenu(loggedInUser);
                    }
                    break;
                case "2":
                    var loggedInAdmin = LoginService.PerformLogin("Admin");
                    if (loggedInAdmin != null)
                    {
                        MenuService.ShowAdminMenu(loggedInAdmin);
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        public static void ShowRegisterMenu()
        {
            Console.Clear();
            Console.WriteLine("Register as:");
            Console.WriteLine("1. User");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Please select an option: ");

            var registerChoice = Console.ReadLine();
            switch (registerChoice)
            {
                case "1":
                    RegisterService.PerformRegistration("User");
                    break;
                case "2":
                    RegisterService.PerformRegistration("Admin");
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        public static void ShowUserMenu(User loggedInUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"User Menu - Logged in as: {loggedInUser.Username}");
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. View book reviews by ID");
                Console.WriteLine("3. Add review for a book");
                Console.WriteLine("4. Logout");
                Console.Write("Please select an option: ");

                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        BookService.ShowAllBooks();
                        break;
                    case "2":
                        BookService.ViewBookReviewsById();
                        break;
                    case "3":
                        BookService.AddReviewForBook(loggedInUser.UserId);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void ShowAdminMenu(User loggedInAdmin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Admin Menu - Logged in as: {loggedInAdmin.Username}");
                Console.WriteLine("1. Show All Books");
                Console.WriteLine("2. Add a new book");
                Console.WriteLine("3. Delete a book by ID");
                Console.WriteLine("4. Logout");
                Console.Write("Please select an option: ");

                var adminChoice = Console.ReadLine();
                switch (adminChoice)
                {
                    case "1":
                        BookService.ShowAllBooks();
                        break;
                    case "2":
                        BookService.AddBook();
                        break;
                    case "3":
                        BookService.DeleteBookById();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}
