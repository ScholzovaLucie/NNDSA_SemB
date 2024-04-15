using SemB.Experimenty;
using SemB.Generator;
using SemB.Treap;
using System;

namespace SemB
{
    class MainClass
    {
        private static Treap<string, int> treap = new Treap<string, int>(new IntPriorityGenerator());
        private static TreapStatistics stats = new TreapStatistics();
        private const string ExitCommand = "K";

        public static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                ProcessChoice(choice, ref keepRunning);
                Console.WriteLine("-------");
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Vyberte akci:");
            Console.WriteLine("1: Načíst hodnoty ze souboru");
            Console.WriteLine("2: Přidej hodnotu");
            Console.WriteLine("3: Najdi hodnotu");
            Console.WriteLine("4: Odeber hodnotu");
            Console.WriteLine("5: Vyčisti strom");
            Console.WriteLine("6: Vypiš strom");
            Console.WriteLine("7: Uložit hodnoty stromu do souboru");
            Console.WriteLine("E0: Základní experimenty");
            Console.WriteLine("E1: Experiment obce");
            Console.WriteLine("E2: Statistické experimenty");
            Console.WriteLine("K: Konec");
        }

        private static void ProcessChoice(string choice, ref bool keepRunning)
        {
            switch (choice)
            {
                case "1":
                    LoadValuesFromFile();
                    break;
                case "2":
                    AddValue();
                    break;
                case "3":
                    FindValue();
                    break;
                case "4":
                    RemoveValue();
                    break;
                case "5":
                    treap.Clear();
                    Console.WriteLine("Strom vyčištěn");
                    break;
                case "6":
                    treap.PrintTree();
                    break;
                case "7":
                    SaveValuesToFile();
                    break;
                case "E0":
                    new ZakladniExperiment().RunExperiment();
                    break;
                case "E1":
                    new ObceExperiment(new IntPriorityGenerator()).RunExperiment();
                    break;
                case "E2":
                    RunStatisticalExperiments();
                    break;
                case ExitCommand:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Neplatná volba, zkuste to znovu.");
                    break;
            }
        }

        private static void LoadValuesFromFile()
        {
            Console.WriteLine("Zadej název souboru");
            string fileName = Console.ReadLine();
            treap.LoadFromFile(fileName);
        }

        private static void AddValue()
        {
            Console.WriteLine("Zadej hodnotu");
            string value = Console.ReadLine();
            treap.Add(value);
        }

        private static void FindValue()
        {
            Console.WriteLine("Zadej hledanou hodnotu");
            string value = Console.ReadLine();
            var node = treap.Find(value);
            Console.WriteLine(node != null ? node.ToString() : "Prvek nenalezen");
        }

        private static void RemoveValue()
        {
            Console.WriteLine("Zadej hodnotu k odstranění");
            string value = Console.ReadLine();
            bool removed = treap.Remove(value);
            Console.WriteLine(removed ? "Prvek odstraněn" : "Prvek nenalezen");
        }

        private static void SaveValuesToFile()
        {
            Console.WriteLine("Zadej název souboru");
            string fileName = Console.ReadLine();
            treap.SaveTreeToFile(fileName);
        }

        private static void RunStatisticalExperiments()
        {
            var experiments = new StatistickeExperimenty(new IntPriorityGenerator());
            experiments.RunExperiment();
            Console.WriteLine("Chceš uložit statistiku do souboru? Y/N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadej název souboru");
                string fileName = Console.ReadLine();
                experiments.SaveStatsToFile(fileName);
            }
        }
    }
}
