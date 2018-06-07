using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poison
{
    class Program
    {
        static void Main(string[] args)
        {
            var apples = PickApples().Take(10000);

            var countPoisoned = apples.Count(n => n.Poisoned == true);

            Console.WriteLine(countPoisoned);

            var nonRedPoisoned = apples.Where(n => n.Poisoned == true && n.Colour != "Red").GroupBy(n => n.Colour)
                .Select(group => new
                {
                    Catg = group.Key,
                    Count = group.Count()
                }).OrderByDescending(n => n.Count).First();


            Console.WriteLine(nonRedPoisoned.Catg);


            //var maxConsecutivePoisoned = apples.SkipWhile(n => n.Poisoned == false);

            var grp = 0;
            var maxConsecutiveNonPoisonedRed = apples.Zip(apples.Skip(1).Concat(new Apple[] { null }),
                (x, y) => new { x, key = (x == null || y == null || (x.Poisoned == y.Poisoned && x.Colour == y.Colour)) ? grp : grp++ }
                ).GroupBy(i => i.key, (k, g) => g.Select(e => e.x));



            //foreach (var apple in maxConsecutiveNonPoisonedRed)
            //{
            //    Console.WriteLine(apple.ToString());
            //}

            Console.ReadLine();

            IEnumerable<Apple> PickApples()
            {
                int colourIndex = 1;
                int poisonIndex = 7;

                while (true)
                {
                    yield return new Apple
                    {
                        Colour = GetColour(colourIndex),
                        Poisoned = poisonIndex % 41 == 0
                    };

                    colourIndex += 5;
                    poisonIndex += 37;
                }
            }

            string GetColour(int colourIndex)
            {
                if (colourIndex % 13 == 0 || colourIndex % 29 == 0)
                {
                    return "Green";
                }

                if (colourIndex % 11 == 0 || colourIndex % 19 == 0)
                {
                    return "Yellow";
                }

                return "Red";
            }


        }

    }

}




