using System;
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
            int[] dimLength = GetDimLength();
            string boarder = GiveBoarder(dimLength);
            String numberLine = "";
            for (int i = 0; i < dimLength[0]; i++)
            {
                Console.WriteLine(boarder);
                numberLine = GiveNumberline(dimLength, i);
                Console.WriteLine(numberLine);
            }
            Console.WriteLine(boarder);
        }

        private int[] GetDimLength()
        {
            int rank = board.GetNumbers().Rank;
            int[] dimLength = new int[rank];
            for (int i = 0; i < rank; i++)
            {
                dimLength[i] = board.GetNumbers().GetLength(i);
            }
            return dimLength;
        }

        private string GiveBoarder(int[] dimLength)
        {
            string boarder = "|";
            for (int j = 0; j < dimLength[1]; j++)
            {
                boarder += "---------|";
            }
            return boarder;
        }

        private string GiveNumberline(int[] dimLength, int lineNumber)
        {
            String numberLine = "|";
            Number[,] numbers = board.GetNumbers();
            for (int j = 0; j < dimLength[1]; j++)
            {
                if(numbers[lineNumber, j].GetValue() < 10)
                {
                    numberLine += string.Format("{0,0}/{1,-7}", numbers[lineNumber, j].GetValue().ToString(), new MyColor(numbers[lineNumber, j].GetColor()).ToString());
                }
                else
                {
                    numberLine += string.Format("{0,0}/{1,-6}", numbers[lineNumber, j].GetValue().ToString(), new MyColor(numbers[lineNumber, j].GetColor()).ToString());
                }
                numberLine += "|";
            }

            return numberLine;
        }

        private string AddSpacesNumberLine(string numberLine)
        {
            while (numberLine.Length < 10)
            {
                numberLine += " ";
            }
            return numberLine;
        }
    }
}
