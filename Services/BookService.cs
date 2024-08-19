using library.Data;
using library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Services
{
    public class BookService
    {
       

        public static void ShowAllBooks()
        {
            using (var context = new AppDbContext())
            {
                var books = context.Books.ToList();
                Console.WriteLine("All Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.BookId,-5} | Title: {book.Title,-30} | Author: {book.Author,-20} | Price: {book.Price,10:C} | Published Year: {book.PublishedYear,4}");

                }
            }
            Console.ReadKey();
        }

        public static void ViewBookReviewsById()
        {
            Console.WriteLine("Enter the Book ID to view its reviews:");
            int bookId;
            if (int.TryParse(Console.ReadLine(), out bookId))
            {
                using (var context = new AppDbContext())
                {
                    var reviews = context.Reviews
                           .Where(r => r.BookId == bookId)
                           .Select(r => new
                           {
                               r.ReviewId,
                               r.Rating,
                               r.ReviewText,
                               r.ReviewDate,
                               UserName = r.User != null ? r.User.Username : "Unknown User"
                           })
                           .ToList();

                    if (reviews.Any())
                    {
                        Console.WriteLine($"Reviews for Book ID: {bookId}");
                        foreach (var review in reviews)
                        {
                            Console.WriteLine($"User: {review.UserName,-20} | Rating: {review.Rating,2} | Review: {review.ReviewText,-40} | Date: {review.ReviewDate:yyyy-MM-dd HH:mm:ss}");

                        }
                    }
                    else
                    {
                        Console.WriteLine("No reviews found for this book.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Book ID.");
            }
            Console.ReadKey();
        }

        public static void AddReviewForBook(int userId)
        {
            Console.WriteLine("Enter the Book ID to review:");
            int bookId;
            if (int.TryParse(Console.ReadLine(), out bookId))
            {
                Console.WriteLine("Enter your rating (1-5):");
                int rating;
                if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
                {
                    Console.WriteLine("Enter your review text:");
                    string reviewText = Console.ReadLine();

                    using (var context = new AppDbContext())
                    {
                        var review = new Review
                        {
                            UserId = userId,
                            BookId = bookId,
                            Rating = rating,
                            ReviewText = reviewText,
                            ReviewDate = DateTime.Now
                        };

                        context.Reviews.Add(review);
                        context.SaveChanges();

                        Console.WriteLine("Review added successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid rating.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Book ID.");
            }
            Console.ReadKey(); 
        }

        public static void AddBook()
        {
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter book author:");
            string author = Console.ReadLine();

            Console.WriteLine("Enter book price:");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                return;
            }

            Console.WriteLine("Enter book published year:");
            int publishedYear;
            if (!int.TryParse(Console.ReadLine(), out publishedYear))
            {
                Console.WriteLine("Invalid year. Please enter a valid integer.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var book = new Book
                {
                    Title = title,
                    Author = author,
                    Price = price,
                    PublishedYear = publishedYear
                };

                context.Books.Add(book);
                context.SaveChanges();

                Console.WriteLine("Book added successfully!");
            }
            Console.ReadKey();
        }

        public static void DeleteBookById()
        {
            Console.WriteLine("Enter the Book ID to delete:");
            int bookId;
            if (int.TryParse(Console.ReadLine(), out bookId))
            {
                using (var context = new AppDbContext())
                {
                    var book = context.Books.Find(bookId);
                    if (book != null)
                    {
                        context.Books.Remove(book);
                        context.SaveChanges();
                        Console.WriteLine("Book deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Book ID.");
            }
            Console.ReadKey();
        }

        

    }
}
