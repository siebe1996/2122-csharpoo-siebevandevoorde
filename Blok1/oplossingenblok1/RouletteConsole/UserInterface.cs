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
            DrawNumbers();
            DrawBottomTwelveTiles();
            DrawLastRow();
        }

        private void DrawNumbers()
        {
            int[] dimLength = GetDimLength();
            string boarder = GiveBoarder(dimLength);
            boarder += "------|";
            String numberLine = "";
            for (int i = 0; i < dimLength[0]; i++)
            {
                Console.WriteLine(boarder);
                numberLine = GiveNumberline(dimLength, i);
                Console.WriteLine(numberLine);
            }
            Console.WriteLine(boarder);
        }

        private void DrawBottomTwelveTiles()
        {
            int[] dimLength = GetDimLength();
            Console.WriteLine(GiveBottomTwelveTiles());
            Console.WriteLine(GiveBoarder(dimLength));
        }

        private void DrawLastRow()
        {
            Console.WriteLine(GiveEightTeenTiles());
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
            numberLine += GiveRightTwelveTiles(lineNumber);
            return numberLine;
        }

        private string GiveRightTwelveTiles(int lineNumber)
        {
            Tile[] rightTwelveTiles = board.GetRightTwelveTiles();
            string rightTwelveTile = "";
            rightTwelveTile = string.Format("{0,0}-{1,-4}", rightTwelveTiles[lineNumber].GetNumber(0).GetValue().ToString(), rightTwelveTiles[lineNumber].GetNumber(rightTwelveTiles[lineNumber].Size() - 1).GetValue().ToString());
            rightTwelveTile += "|";
            return rightTwelveTile;

        }

        private string GiveBottomTwelveTiles()
        {
            Tile[] bottomTwelveTiles = board.GetBottomTwelveTiles();
            string bottomTwelveTile = "|";
            for (int i = 0; i < bottomTwelveTiles.Length; i++)
            {
                bottomTwelveTile += string.Format("{0,19}-{1,-19}", bottomTwelveTiles[i].GetNumber(0).GetValue().ToString(), bottomTwelveTiles[i].GetNumber(bottomTwelveTiles[i].Size() - 1).GetValue().ToString());
                bottomTwelveTile += "|";
            }
            return bottomTwelveTile;
        }

        private string GiveEightTeenTiles()
        {
            Tile[] eightTeenTiles = board.GetEightTeenTiles();
            string eightTeenTile = "|";
            for (int i = 0; i < eightTeenTiles.Length; i++)
            {
                eightTeenTile += string.Format("{0,9}-{1,-9}", eightTeenTiles[i].GetNumber(0).GetValue().ToString(), eightTeenTiles[i].GetNumber(eightTeenTiles[i].Size() - 1).GetValue().ToString());
                eightTeenTile += "|";
            }
            return eightTeenTile;
        }
    }
}
