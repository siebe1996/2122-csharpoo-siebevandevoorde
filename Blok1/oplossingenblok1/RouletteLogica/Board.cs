using System;
using System.Drawing;

namespace RouletteLogica
{
    public class Board
    {
        private Number[,] numbers = new Number[3, 12];
        private Number[,] rightTwelveTiles = new Number[3, 12];
        private Number[,] bottomTwelveTiles = new Number[3, 12];

        public Board()
        {
            NumbersBoardFiller();
            RightTwelveTileMaker();
        }

        public Number[,] GetNumbers()
        {
            return numbers;
        }

        public Number[,] GetRightTwelveTiles()
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
            rightTwelveTiles = numbers;
        }

        public void BottomTwelveTileMaker()
        {

        }
    }
}
