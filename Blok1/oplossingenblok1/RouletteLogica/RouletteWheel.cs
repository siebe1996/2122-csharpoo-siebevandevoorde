﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLogica
{
    public class RouletteWheel
    {
        private static Random random = new Random();
        public static int Turn()
        {
            return random.Next(37);
        }
    }
}
