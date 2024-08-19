using library.Data;
using library.Entities;
using library.Services;

namespace library
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Library System!");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Please select an option: ");

                var mainChoice = Console.ReadLine();
                switch (mainChoice)
                {
                    case "1":
                        MenuService.ShowLoginMenu();
                        break;
                    case "2":
                        MenuService.ShowRegisterMenu();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
       
    }

}
