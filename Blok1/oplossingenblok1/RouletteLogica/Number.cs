using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RouletteLogica
{
    class Number
    {
        private Color color;
        private int value;
        
        public void SetColor(Color color)
        {
            if(color == Color.Black || color == Color.Red)
            {
                this.color = color;
            }
            else
            {
                throw new ArgumentException("A number color can only be red or black");
            }
        }

        public void SetValue(int value)
        {
            if (value < 1 || value > 36)
            {
                throw new ArgumentException("A number value can only be 1 -> 36");
            }
            else
            {
                this.value = value;
            }
        }
    }
}
