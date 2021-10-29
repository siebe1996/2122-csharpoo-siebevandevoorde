using System;
using RouletteData;
using RouletteLogica;

namespace RouletteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new UserInterface(new Board(new Data())).Run();
        }
    }
}
