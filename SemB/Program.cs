using SemB.Treap;

namespace SemB
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Treap<string> treap = new Treap<string>();

            List<int> heights = new List<int>();

         
            for (int j = 0; j < 1023; j++)
            {
                string key = GenerateRandomNazevObce();
                treap.Add(key);
            }


            treap = new Treap<string>();
            treap.PrintTree();
            

            //HeightStatistics stat = new HeightStatistics(heights);
            //stat.Analyze();
           
        }

        static Random rnd = new Random();
        static string GenerateRandomNazevObce()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
