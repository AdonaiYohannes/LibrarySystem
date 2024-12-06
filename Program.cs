using Library.Models;
using Library.Operations;
using LibrarySystem.Operations;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
            {
                Seed.Run();
                Console.WriteLine("Welcome to the Library System!");
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\nLibrary System Menu:");
                    Console.WriteLine("1. Add Author");
                    Console.WriteLine("2. Add Book");
                    Console.WriteLine("3. Add Author-Book Relationship");
                    Console.WriteLine("4. Borrow Book");
                    Console.WriteLine("5. List All Books");
                    Console.WriteLine("6. List All Loans");
                    Console.WriteLine("7. Remove A Book");
                    Console.WriteLine("8. Return A Book");
                    Console.WriteLine("9. Update A Book");
                    Console.WriteLine("10. Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddAuthor.Run();
                            break;
                        case "2":
                            AddBook.Run();
                            break;
                        case "3":
                            AddBookAuthor.Run();
                            break;
                        case "4":
                            AddBorrower.Run();
                            break;
                        case "5":
                            ListBook.Run();
                            break;
                        case "6":
                            ListLoan.Run();
                            break;
                        case "7":
                            Remove.Run();
                            break;
                        case "8":
                            Return.Run();
                            break;
                        case "9":
                            Update.Run();
                            break;
                        case "10":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                Console.WriteLine("Thank you for using the Library System. Goodbye!");
        }
    }
}


