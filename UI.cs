using PROJECT1.ADMIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.USER
{
    public class UserUI
    {
        private UserService service = new UserService();
        private Student student;

        public void Start()
        {
            student = new Student();

            Console.WriteLine("===== USER LOGIN =====");

            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Registration Number: ");
            student.RegistrationNumber = Console.ReadLine();
            if (student.Name == "" || student.RegistrationNumber == "")
            {
                Console.WriteLine("Invalid student details!");
                return;
            }

            ShowMenu();
        }

        private void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n========== USER MENU ==========");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Request Book Issue");
                Console.WriteLine("4. Return Book Request");
                Console.WriteLine("5. Low Stock Books");
                Console.WriteLine("6. Check Availability");
                Console.WriteLine("7. My Issued Books");
                Console.WriteLine("8. Instructions and Rules");
                Console.WriteLine("9. Reserve Book");
                Console.WriteLine("10.Search by author.");
                Console.WriteLine("11. Exit");


                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    ViewAllBooks();
                }
                else if (choice == "2")
                {
                    SearchBook();
                }
                else if (choice == "3")
                {
                    RequestIssueBook();
                }
                else if (choice == "4")
                {

                    RequestReturnBook();
                }
                else if (choice == "5")
                {
                    LowStockBooks();
                }
                else if (choice == "6")
                {
                    CheckAvailability();
                }
                else if (choice == "7")
                {
                    ViewIssuedRecords();
                }
                else if (choice == "8")
                {
                    ShowInstructions();
                }
                else if (choice == "9")
                {
                    ReserveBook();
                }
                else if (choice == "10")
                {
                    searchbyauthor();
                }
                else if (choice == "11")
                {
                    Console.WriteLine("Thank you for using the system!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Try again.");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void ViewAllBooks()
        {
            List<Book> books = service.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }
            Console.WriteLine("Enter pagesize: ");
            string pagesize = Console.ReadLine();
            Console.WriteLine("1.Enter N for next page: ");
            Console.WriteLine("2.Enter F for next page: ");
            Console.WriteLine("3.Enter L for next page: ");
            Console.WriteLine("4.Enter X for next page: ");
            string key = Console.ReadLine();
            foreach (Book book in books)
            {
                DisplayBook(book);
            }
        }
        private void searchbyauthor()
        {
            Console.Write("1.Enter Book author:");
            string author = Console.ReadLine();
            Console.Write("2.Enter Book quantity:");
            string quantity = Console.ReadLine();
            Console.Write("3.Enter Comparison: ");
            string comparison = Console.ReadLine();
            List<Book> books = service.GetAllBooks();
            List<Book> book = service.Search(quantity, author,bookname);

        }
        private void SearchBook()
        {
            Console.Write("Enter Book ID: ");
            string id = Console.ReadLine();

            List<Book> books = service.GetAllBooks();
            Book foundBook = null;

            foreach (Book book in books)
            {
                if (book.Id.Equals(id,
                    StringComparison.OrdinalIgnoreCase))
                {
                    foundBook = book;
                    break;
                }
            }

            if (foundBook != null)
            {
                DisplayBook(foundBook);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        private void RequestIssueBook()
        {
            ViewAllBooks();

            Console.Write("Enter Book ID to issue: ");
            string id = Console.ReadLine();

            bool result = service.RequestIssueBook(student, id);

            if (result)
            {
                Console.WriteLine("Issue request submitted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found or unavailable.");
            }
        }

        private void RequestReturnBook()
        {
            Console.Write("Enter Book ID to return: ");
            string id = Console.ReadLine();

            bool result = service.RequestReturnBook(student, id);

            if (result)
            {
                Console.WriteLine("Return request submitted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private void ReserveBook()
        {
            ViewAllBooks();

            Console.Write("Enter Book ID to reserve: ");
            string id = Console.ReadLine();

            bool result = service.ReserveBook(student, id);

            if (result)
            {
                Console.WriteLine("Book reserved successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private void ViewIssuedRecords()
        {
            List<string> records = service.GetIssuedRecords();

            if (records.Count == 0)
            {
                Console.WriteLine("No issued records found.");
                return;
            }

            foreach (string record in records)
            {
                Console.WriteLine(record);
            }
        }



        private void DisplayBook(Book book)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Book Name: " + book.Name);
            Console.WriteLine("Book ID: " + book.Id);
            Console.WriteLine("Author: " + book.Author);
            Console.WriteLine("Quantity: " + book.Quantity);
        }
        private void LowStockBooks()
        {
            List<Book> books = service.GetAllBooks();
            bool found = false;

            Console.WriteLine("===== LOW STOCK BOOKS =====");

            foreach (Book book in books)
            {
                if (book.Quantity > 0 && book.Quantity <= 2)
                {
                    DisplayBook(book);
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("No low-stock books found.");
            }
        }
        private void CheckAvailability()
        {
            Console.Write("Enter Book ID: ");
            string id = Console.ReadLine();

            List<Book> books = service.GetAllBooks();
            bool found = false;

            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    found = true;
                    if (book.Quantity > 0)
                    {
                        Console.WriteLine("Book is available.");
                    }
                    else
                    {
                        Console.WriteLine("Book is not available.");
                    }

                    DisplayBook(book);
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Book not found.");
            }
        }
        private void ShowInstructions()
        {
            Console.WriteLine("===== LIBRARY RULES =====");
            Console.WriteLine("1. Enter correct Book ID.");
            Console.WriteLine("2. Check book availability.");
            Console.WriteLine("3. Return books on time.");
            Console.WriteLine("4. Follow library rules.");
        }
    }
}
