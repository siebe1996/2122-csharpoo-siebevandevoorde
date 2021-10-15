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
        public int Multiplier { get; }

        public Tile(int multiplier)
        {
            this.Multiplier = multiplier;
        }
        public void AddNumber(Number number)
        {
            numbers.Add(number);
        }

        public void AddNumberList(List<Number> numbers)
        {
            this.numbers = numbers;
        }

        public Number GetNumber(int index)
        {
            return numbers[index];
        }

        public int Size()
        {
            return numbers.Count;
        }

        public override string ToString()
        {
            string weergave = "{";
            foreach(Number number in numbers)
            {
                weergave += number + ",";
            }
            weergave += "} "+Multiplier;
            return weergave;
        }
    }
}
