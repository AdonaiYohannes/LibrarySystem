using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Loan
    {
        public int LoanId {get; set;}
        public int BookId {get; set;}
        public required Book Book {get; set;}
        public int BorrowerId {get; set;}
        public required Borrower Borrower {get; set;}
        public required string BorrowerName {get; set;}
        public DateTime LoanDate {get; set;}
        public DateTime? ReturnDate {get; set;}
    }
    
}