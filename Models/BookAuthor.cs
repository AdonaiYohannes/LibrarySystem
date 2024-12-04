using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Models;

namespace Library.Models
{
    public class BookAuthor
    {
        public int Id {get; set;}
        public int BookId {get; set;}
        public required Book Book {get; set;}
        public int AuthorId {get; set;}
        public required Author Author {get; set;}
        
    }
    
}