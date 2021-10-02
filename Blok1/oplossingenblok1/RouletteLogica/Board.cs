using System;
using System.Drawing;
using System.Collections.Generic;

namespace RouletteLogica
{
    public class Board
    {
        private Number[,] numbers = new Number[3, 12];
        private Tile[] rightTwelveTiles = new Tile[3];

        public Board()
        {
            NumbersBoardFiller();
            RightTwelveTileMaker();
        }

        public Number[,] GetNumbers()
        {
            return numbers;
        }

        public Tile[] GetRightTwelveTiles()
        {
            return rightTwelveTiles;
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
            for (int i = 0; i < 3; i++)
            {
                rightTwelveTiles[i] = new Tile();
                for (int j = 0; j < 12; j++)
                {
                    rightTwelveTiles[i].AddNumber(numbers[i, j]);
                    //Console.WriteLine(rightTwelveTiles[i].GetNumber(j).GetValue());
                }
            }
        }
    }
}
