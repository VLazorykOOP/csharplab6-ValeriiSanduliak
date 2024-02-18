using System;
using Task1;

namespace Lab6CSharp
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Lab 6 CSharp");

            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Select a task:");
                Console.WriteLine("1. Task 1");
                Console.WriteLine("2. Task 2");
                Console.WriteLine("3. Task 3");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=========================================================");
                Console.Write("Enter your choice >>> ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1.Task1.Task1_();
                        break;

                    case "2":
                        Task2.Task2.Task2_();
                        break;
                    case "3":
                        // Task3.Task3.Task3_();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
