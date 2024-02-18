using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Document
    {
        protected string documentNumber;
        protected DateTime date;
        protected decimal amount;

        public Document(string documentNumber, DateTime date, decimal amount)
        {
            this.documentNumber = documentNumber;
            this.date = date;
            this.amount = amount;
        }

        public DateTime Date
        {
            get { return date; }
        }

        public virtual void Show()
        {
            Console.WriteLine($"Document Number: {documentNumber}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Amount: {amount:C}");
        }
    }

    // Клас рахунок
    public class Invoice : Document, IEnumerable<string>
    {
        protected string seller;
        protected string buyer;
        protected string description;

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
            this.seller = seller;
            this.buyer = buyer;
            this.description = description;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Seller: {seller}");
            Console.WriteLine($"Buyer: {buyer}");
            Console.WriteLine($"Description: {description}");
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return seller;
            yield return buyer;
            yield return description;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Receipt : Document, IEnumerable<string>
    {
        protected string payer;

        public Receipt(string documentNumber, DateTime date, decimal amount, string payer)
            : base(documentNumber, date, amount)
        {
            this.payer = payer;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Payer: {payer}");
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return payer;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // Клас накладна
    public class Waybill : Document, IEnumerable<string>
    {
        protected string sender;
        protected string receiver;
        protected List<string> goods;

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
            this.sender = sender;
            this.receiver = receiver;
            this.goods = goods;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Sender: {sender}");
            Console.WriteLine($"Receiver: {receiver}");
            Console.WriteLine("Goods:");
            foreach (var item in goods)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return sender;
            yield return receiver;
            foreach (var item in goods)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Task3
    {
        public static void Task3_()
        {
            Invoice invoice = new Invoice(
                "INV001",
                DateTime.Now,
                1000.50m,
                "SellerName",
                "BuyerName",
                "Description"
            );
            Receipt receipt = new Receipt("RCPT001", DateTime.Now, 500.75m, "PayerName");
            Waybill waybill = new Waybill(
                "WB001",
                DateTime.Now,
                1200.25m,
                "SenderName",
                "ReceiverName",
                new List<string> { "Item1", "Item2" }
            );

            Console.WriteLine("Using foreach with Invoice:");
            foreach (var item in invoice)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nUsing foreach with Receipt:");
            foreach (var item in receipt)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nUsing foreach with Waybill:");
            foreach (var item in waybill)
            {
                Console.WriteLine(item);
            }
        }
    }
}
