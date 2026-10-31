using PROJECT1.ADMIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.USER
{
    public class UserService
    {

        private UserRepository repo = new UserRepository();
        public List<Book> GetAllBooks()
        {
            return repo.GetBooks();
        }

        public List<string> GetIssuedRecords()
        {
            return repo.GetIssuedRecords();
        }

        public bool RequestIssueBook(
            Student student, string bookId)
        {
            Book book = null;

            foreach (Book b in repo.GetBooks())
            {
                if (b.Id == bookId)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
                return false;

            if (book.Quantity <= 0)
                return false;

            repo.SaveIssueRequest(student, book);
            return true;
        }

        public bool RequestReturnBook(
            Student student, string bookId)
        {
            Book book = null;

            foreach (Book b in repo.GetBooks())
            {
                if (b.Id == bookId)
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
                return false;

            repo.SaveReturnRequest(student, book);
            return true;
        }

        public bool ReserveBook(
            Student student, string bookId)
        {
            Book book = null;

            foreach (Book b in repo.GetBooks())
            {
                if (b.Id == bookId)
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
                return false;
            repo.SaveReservation(student, book);
            return true;
        }
    }
}
