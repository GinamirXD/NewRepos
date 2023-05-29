using System.Linq;

namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var sequenceA = new List<string[]> { new[] { "1995", "Lenina", "1" }, new[] { "1997", "Pushkina", "2" } };
            var sequenceD = new List<string[]> { new[] { "1", "Store1", "100" }, new[] { "2", "Store2", "200" } };
            var sequenceE = new List<string[]> { new[] { "Store1", "1", "1" }, new[] { "Store2", "2", "2" } };

            var purchases = from d in sequenceD
                            join e in sequenceE
                            on new { store = d[1], customer = d[2] } equals new { store = e[0], customer = e[1] }
                            select new { street = sequenceA.First(a => a[2] == e[1])[1], store = d[1], cost = int.Parse(d[2]) };

            var results = from p in purchases
                          group p by new { p.street, p.store } into g
                          orderby g.Key.street, g.Key.store
                          select new { g.Key.street, g.Key.store, totalCost = g.Sum(p => p.cost) };

            foreach (var r in results)
            {
                Console.WriteLine($"{r.street}, {r.store}, {r.totalCost}");
            }

        }
    }
}