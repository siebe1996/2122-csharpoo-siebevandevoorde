﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Globals;
using RouletteData;

namespace RouletteLogica
{
    public class Board : IBoard
    {
        public Number[,] Numbers { get; } = new Number[3, 12];
        public Tile[] NumberTiles { get; } = new Tile[36];
        public Tile[] RightTwelveTiles { get; } = new Tile[3];
        public Tile[] BottomTwelveTiles { get; } = new Tile[3];
        public Tile[] EightTeenTiles { get; } = new Tile[2];
        public Tile[] EvenOddTiles { get; } = new Tile[2];
        public Tile[] RedBlackTiles { get; } = new Tile[2];
        private List<Tile> winningTiles = new List<Tile>();
        public List<Player> Players { get; } = new List<Player>();
        private IData data;

        public Board(IData data)
        {
            NumbersBoardFiller();
            RunningOverAllNumbers();
            this.data = data;
        }

        private void NumbersBoardFiller()
        {
            int value = 1;
            for (int j = 0; j < 12; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    Numbers[i, j] = new Number();
                    Numbers[i, j].Value = value;
                    Numbers[i, j].Color = GiveColor(value);
                    value++;
                }
            }
        }

        private Color GiveColor(int value)
        {
            Color color;
            if (value < 11 || (value > 18 && value < 29))
            {
                if (value % 2 == 0)
                {
                    color = Color.Black;
                }
                else
                {
                    color = Color.Red;
                }
            }
            else
            {
                if (value % 2 == 0)
                {
                    color = Color.Red;
                }
                else
                {
                    color = Color.Black;
                }
            }
            return color;
        }

