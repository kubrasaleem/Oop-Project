using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.ADMIN
{
    public class AdminRepository
    {
        private readonly string booksFile = "books.txt";
        private readonly string issuedFile = "issued.txt";
        private readonly string historyFile = "history.txt";
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(booksFile))
                return books;
            StreamReader reader = new StreamReader(booksFile);

            while (!reader.EndOfStream)
            {
                Book book = new Book();

                book.Name = reader.ReadLine();
                book.Id = reader.ReadLine();
                book.Author = reader.ReadLine();

                string quantity = reader.ReadLine();
                book.Quantity = Convert.ToInt32(quantity);

                books.Add(book);
            }
            reader.Close();

            return books;
        }
        public void SaveBooks(List<Book> books)
        {
            StreamWriter writer = new StreamWriter(booksFile);

            foreach (Book book in books)
            {
                writer.WriteLine(book.Name);
                writer.WriteLine(book.Id);
                writer.WriteLine(book.Author);
                writer.WriteLine(book.Quantity);
            }

            writer.Close();
        }
        public List<string> GetIssuedRecords()
        {
            if (!File.Exists(issuedFile))
                return new List<string>();

            return new List<string>(
                File.ReadAllLines(issuedFile));
        }
        public void SaveIssuedRecords(List<string> records)
        {
            File.WriteAllLines(issuedFile, records);
        }
        public void SaveHistory(
           string action, Book book)
        {
            StreamWriter writer =
                new StreamWriter(historyFile, true);

            writer.WriteLine(action);
            writer.WriteLine(book.Name);
            writer.WriteLine(book.Id);
            writer.WriteLine(book.Author);
            writer.WriteLine(book.Quantity);

            writer.Close();
        }
        public List<string> GetHistory()
        {
            if (!File.Exists(historyFile))
                return new List<string>();

            return new List<string>(
                File.ReadAllLines(historyFile));
        }
    }
            }
