using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals
{
    public static class ExtensionMethodes
    {

        public static string ColorString(this Color color)
        {
            string colorName = color.ToString().Substring(7);
            colorName = colorName.Substring(0, colorName.Length - 1);
            return colorName;
        }
    }
}
