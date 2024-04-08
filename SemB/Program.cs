using SemB.Treap;
using System;

namespace SemB
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Parser<string> parser = new Parser<string>();
            var treap = new Treap<string>(); // Předpokládáme existenci generické třídy Treap<T>
            var stats = new TreapStatistics(); // Pro statistické zpracování
            var keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1: Načíst hodnoty ze souboru");
                Console.WriteLine("2: Přidej hodnotu");
                Console.WriteLine("3: Odeber hodnotu");
                Console.WriteLine("4: Vyčisti strom");
                Console.WriteLine("5: Vypiš strom");
                Console.WriteLine("6: Vytvoř statistiku");
                Console.WriteLine("7: Uložit hodnoty stromu do souboru");
                Console.WriteLine("8: Uložit statistickou analýzu do souboru");
                Console.WriteLine("9: Konec");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        parser.LoadValuesFromFile(treap, "files/data.txt");
                        break;
                    case "2":
                        Console.WriteLine("Zadávejte hodnoty (pro ukončení zadávání zadejte 'konec'):");
                        string addValue = Console.ReadLine();
                        treap.Add(addValue); 
                        break;
                    case "3":
                        string removeValue = Console.ReadLine();
                        treap.Remove(removeValue);
                        break;
                    case "4":
                        treap.Clear();
                        break;
                    case "5":
                        treap.PrintTree();
                        break;
                    case "6":
                        stats.AddHeight(treap.Height());
                        Console.WriteLine($"Průměr: {stats.GetAverageHeight()}");
                        Console.WriteLine($"Maximum: {stats.GetMaxHeight()}");
                        Console.WriteLine($"Minimum: {stats.GetMinHeight()}");
                        Console.WriteLine($"Modus: {stats.GetModeHeight()}");
                        stats.PrintCumulativeAverages();
                        break;
                    case "7":
                        parser.SaveTreeToFile(treap, "files/data.txt");
                        break;
                    case "8":
                        parser.SaveStatsToFile(stats, "files/data_stat.txt");
                        break;
                    case "9":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        break;
                }
            }
        }

       
    }
}
