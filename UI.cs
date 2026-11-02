using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.ADMIN
{
    public class AdminUI
    {
        private AdminService service = new AdminService();

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("   LIBRARY MANAGEMENT SYSTEM");
                Console.WriteLine("           ADMIN MENU");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Update Book");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("6. Sort Books");
                Console.WriteLine("7. Issue Book");
                Console.WriteLine("8. Return Book");
                Console.WriteLine("9. View History");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                int option = Convert.ToInt32(input);

                if (option == 1)
                {
                    AddBookUI();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    service.ViewBooks();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    SearchBookUI();
                }
                else if (option == 4)
                {
                    UpdateBookUI();
                }
                else if (option == 5)
                {
                    DeleteBookUI();
                }
                else if (option == 6)
                {
                    service.SortBooks();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 7)
                {
                    IssueBookUI();
                }
                else if (option == 8)
                {
                    ReturnBookUI();
                }
                else if (option == 9)
                {
                    Console.Clear();
                    service.ViewHistory();
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 10)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                }
            }
        }

        private void AddBookUI()
        {
            Console.Clear();
            Console.WriteLine("----- Add Book -----");

            Book book = new Book();

            Console.Write("Enter book name: ");
            book.Name = Console.ReadLine();

            Console.Write("Enter book ID: ");
            book.Id = Console.ReadLine();

            Console.Write("Enter author name: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter quantity: ");
            book.Quantity = Convert.ToInt32(Console.ReadLine());

            service.AddBook(book);

            Console.ReadKey();
        }

        private void SearchBookUI()
        {
            Console.Clear();
            Console.WriteLine("----- Search Book -----");

            Console.Write("Enter book ID: ");
            string id = Console.ReadLine();

            Book book = service.SearchBook(id);

            if (book != null)
            {
                Console.WriteLine("Book Name: " + book.Name);
                Console.WriteLine("Book ID: " + book.Id);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine("Quantity: " + book.Quantity);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            Console.ReadKey();
        }

        private void UpdateBookUI()
        {
            Console.Clear();
            Console.WriteLine("----- Update Book -----");

            Console.Write("Enter book ID: ");
            string id = Console.ReadLine();

            Book oldBook = service.SearchBook(id);

            if (oldBook != null)
            {
                Book book = new Book();

                book.Id = id;

                Console.Write("Enter new book name: ");
                book.Name = Console.ReadLine();

                Console.Write("Enter new author name: ");
                book.Author = Console.ReadLine();

                Console.Write("Enter new quantity: ");
                book.Quantity = Convert.ToInt32(Console.ReadLine());

                service.UpdateBook(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            Console.ReadKey();
        }

        private void DeleteBookUI()
        {
            Console.Clear();
            Console.WriteLine("----- Delete Book -----");

            Console.Write("Enter book ID: ");
            string id = Console.ReadLine();

            service.DeleteBook(id);

            Console.ReadKey();
        }

        private void IssueBookUI()
        {
            Console.Clear();
            Console.WriteLine("----- Issue Book -----");

            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter book ID: ");
            string bookId = Console.ReadLine();

            service.IssueBook(studentName, bookId);

            Console.ReadKey();
        }

        private void ReturnBookUI()
        {
            Console.Clear();
            Console.WriteLine("----- Return Book -----");

            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter book ID: ");
            string bookId = Console.ReadLine();

            service.ReturnBook(studentName, bookId);

            Console.ReadKey();
        }
    }
}
