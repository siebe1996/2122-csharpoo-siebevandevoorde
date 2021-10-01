using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteLogica;

namespace RouletteConsole
{
   
    class UserInterface
    {

        private readonly Board board;

        public UserInterface()
        {
            board = new Board();
        }

        public void Run()
        {
            DrawBoard();
        }

        private void DrawBoard()
        {
            int [] dimLength = GetDimLength();
            string LengthBoard = "|";
            int length = board.GetNumbers().Length;
            Console.WriteLine(length);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    
                }
            }
        }

        private int[] GetDimLength()
        {
            int rank = board.GetNumbers().Rank;
            int[] dimLength = new int[rank];
            for (int i = 0; i < rank; i++)
            {
                dimLength[i] = board.GetNumbers().GetLength(i);
                Console.WriteLine(dimLength[i]);
            }
            return dimLength;
        }

    }
}
