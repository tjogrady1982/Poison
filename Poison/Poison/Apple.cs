﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poison
{
    class Apple
    {
        public string Colour { get; set; }
        public bool Poisoned { get; set; }

        public override string ToString()
        {
            return $"{Colour} apple{(Poisoned ? " (poisoned!)" : "")}";
        }
    }
}
