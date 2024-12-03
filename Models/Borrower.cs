using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Borrower
    {
        public int BorrowerId {get; set;}
        public required string FirstName {get; set;}
        public required string LastName {get; set;}
        public int MaxBooksAllowed {get; set;}
        public required ICollection<Loan> Loans {get; set;}
    }
}