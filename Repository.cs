using PROJECT1.ADMIN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.USER
{
    public class UserRepository
    {
        private readonly string booksFile = "books.txt";
        private readonly string issuedFile = "issued.txt";
        private readonly string issueRequestFile = "requestissue.txt";
        private readonly string returnRequestFile = "requestreturn.txt";
        private readonly string reserveFile = "reserve.txt";

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(booksFile))
            {
                return books;
            }
            using (StreamReader reader = new StreamReader(booksFile))

            { 

                while (!reader.EndOfStream)
                {
                    string name = reader.ReadLine();
                    string id = reader.ReadLine();
                    string author = reader.ReadLine();
                    string quantity = reader.ReadLine();

                    if (name == null || id == null ||
                        author == null || quantity == null)
                    {
                        break;
                    }

                    Book book = new Book();

                    book.Name = name;
                    book.Id = id;
                    book.Author = author;
                    book.Quantity = int.Parse(quantity);

                    books.Add(book);
                }
        }
            return books;
}
        public List<string> GetIssuedRecords()
        {
            if (!File.Exists(issuedFile))
            {
                return new List<string>();
            }

            return new List<string>(
                File.ReadAllLines(issuedFile));
        }

        public void SaveIssuedRecords(List<string> records)
        {
            File.WriteAllLines(issuedFile, records);
        }

        public void SaveIssueRequest(
            Student student, Book book)
        {
            using (StreamWriter writer =
     new StreamWriter(issueRequestFile, true))
            {
                writer.WriteLine(student.Name);
                writer.WriteLine(student.RegistrationNumber);
                writer.WriteLine(book.Name);
                writer.WriteLine(book.Id);
                writer.WriteLine(book.Author);
                writer.WriteLine(book.Quantity);

              
            }
        }
        public void SaveReturnRequest(
            Student student, Book book)
        {
            using (StreamWriter writer =
    new StreamWriter(returnRequestFile, true)) {

                writer.WriteLine(student.Name);
                writer.WriteLine(student.RegistrationNumber);
                writer.WriteLine(book.Name);
                writer.WriteLine(book.Id);
                writer.WriteLine(book.Author);
                writer.WriteLine(book.Quantity);

           
            }
        }
        public void SaveReservation(
            Student student, Book book)
        {

            using (StreamWriter writer =
    new StreamWriter(reserveFile, true))
            {

                writer.WriteLine(student.Name);
                writer.WriteLine(student.RegistrationNumber);
                writer.WriteLine(book.Name);
                writer.WriteLine(book.Id);
                writer.WriteLine(book.Author);
            }

        }
    }
}

