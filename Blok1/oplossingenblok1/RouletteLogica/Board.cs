using System;
using System.Drawing;
using System.Collections.Generic;

namespace RouletteLogica
{
    public class Board
    {
        private Number[,] numbers = new Number[3, 12];
        private Tile[] numberTiles = new Tile[36];
        private Tile[] rightTwelveTiles = new Tile[3];
        private Tile[] bottomTwelveTiles = new Tile[3];
        private Tile[] eightTeenTiles = new Tile[2];
        private Tile[] evenOddTiles = new Tile[2];
        private Tile[] redBlackTiles = new Tile[2];

        public Board()
        {
            NumbersBoardFiller();
            RightTwelveTileMaker();
            RunningOverAllNumbers();
        }

        public Number[,] GetNumbers()
        {
            return numbers;
        }

        public Tile[] GetNumberTiles()
        {
            return numberTiles;
        }

        public Tile[] GetRightTwelveTiles()
        {
            return rightTwelveTiles;
        }

        public Tile[] GetBottomTwelveTiles()
        {
            return bottomTwelveTiles;
        }

        public Tile[] GetEightTeenTiles()
        {
            return eightTeenTiles;
        }

        public Tile[] GetEvenOddTiles()
        {
            return evenOddTiles;
        }

        public Tile[] GetRedBlackTiles()
        {
            return redBlackTiles;
        }

        private void NumbersBoardFiller()
        {
            int value = 1;
            for(int j = 0; j < 12; j++) 
            {
                for(int i = 2; i >= 0; i--)
                {
                    numbers[i,j] = new Number();
                    numbers[i, j].SetValue(value);
                    numbers[i, j].SetColor(GiveColor(value));
                    value++;
                }
            }
        }

        private Color GiveColor(int value)
        {
            Color color;
            if(value < 11 || (value > 18 && value < 29))
            {
                if (value % 2 == 0)
                {
                    color = Color.Black;
                }
                else
                {
                    color = Color.Red;
                }
            }
            else
            {
                if (value % 2 == 0)
                {
                    color = Color.Red;
                }
                else
                {
                    color = Color.Black;
                }
            }
            return color;
        }

        public void RightTwelveTileMaker()
        {
            TileInitializer(rightTwelveTiles, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    rightTwelveTiles[i].AddNumber(numbers[i, j]);
                }
            }
        }

        public void RunningOverAllNumbers()
        {
            int value = 1;
            TileInitializer(numberTiles, 36);
            TileInitializer(bottomTwelveTiles, 3);
            TileInitializer(eightTeenTiles, 2);
            TileInitializer(evenOddTiles, 2);
            TileInitializer(redBlackTiles, 2);
            for (int j = 0; j < 12; j++) 
            {
                for(int i = 2; i >= 0; i--)
                {
                    numberTiles[value - 1].AddNumber(numbers[i, j]);
                    BottomTwelveTileMaker(value, i, j);
                    EightTeenTileMaker(value, i, j);
                    EvenOddTileMaker(value, i, j);
                    RedBlackTileMaker(i, j);
                    value++;
                }
            }
        }

        public void BottomTwelveTileMaker(int value, int row, int column)
        {
            if (value < 13)
            {
                bottomTwelveTiles[0].AddNumber(numbers[row, column]);
            }
            else if (value > 24)
            {
                bottomTwelveTiles[2].AddNumber(numbers[row, column]);
            }
            else
            {
                bottomTwelveTiles[1].AddNumber(numbers[row, column]);
            }
        }

        public void EightTeenTileMaker(int value, int row, int column)
        {
            if (value < 19)
            {
                eightTeenTiles[0].AddNumber(numbers[row, column]);
            }
            else
            {
                eightTeenTiles[1].AddNumber(numbers[row, column]);
            }
        }

        public void EvenOddTileMaker(int value, int row, int column)
        {
            if (value % 2 == 0)
            {
                evenOddTiles[0].AddNumber(numbers[row, column]);
            }
            else
            {
                evenOddTiles[1].AddNumber(numbers[row, column]);
            }
        }

        public void RedBlackTileMaker(int row, int column)
        {
            if (new MyColor(numbers[row, column].GetColor()).ToString().Equals("Red"))
            {
                redBlackTiles[0].AddNumber(numbers[row, column]);
            }
            else 
            {
                redBlackTiles[1].AddNumber(numbers[row, column]);
            }
        }

        public void TileInitializer(Tile[] array, int multiplier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Tile(multiplier);
            }
        }
    }
}
