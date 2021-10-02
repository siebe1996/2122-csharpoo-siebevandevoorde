using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLogica
{
    public class Tile
    {
        private List<Number> numbers = new List<Number>();

        public Tile()
        {

        }
        public void AddNumber(Number number)
        {
            numbers.Add(number);
        }

        public Number GetNumber(int index)
        {
            return numbers[index];
        }

        public int Size()
        {
            return numbers.Count;
        }
    }
}
