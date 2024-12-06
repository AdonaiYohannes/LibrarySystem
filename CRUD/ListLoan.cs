using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Operations
{
    public class ListLoan
    {
        public static void Run()
        {
            using (var context = new LibraryContext())
            {
                var loanList = context.Loans
                    .Include(l => l.Borrower) // Include Borrower data
                    .Include(l => l.Book)     // Include Book data
                    .ThenInclude(b => b.BookAuthors) // Include authors of the book
                    .ThenInclude(ba => ba.Author)    // Include Author details
                    .ToList();

                Console.WriteLine("\nLoans: ");
                foreach (var loan in loanList)
                {
                    var book = loan.Book;
                    var authors = book.BookAuthors.Select(ba => ba.Author.FirstName + ba.Author.LastName);

                    Console.WriteLine(
                        $"Book Title: {book.Titel}, Authors: {string.Join(", ", authors)}, " +
                        $"Borrower ID: {loan.BorrowerId}, Borrower Name: {loan.Borrower.FirstName} {loan.Borrower.LastName}, " +
                        $"Loan Date: {loan.LoanDate}, Return Date: {loan.ReturnDate?.ToString() ?? "Not Returned"}");
                }
            }
        }
    }
}