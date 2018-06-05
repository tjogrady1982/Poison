﻿using System;
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
            var apples = PickApples().Take(100000);

            foreach (var apple in apples)
            {
                Console.WriteLine(apple.Colour + "  " + apple.Poisoned);
            }

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




