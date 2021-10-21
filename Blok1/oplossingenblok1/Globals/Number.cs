using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals
{
    public class Number
    {
        private Color color;
        private int value;

        public Number()
        {
            this.color = Color.Blue;
            this.value = -1;
        }

        public Color Color
        {
            get => color;
            set => this.color = value;
        }

        public int Value
        {
            get => value;
            set
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

        public override string ToString()
        {
            return value + "/" + color.ColorString();
        }
    }
}
