using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLogica
{
    public class MyColor
    {
        private Color color;

        public MyColor(Color color)
        {
            this.color = color;
        }

        public override string ToString()
        {
            string colorName = color.ToString().Substring(7);
            colorName = colorName.Substring(0, colorName.Length - 1);
            return colorName;
        }

    }
}
