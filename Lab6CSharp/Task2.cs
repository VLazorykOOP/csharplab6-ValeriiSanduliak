using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface ISoftware
    {
        string Name { get; }
        string Manufacturer { get; }
        void ShowInfo();
        bool CanBeUsed(DateTime currentDate);
    }

    public class FreeSoftware : ISoftware
    {
        public string Name { get; }
        public string Manufacturer { get; }

        public FreeSoftware(string name, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
        }

        public bool CanBeUsed(DateTime currentDate)
        {
            return true;
        }
    }

    public class SharewareSoftware : ISoftware
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public DateTime InstallationDate { get; }
        public TimeSpan FreeUsagePeriod { get; }

        public SharewareSoftware(
            string name,
            string manufacturer,
            DateTime installationDate,
            TimeSpan freeUsagePeriod
        )
        {
            Name = name;
            Manufacturer = manufacturer;
            InstallationDate = installationDate;
            FreeUsagePeriod = freeUsagePeriod;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Installation Date: {InstallationDate}");
            Console.WriteLine($"Free Usage Period: {FreeUsagePeriod.TotalDays} days");
        }

        public bool CanBeUsed(DateTime currentDate)
        {
            return currentDate <= InstallationDate + FreeUsagePeriod;
        }
    }

    public class CommercialSoftware : ISoftware
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public decimal Price { get; }
        public DateTime InstallationDate { get; }
        public TimeSpan UsagePeriod { get; }

        public CommercialSoftware(
            string name,
            string manufacturer,
            decimal price,
            DateTime installationDate,
            TimeSpan usagePeriod
        )
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            InstallationDate = installationDate;
            UsagePeriod = usagePeriod;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Installation Date: {InstallationDate}");
            Console.WriteLine($"Usage Period: {UsagePeriod.TotalDays} days");
        }

        public bool CanBeUsed(DateTime currentDate)
        {
            return currentDate <= InstallationDate + UsagePeriod;
        }
    }

    public class Task2
    {
        public static void Task2_()
        {
            List<ISoftware> softwareDatabase = new List<ISoftware>
            {
                new FreeSoftware("FreeApp1", "ManufacturerA"),
                new SharewareSoftware(
                    "TrialApp1",
                    "ManufacturerB",
                    DateTime.Now.AddDays(-15),
                    TimeSpan.FromDays(10)
                ),
                new CommercialSoftware(
                    "CommercialApp1",
                    "ManufacturerC",
                    99.99m,
                    DateTime.Now.AddMonths(-3),
                    TimeSpan.FromDays(365)
                ),
                new FreeSoftware("FreeApp2", "ManufacturerD"),
                new CommercialSoftware(
                    "CommercialApp2",
                    "ManufacturerE",
                    149.99m,
                    DateTime.Now.AddDays(-60),
                    TimeSpan.FromDays(180)
                )
            };
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Software Database:");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var software in softwareDatabase)
            {
                software.ShowInfo();
                Console.WriteLine();
            }

            DateTime currentDate = DateTime.Now;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Software Available for Current Date:");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
            foreach (var software in softwareDatabase)
            {
                if (software.CanBeUsed(currentDate))
                {
                    software.ShowInfo();
                    Console.WriteLine();
                }
            }
        }
    }
}
