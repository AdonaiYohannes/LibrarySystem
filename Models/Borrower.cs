using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Borrower
    {
        public int BorrowerId {get; set;}
        public int PersonNr {get; set;}
        public required string FirstName {get; set;}
        public required string LastName {get; set;}
        public string Email {get; set;}
        public int PhoneNr {get; set;}
        public int MaxBooksAllowed {get; set;}
        public required ICollection<Loan> Loans {get; set;}
    }
}