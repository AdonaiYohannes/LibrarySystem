using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Author
    {
        public int Id {get; set;}
        public required string FirstName {get; set;}
        public required string LastName {get; set;}
        public  ICollection<BookAuthor>BookAuthors {get; set;}
    }
}
