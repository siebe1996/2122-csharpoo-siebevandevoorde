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
            this.color = color;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }
    }
}
