using System;
using System.Collections.Generic;
using Library.Models;

namespace Library.Operations
{
    public class AddBorrower
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                // Get Borrower details
                Console.Write("Enter First Name: ");
                var firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                var lastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("First Name and Last Name cannot be empty.");
                    return;
                }

                // Create a new Borrower
                var borrower = new Borrower
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Loans = new List<Loan>() // Initialize Loans
                };

                // Optionally, add a Loan for this Borrower
                Console.Write("Enter Book ID for the Loan (or press Enter to skip): ");
                var bookIdInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(bookIdInput) && int.TryParse(bookIdInput, out int bookId))
                {
                    var loan = new Loan
                    {
                        BookId = bookId,
                        Borrower = borrower,
                        BorrowerName = $"{firstName} {lastName}", // Use BorrowerName dynamically
                        LoanDate = DateTime.Now,
                    };

                    borrower.Loans.Add(loan); // Add loan to borrower's list
                    context.Loans.Add(loan); // Add loan to the context
                }

                context.Borrowers.Add(borrower); // Add borrower to the context
                context.SaveChanges();

                Console.WriteLine($"Borrower added successfully with ID {borrower.BorrowerId}.");
                if (borrower.Loans.Count > 0)
                {
                    Console.WriteLine($"Loan added successfully.");
                }
            }
        }
    }
}
