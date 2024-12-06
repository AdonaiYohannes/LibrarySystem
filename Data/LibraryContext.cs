using Microsoft.EntityFrameworkCore;
using Library.Models;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<BookAuthor> BookAuthors {get; set;}
    public DbSet<Loan> Loans {get; set;}
    public DbSet<Borrower> Borrowers {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=bibliotekDb;User ID=sa;Password=GeharestNo2;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Borrower)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BorrowerId);
    }
}
