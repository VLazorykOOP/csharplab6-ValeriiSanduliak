using System;
using System.Collections.Generic;

namespace Task1
{
    public interface IDocument
    {
        string DocumentNumber { get; }
        DateTime Date { get; }
        decimal Amount { get; }
        void Show();
    }

    public interface IUserInterface
    {
        void DisplayMessage(string message);
        string GetUserInput();
    }

    public class Document : IDocument
    {
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Document(string documentNumber, DateTime date, decimal amount)
        {
            DocumentNumber = documentNumber;
            Date = date;
            Amount = amount;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Document Number: {DocumentNumber}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Amount: {Amount:C}");
        }
    }

    public class Invoice : Document, IComparable<Invoice>, IUserInterface
    {
        protected string Seller { get; }
        protected string Buyer { get; }
        protected string Description { get; }

        public Invoice(
            string documentNumber,
            DateTime date,
            decimal amount,
            string seller,
            string buyer,
            string description
        )
            : base(documentNumber, date, amount)
        {
            Seller = seller;
            Buyer = buyer;
            Description = description;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Seller: {Seller}");
            Console.WriteLine($"Buyer: {Buyer}");
            Console.WriteLine($"Description: {Description}");
        }

        public int CompareTo(Invoice other)
        {
            return Date.CompareTo(other.Date);
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine($"Invoice Message: {message}");
        }

        public string GetUserInput()
        {
            Console.Write("Enter Invoice User Input: ");
            return Console.ReadLine();
        }
    }

    public class Receipt : Document, IUserInterface
    {
        protected string Payer { get; }

        public Receipt(string documentNumber, DateTime date, decimal amount, string payer)
            : base(documentNumber, date, amount)
        {
            Payer = payer;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Payer: {Payer}");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine($"Receipt Message: {message}");
        }

        public string GetUserInput()
        {
            Console.Write("Enter Receipt User Input: ");
            return Console.ReadLine();
        }
    }

    public class Waybill : Document, IUserInterface
    {
        protected string Sender { get; }
        protected string Receiver { get; }
        protected List<string> Goods { get; }

        public Waybill(
            string documentNumber,
            DateTime date,
            decimal amount,
            string sender,
            string receiver,
            List<string> goods
        )
            : base(documentNumber, date, amount)
        {
            Sender = sender;
            Receiver = receiver;
            Goods = goods;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Sender: {Sender}");
            Console.WriteLine($"Receiver: {Receiver}");
            Console.WriteLine("Goods:");
            foreach (var item in Goods)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine($"Waybill Message: {message}");
        }

        public string GetUserInput()
        {
            Console.Write("Enter Waybill User Input: ");
            return Console.ReadLine();
        }
    }

    public class Task1
    {
        public static void Task1_()
        {
            Invoice invoice = new Invoice(
                "INV001",
                DateTime.Now,
                1000.50m,
                "SellerName",
                "BuyerName",
                "Description"
            );

            Console.WriteLine("Showing Invoice:");
            invoice.Show();

            int comparisonResult = invoice.CompareTo(
                new Invoice(
                    "INV002",
                    DateTime.Now.AddDays(1),
                    1500.25m,
                    "Seller2",
                    "Buyer2",
                    "Desc2"
                )
            );
            Console.WriteLine($"Comparison Result: {comparisonResult}");

            invoice.DisplayMessage("This is an invoice message.");
            string userInput1 = invoice.GetUserInput();
            Console.WriteLine($"User Input: {userInput1}");
            Console.WriteLine();
            Receipt receipt = new Receipt("RCPT001", DateTime.Now, 500.75m, "PayerName");

            Console.WriteLine("Showing Receipt:");
            receipt.Show();

            receipt.DisplayMessage("This is a receipt message.");
            string userInput2 = receipt.GetUserInput();
            Console.WriteLine($"User Input: {userInput2}");

            Console.WriteLine();

            Waybill waybill = new Waybill(
                "WB001",
                DateTime.Now,
                1200.25m,
                "SenderName",
                "ReceiverName",
                new List<string> { "Item1", "Item2" }
            );

            Console.WriteLine("Showing Waybill:");
            waybill.Show();

            waybill.DisplayMessage("This is a waybill message.");
            string userInput = waybill.GetUserInput();
            Console.WriteLine($"User Input: {userInput}");

            Console.WriteLine();
        }
    }
}
