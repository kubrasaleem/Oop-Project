using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.ADMIN
{
    public class AdminService
    {
        private AdminRepository repo =
            new AdminRepository();
        public void AddBook(Book book)
        {
            List<Book> books = repo.GetBooks();

            foreach (Book b in books)
            {
                if (b.Id == book.Id)
                {
                    Console.WriteLine("Book ID already exists.");
                    return;
                }
            }
            books.Add(book);
            repo.SaveBooks(books);

            repo.SaveHistory("ADDED", book);

            Console.WriteLine("Book added successfully.");
        }
        public Book SearchBook(string id)
        {
            List<Book> books = repo.GetBooks();

            foreach (Book book in books)
            {
                if (book.Id == id)
                    return book;
            }

            return null;
        }
        public void UpdateBook(Book updatedBook)
        {
            List<Book> books = repo.GetBooks();

            foreach (Book book in books)
            {
                if (book.Id == updatedBook.Id)
                {
                    book.Name = updatedBook.Name;
                    book.Author = updatedBook.Author;
                    book.Quantity = updatedBook.Quantity;
                    repo.SaveBooks(books);
                    repo.SaveHistory("UPDATED", book);

                    Console.WriteLine("Book updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Book not found.");
        }
        public void DeleteBook(string id)
        {
            List<Book> books = repo.GetBooks();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    Book book = books[i];

                    books.RemoveAt(i);
                    repo.SaveBooks(books);
                    repo.SaveHistory("DELETED", book);

                    Console.WriteLine("Book deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Book not found.");
        }
        public void ViewBooks()
        {
            List<Book> books = repo.GetBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }
            foreach (Book book in books)
            {
                Console.WriteLine(
             book.Name + "\t\t" +
             book.Id + "\t" +
             book.Author + "\t" +
             book.Quantity);
            }
        }
        public void SortBooks()
        {
            List<Book> books = repo.GetBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books found to sort.");
                return;
            }
            for (int i = 0; i < books.Count; i++)
            {
                for (int j = i + 1; j < books.Count; j++)
                {
                    if (string.Compare(books[i].Name, books[j].Name) > 0)
                    {
                        Book temp = books[i];
                        books[i] = books[j];
                        books[j] = temp;
                    }
                }
            }
            repo.SaveBooks(books);
            Console.WriteLine("Books sorted successfully.");
            Console.WriteLine("\n===== SORTED BOOK LIST =====");
            Console.WriteLine("Book Name\tBook ID\tAuthor\tQuantity");

            foreach (Book book in books)
            {
                Console.WriteLine(
         book.Name + "\t\t" +
         book.Id + "\t" +
         book.Author + "\t" +
         book.Quantity);
            }
        }
        public void ViewHistory()
        {
            List<string> history = repo.GetHistory();
            if (history.Count == 0)
            {
                Console.WriteLine("No history found.");
                return;
            }

            for (int i = 0; i + 4 < history.Count; i += 5)
            {
                Console.WriteLine(
                    history[i] + "\t" +
            history[i + 1] + "\t\t" +
            history[i + 2] + "\t" +
            history[i + 3] + "\t" +
            history[i + 4]);
            }
        }
             public void IssueBook(string studentName, string bookId)
        {
            List<Book> books = repo.GetBooks();

            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    if (book.Quantity <= 0)
                    {
                        Console.WriteLine("Book not available.");
                        return;
                    }

                    book.Quantity--;
                    repo.SaveBooks(books);

                    List<string> records = repo.GetIssuedRecords();

                    records.Add(studentName);
                    records.Add(book.Name);
                    records.Add(book.Id);
                    records.Add(book.Author);
                    records.Add("1");

                    repo.SaveIssuedRecords(records);

                    repo.SaveHistory("ISSUED", book);
                    Console.WriteLine("\n===== BOOK ISSUED =====");
                    Console.WriteLine("Student Name: " + studentName);
                    Console.WriteLine("Book Name: " + book.Name);
                    Console.WriteLine("Book ID: " + book.Id);
                    Console.WriteLine("Author: " + book.Author);
                    Console.WriteLine("Remaining Quantity: " + book.Quantity);
                    return;
                }
            }
            Console.WriteLine("Book not found.");
        }
        public void ReturnBook(string studentName, string bookId)
        {
            List<Book> books = repo.GetBooks();
            List<string> records = repo.GetIssuedRecords();
            Book foundBook = null;

            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    foundBook = book;
                    break;
                }
            }

            if (foundBook == null)
            {
                Console.WriteLine("Book not found in library.");
                return;
            }

            int recordIndex = -1;

            for (int i = 0; i + 4 < records.Count; i += 5)
            {
                if (records[i] == studentName &&
                    records[i + 2] == bookId)
                {
                    recordIndex = i;
                    break;
                }
            }

            if (recordIndex == -1)
            {
                Console.WriteLine("Issued record not found.");
                return;
            }

            records.RemoveRange(recordIndex, 5);
            foundBook.Quantity++;

            repo.SaveBooks(books);
            repo.SaveIssuedRecords(records);
            repo.SaveHistory("RETURNED", foundBook);
            Console.WriteLine("Student Name: " + studentName);
            Console.WriteLine("Book Name: " + foundBook.Name);
            Console.WriteLine("Book ID: " + foundBook.Id);
            Console.WriteLine("Author: " + foundBook.Author);
            Console.WriteLine("Updated Quantity: " + foundBook.Quantity);

            Console.WriteLine("Book returned successfully.");
        }

    }
    }

      