        private void RunningOverAllNumbers()
        {
            int value = 1;
            AllTileInitializer();
            for (int j = 0; j < 12; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    NumberTiles[value - 1].AddNumber(Numbers[i, j]);
                    //Console.Write(value + ", ");
                    value++;
                }
            }
            Task job1 = Task.Run(() => { RightTwelveTileMaker(); });
            Task job2 = Task.Run(() => { BottomTwelveTileMaker(); });
            Task job3 = Task.Run(() => { EightTeenTileMaker(); });
            Task job4 = Task.Run(() => { RedBlackTileMaker(); });
            Task job5 = Task.Run(() => { EvenOddTileMaker(); });
            Task.WaitAll(new Task[] { job1, job2, job3, job4, job5 });
            /*RightTwelveTileMaker();
            BottomTwelveTileMaker();
            EightTeenTileMaker();
            RedBlackTileMaker();
            EvenOddTileMaker();
            */
            /*Console.WriteLine();
            foreach (Tile tile in eightTeenTiles)
            {
                Console.WriteLine(tile);
            }*/
        }

        private void AllTileInitializer()
        {
            Task job1 = Task.Run(() => { TileInitializer(NumberTiles, 36); });
            Task job2 = Task.Run(() => { TileInitializer(BottomTwelveTiles, 3); });
            Task job3 = Task.Run(() => { TileInitializer(EightTeenTiles, 2); });
            Task job4 = Task.Run(() => { TileInitializer(EvenOddTiles, 2); });
            Task job5 = Task.Run(() => { TileInitializer(RedBlackTiles, 2); });
            Task job6 = Task.Run(() => { TileInitializer(RightTwelveTiles, 3); });
            Task.WaitAll(new Task[] { job1, job2, job3, job4, job5, job6 });
            /*TileInitializer(BottomTwelveTiles, 3);
            TileInitializer(EightTeenTiles, 2);
            TileInitializer(EvenOddTiles, 2);
            TileInitializer(RedBlackTiles, 2);
            TileInitializer(RightTwelveTiles, 3);*/
        }

        private void RightTwelveTileMaker()
        {
            RightTwelveTiles[0].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value % 3 == 0).Select(n => n.GetNumber(0))).ToList());
            RightTwelveTiles[1].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value % 3 == 2).Select(n => n.GetNumber(0))).ToList());
            RightTwelveTiles[2].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value % 3 == 1).Select(n => n.GetNumber(0))).ToList());
        }

        private void BottomTwelveTileMaker()
        {
            BottomTwelveTiles[0].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value < 13).Select(n => n.GetNumber(0))).ToList());
            BottomTwelveTiles[2].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value > 24).Select(n => n.GetNumber(0))).ToList());
            BottomTwelveTiles[1].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value >= 13 && n.GetNumber(0).Value <= 24).Select(n => n.GetNumber(0))).ToList());
        }

        private void EightTeenTileMaker()
        {
            EightTeenTiles[0].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value < 19).Select(n => n.GetNumber(0))).ToList());
            EightTeenTiles[1].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value >= 19).Select(n => n.GetNumber(0))).ToList());
        }

        private void EvenOddTileMaker()
        {
            EvenOddTiles[0].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value % 2 == 0).Select(n => n.GetNumber(0))).ToList());
            EvenOddTiles[1].AddNumberList((NumberTiles.Where(n => n.GetNumber(0).Value % 2 == 1).Select(n => n.GetNumber(0))).ToList());
        }

        private void RedBlackTileMaker()
        {

            RedBlackTiles[0].AddNumberList(NumberTiles.Where(n => n.GetNumber(0).Color.ColorString().Equals("Red")).Select(n => n.GetNumber(0)).ToList());
            RedBlackTiles[1].AddNumberList(NumberTiles.Where(n => n.GetNumber(0).Color.ColorString().Equals("Black")).Select(n => n.GetNumber(0)).ToList());

            /*
            RedBlackTiles[0].AddNumberList((from numberTile in NumberTiles
                                where new MyColor(numberTile.GetNumber(0).Color).ToString().Equals("Red")
                                select numberTile.GetNumber(0)).ToList());

            RedBlackTiles[1].AddNumberList((from numberTile in NumberTiles
                                            where new MyColor(numberTile.GetNumber(0).Color).ToString().Equals("Black")
                                            select numberTile.GetNumber(0)).ToList());
            */
        }

        public void CheckIfPlayerExists(string name)
        {

            List<Player> allPlayers = data.GetPlayers();
            bool playerPresent = false;
            foreach (Player player in allPlayers)
            {
                if (player.Name.Equals(name))
                {
                    playerPresent = true;
                    Players.Add(player);
                }
                /*if (player.Equals(newPlayer))
                {
                    playerPresent = true;
                    Players.Add(player);
                }*/
            }
            if (!playerPresent)
            {
                Players.Add(new Player(name));
            }
        }

        public void WinningTileMaker(int value)
        {
            if (GiveWinningTile(value, NumberTiles) != null)
            {
                winningTiles.Add(GiveWinningTile(value, NumberTiles));
            }
            if (GiveWinningTile(value, RightTwelveTiles) != null)
            {
                winningTiles.Add(GiveWinningTile(value, RightTwelveTiles));
            }
            if (GiveWinningTile(value, BottomTwelveTiles) != null)
            {
                winningTiles.Add(GiveWinningTile(value, BottomTwelveTiles));
            }
            if (GiveWinningTile(value, EightTeenTiles) != null)
            {
                winningTiles.Add(GiveWinningTile(value, EightTeenTiles));
            }
            if (GiveWinningTile(value, EvenOddTiles) != null)
            {
                winningTiles.Add(GiveWinningTile(value, EvenOddTiles));
            }
            if (GiveWinningTile(value, RedBlackTiles) != null)
            {
                winningTiles.Add(GiveWinningTile(value, RedBlackTiles));
            }
        }

        private Tile GiveWinningTile(int value, Tile[] tileArray)
        {
            foreach (Tile tile in tileArray)
            {
                for (int i = 0; i < tile.Size(); i++)
                {
                    if (tile.GetNumber(i).Value == value)
                    {
                        return tile;
                    }
                }
            }
            return null;
        }

        private void TileInitializer(Tile[] array, int multiplier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Tile(multiplier);
            }
        }

        public Tile CheckWin()
        {
            //int outcome = Roll();
            int outcome = 15;
            Console.WriteLine(outcome + " is gerolt");
            WinningTileMaker(outcome);
            Tile winnningTileHolder = new Tile();
            /*foreach (Tile winningTile in WinningTiles)
            {
                if (Player.Bets.ContainsKey(winningTile))
                {
                    Player.AddWinning(Player.Bets[winningTile] * winningTile.Multiplier);
                    winnningTileHolder = winningTile;
                }
            }*/
            Parallel.ForEach(winningTiles, (Tile winningTile) =>
            {
                foreach (Player player in Players)
                {
                    if (player.Bets.ContainsKey(winningTile))
                    {
                        player.AddWinning(player.Bets[winningTile] * winningTile.Multiplier);
                        winnningTileHolder = winningTile;
                    }
                }
            });
            data.JSONSerializerAndWriter(Players);
            winningTiles.Clear();
            return winnningTileHolder;
        }
    }
}
