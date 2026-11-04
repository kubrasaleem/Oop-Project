using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1.USER
{
    public class Student
    {
        public string Name;
        public string RegistrationNumber;
        public Student()
        {
            Name = "";
            RegistrationNumber = "";
        }
        public Student(string name, string registrationNumber)
        {
            Name = name;
            RegistrationNumber = registrationNumber;
        }
    }
    public class BookRequest
    {
        public string StudentName;
        public string RegistrationNumber;
        public string BookName;
        public string BookId;
        public string Author;
        public string RequestType;
        public int Quantity;
        public BookRequest()
        {
            StudentName = "";
            RegistrationNumber = "";
            BookName = "";
            BookId = "";
            Author = "";
            RequestType = "";
            Quantity = 0;
        }
        public BookRequest(
           string studentName,
           string registrationNumber,
           string bookName,
           string bookId,
           string author,
           string requestType,
           int quantity)
        {
            StudentName = studentName;
            RegistrationNumber = registrationNumber;
            BookName = bookName;
            BookId = bookId;
            Author = author;
            RequestType = requestType;
            Quantity = quantity;
        }
    }
    public class Reservation
    {
        public string StudentName;
        public string RegistrationNumber;
        public string BookName;
        public string BookId;
        public string Author;
        public Reservation()
        {
            StudentName = "";
            RegistrationNumber = "";
            BookName = "";
            BookId = "";
            Author = "";
        }
        public Reservation(
            string studentName,
            string registrationNumber,
            string bookName,
            string bookId,
            string author)
        {
            StudentName = studentName;
            RegistrationNumber = registrationNumber;
            BookName = bookName;
            BookId = bookId;
            Author = author;
        }
    }
}
