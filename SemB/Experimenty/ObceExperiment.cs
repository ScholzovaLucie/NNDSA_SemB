using SemB.Generator;
using SemB.Treap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Experimenty
{
    internal class ObceExperiment
    {
        private Treap<string, int> treap;

        public ObceExperiment(IPriorityGenerator<int> priorityGenerator)
        {
            treap = new Treap<string, int>(priorityGenerator);
        }

        public void RunExperiment()
        {
            string[] cities = {
            "Praha", "Brno", "Ostrava", "Plzeň", "Liberec",
            "Olomouc", "České_Budějovice", "Hradec_Králové", "Ústí_nad_Labem",
            "Pardubice", "Zlín", "Havířov", "Kladno", "Most", "Opava"
        };

            foreach (string city in cities)
            {
                AddAndPrint(city);
            }

            RemoveAndPrint("Praha");
            RemoveAndPrint("České_Budějovice");
            FindAndPrint("Ostrava");
        }

        private void AddAndPrint(string city)
        {
            treap.Add(city);
            treap.PrintTree();
            Console.WriteLine($"Výška: {treap.Height()}");
            Console.WriteLine("-------");
        }

        private void RemoveAndPrint(string city)
        {
            Console.WriteLine($"Odstraň prvek {city}");
            treap.Remove(city);
            treap.PrintTree();
            Console.WriteLine("-------");
        }

        private void FindAndPrint(string city)
        {
            Console.WriteLine($"Najdi prvek {city}");
            var foundCity = treap.Find(city);
            Console.WriteLine(foundCity != null ? foundCity.ToString() : "Prvek nenalezen");
            Console.WriteLine("-------");
        }
    }


}
