


static void BorrowBook()
        {
            Console.WriteLine("\nEnter Borrower ID: ");
            int borrowerId = int.Parse(Console.ReadLine());
            var borrower = Borrowers.FirstOrDefault(b => b.Id == borrowerId);

            if (borrower == null)
            {
                Console.WriteLine("Borrower not found.");
                return;
            }

            if (borrower.BorrowedBooks.Count >= borrower.MaxBooksAllowed)
            {
                Console.WriteLine($"You have reached the maximum allowed books ({borrower.MaxBooksAllowed}).");
                return;
            }

            Console.WriteLine("\nEnter Book ID to Borrow: ");
            int bookId = int.Parse(Console.ReadLine());
            var book = Books.FirstOrDefault(b => b.Id == bookId);

            if (book == null || book.IsBorrowed)
            {
                Console.WriteLine("Book is not available.");
                return;
            }

            book.IsBorrowed = true;
            borrower.BorrowedBooks.Add(book.Id);

            Console.WriteLine($"You borrowed: {book.Title}");
        }
