using System.Collections.Generic;

namespace RouletteLogica
{
    public class Player
    {
        private string name;
        private int capital;
        private Dictionary <Tile, int> bets = new Dictionary <Tile, int>();


        public Player() : this("dummy", 100)
        {

        }
        public Player(string name, int capital)
        {
            this.name = name;
            this.capital = capital;
        }

        private void PlaceBet(Tile tile, int bet)
        {
            bets.Add(tile, bet);
            capital -= bet;
        }
    }
}
