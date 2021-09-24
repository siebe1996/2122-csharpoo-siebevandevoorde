using System;
using System.Drawing;

namespace RouletteLogica
{
    public class Board
    {
        private Number[,] numbers = new Number[3, 12];

        private void NumbersBoardFiller()
        {
            int value = 1;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    numbers[i, j].SetValue(value);
                    numbers[i, j].SetColor(GiveColor(value));
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
    }
}
