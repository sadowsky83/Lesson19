using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        // Компьютеры на складе
        static void Main(string[] args)
        {
            List<Computer> listComputers = new List<Computer>()
            {
                new Computer(){ Id=1, Mark="Mac", Type="Intel i7", Frequency=5700, RAM=64, HDD=2000, Video=12, Price=175000, Stock=8},
                new Computer(){ Id=2, Mark="Mac", Type="Intel i7", Frequency=4200, RAM=32, HDD=1500, Video=8, Price=120000, Stock=15},
                new Computer(){ Id=3, Mark="Mac", Type="Intel i7", Frequency=3500, RAM=16, HDD=1000, Video=8, Price=95000, Stock=6},
                new Computer(){ Id=4, Mark="ASUS", Type="Intel i5", Frequency=4200, RAM=64, HDD=2000, Video=12, Price=128000, Stock=12},
                new Computer(){ Id=5, Mark="ASUS", Type="Intel i5", Frequency=3500, RAM=32, HDD=1500, Video=8, Price=114000, Stock=32},
                new Computer(){ Id=6, Mark="ASUS", Type="Intel i5", Frequency=3000, RAM=16, HDD=1000, Video=4, Price=84000, Stock=29},
                new Computer(){ Id=7, Mark="Acer", Type="AMD", Frequency=3500, RAM=64, HDD=2000, Video=8, Price=105000, Stock=15},
                new Computer(){ Id=8, Mark="Acer", Type="AMD", Frequency=3000, RAM=32, HDD=1500, Video=8, Price=87000, Stock=8},
                new Computer(){ Id=9, Mark="Acer", Type="AMD", Frequency=2500, RAM=16, HDD=1000, Video=4, Price=63000, Stock=9},
                new Computer(){ Id=10, Mark="HP", Type="Intel i7", Frequency=3800, RAM=64, HDD=2000, Video=12, Price=90000, Stock=6},
            };

            Console.WriteLine("Ведите характеристики компьютера:");

            Console.WriteLine("Процессор (AMD, Intel i5, Intel i7):");
            string type = Console.ReadLine();
            List<Computer> computers = listComputers
                .Where(c => c.Type == type)
                .ToList();
            Console.WriteLine();
            foreach (Computer c in computers)
                Console.WriteLine($"{c.Id} {c.Mark} {c.Type} {c.Frequency} {c.RAM} {c.HDD} {c.Video} {c.Price} {c.Stock}");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Объём ОЗУ, (64, 32, 16)Гб:");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = listComputers
                .Where(c => c.RAM >= ram)
                .ToList();
            Console.WriteLine();
            foreach (Computer c in computers2)
                Console.WriteLine($"{c.Id} {c.Mark} {c.Type} {c.Frequency} {c.RAM} {c.HDD} {c.Video} {c.Price} {c.Stock}");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Cписок, отсортированный по увеличению стоимости:");
            var computersPrice = listComputers
                .OrderBy(c => c.Price)
                .ToList();
            Console.WriteLine();
            foreach (var c in computersPrice)
                Console.WriteLine($"{c.Id} {c.Mark} {c.Type} {c.Frequency} {c.RAM} {c.HDD} {c.Video} {c.Price} {c.Stock}");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Cписок, сгруппированный по типу процессора:\n");
            var compsType = from Computer in listComputers
                            group Computer by Computer.Type;
            foreach (IGrouping<string, Computer> c in compsType)
            {
                Console.WriteLine(c.Key);
                foreach (var t in c)
                    Console.WriteLine($"{t.Id} {t.Mark} {t.Type} {t.Frequency} {t.RAM} {t.HDD} {t.Video} {t.Price} {t.Stock}");
                Console.WriteLine();
            }
            Console.ReadKey();
            
            Console.WriteLine("Самый дорогой компьютер:");
            var compMax = listComputers
                .Max(c => c.Price);
            Console.WriteLine(compMax);

            Console.WriteLine();
            Console.WriteLine("Самый бюджетный компьютер:");
            var compMin = listComputers
                .Min(c => c.Price);
            Console.WriteLine(compMin);

            Console.WriteLine();
            Console.WriteLine("Проверка наличия на складе компьюеторв определенной конфигурации в количестве более 30 штук:");
            bool compsStock = listComputers
                .Any(c => c.Stock > 30);
            if (compsStock)
                Console.WriteLine("\nНа складе есть более 30 компьютеров, определенной конфигурации");
            else
                Console.WriteLine("\nК сожалению на складе нет такого такого количества компьютеров, определенной конфигурации");
            Console.ReadKey();
        }
    }

    class Computer
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public int Frequency { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int Video { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
