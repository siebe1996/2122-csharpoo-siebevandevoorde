using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace Globals
{
    public class Player : IEquatable<Player>
    {
        public string Name { get; set; }
        public int Capital { get; set; }

        [JsonIgnore]
        public Dictionary<Tile, int> Bets { get; } = new Dictionary<Tile, int>();


        public Player()// : this("dummy")
        {

        }

        public Player(string name) : this(name, 100)
        {

        }
        public Player(string name, int capital)
        {
            this.Name = name;
            this.Capital = capital;
        }

        public Player(string name, int capital, Dictionary<string, int> trowAway)
        {
            this.Name = name;
            this.Capital = capital;
        }

        public Player(Player player)
        {
            this.Name = player.Name;
            this.Capital = player.Capital;
        }

        public void PlaceBet(Tile tile, int bet)
        {
            if (bet <= Capital)
            {
                Bets.Add(tile, bet);
                Capital -= bet;
            }
            else
            {
                throw new ArgumentException($"Je inzet kan niet groter zijn dan je kapitaal, inzet: {bet}, kapitaal: {Capital}");
            }
        }

        public void AddWinning(int winning)
        {
            Capital += winning;
        }


        public bool Equals(Player other)
        {
            return other != null &&
                   Name == other.Name;
        }

        public override bool Equals(object obj) => Equals(obj as Player);
        public override int GetHashCode() => (Name).GetHashCode();


        public override string ToString()
        {
            return Name ;
        }


    }
}
