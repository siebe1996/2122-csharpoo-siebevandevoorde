using System;
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

        public void PlaceBet(Tile tile, int bet)
        {
            if (bet <= capital)
            {
                bets.Add(tile, bet);
                capital -= bet;
            }
            else
            {
                throw new ArgumentException("Je inzet kan niet groter zijn dan je kapitaal, inzet: "+bet+", kapitaal: "+capital);
            }
        }

        public Dictionary<Tile, int> GetBets()
        {
            return bets;
        }

        public void AddWinning(int winning)
        {
            capital += winning;
        }
    }
}
