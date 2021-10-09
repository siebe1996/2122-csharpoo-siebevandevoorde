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
        private int multiplier;

        public Tile(int multiplier)
        {
            this.multiplier = multiplier;
        }
        public void AddNumber(Number number)
        {
            numbers.Add(number);
        }

        public Number GetNumber(int index)
        {
            return numbers[index];
        }

        public int GetMultiplier()
        {
            return multiplier;
        }

        public int Size()
        {
            return numbers.Count;
        }

        public void GetTilesWithNumber(int number)
        {
            //rteurn alle tiles die er een tile is met dit nummer return deze tile
            //if () { }
        }

        public override string ToString()
        {
            string weergave = "{";
            foreach(Number number in numbers)
            {
                weergave += number + ",";
            }
            weergave += "} "+multiplier;
            return weergave;
        }
    }
}
