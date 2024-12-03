using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Models;

namespace BookAuthor.Models
{
    public class BookAuthor
    {
        public int BookId {get; set;}
        public required Book Book {get; set;}
        public int AuthorId {get; set;}
        public required Author Author {get; set;}
    }
    
}