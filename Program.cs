using PROJECT1.ADMIN;
using PROJECT1.USER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT1
{
internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===== LIBRARY SYSTEM =====");
                Console.WriteLine("1. Admin Menu");
                Console.WriteLine("2. User Menu");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    AdminUI admin = new AdminUI();
                    admin.ShowMenu();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    UserUI user = new UserUI();
                    user.Start();
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
        }
    }
}

