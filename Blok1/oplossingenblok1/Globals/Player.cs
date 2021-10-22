﻿using System;
using System.Collections.Generic;

namespace Globals
{
    public class Player : IEquatable<Player>
    {
        public string name { get; }
        public int capital { get; private set; }
        public Dictionary<Tile, int> Bets { get; } = new Dictionary<Tile, int>();


        public Player() : this("dummy", 100)
        {

        }
        public Player(string name, int capital)
        {
            this.name = name;
            this.capital = capital;
        }

        public Player(Player player)
        {
            this.name = player.name;
            this.capital = player.capital;
        }

        public void PlaceBet(Tile tile, int bet)
        {
            if (bet <= capital)
            {
                Bets.Add(tile, bet);
                capital -= bet;
            }
            else
            {
                throw new ArgumentException($"Je inzet kan niet groter zijn dan je kapitaal, inzet: {bet}, kapitaal: {capital}");
            }
        }

        public void AddWinning(int winning)
        {
            capital += winning;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Player);
        }

        public bool Equals(Player other)
        {
            return other != null &&
                   name == other.name;
        }
    }
}
