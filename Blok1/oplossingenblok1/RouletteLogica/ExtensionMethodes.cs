using System.Drawing;

namespace RouletteLogica
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
