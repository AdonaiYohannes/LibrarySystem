using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int ID {get; set;}
        public required string Titel {get; set;}
        public int PublishedYear {get; set;}
        public required string ISBN {get; set;} // I understand that the real ISBN is not just string
        public  ICollection<BookAuthor> BookAuthors {get; set;}
        public ICollection<Loan> Loans {get; set;}
    }

}
