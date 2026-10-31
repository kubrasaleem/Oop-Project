using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.ADMIN
{
    public class Book
    {
        public string Name;
        public string Id;
        public string Author;
        public int Quantity;
        public Book()
        {
            Name = "";
            Id = "";
            Author = "";
            Quantity = 0;
        }

        public Book(string name, string id, string author, int quantity)
        {
            Name = name;
            Id = id;
            Author = author;
            Quantity = quantity;
        }
        public bool IsAvailable
        {
            get
            {
                return Quantity > 0;
            }
        }
    }
    public class IssuedBook
    {
        public string StudentName;
        public string BookName;
        public string BookId;
        public string Author;
        public int Quantity;
        public IssuedBook()
        {
            StudentName = "";
            BookName = "";
            BookId = "";
            Author = "";
            Quantity = 0;
        }
        public IssuedBook(
                   string studentName,
                   string bookName,
                   string bookId,
                   string author,
                   int quantity)
        {
            StudentName = studentName;
            BookName = bookName;
            BookId = bookId;
            Author = author;
            Quantity = quantity;
        }
    }
    public class HistoryRecord
    {
        public string Action;
        public string BookName;
        public string BookId;
        public string Author;
        public int Quantity;
        public HistoryRecord()
        {
            Action = "";
            BookName = "";
            BookId = "";
            Author = "";
            Quantity = 0;
        }
        public HistoryRecord(
                   string action,
                   string bookName,
                   string bookId,
                   string author,
                   int quantity)
        {
            Action = action;
            BookName = bookName;
            BookId = bookId;
            Author = author;
            Quantity = quantity;
        }
    }
}
        

