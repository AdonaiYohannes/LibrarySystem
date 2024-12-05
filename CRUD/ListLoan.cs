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
                var loan = context.Loans.ToList();
                Console.WriteLine("\nLoans: ");
                foreach (var loan in loans)
                {
                    Console.WriteLine ($"Book ID: {loan.BookId}, Loan Date: {loan.ReturnDate}, Return Date: {loan.LoanDate?.ToString() ?? "Not Returned"}");
                }
            }
        }
    }
}