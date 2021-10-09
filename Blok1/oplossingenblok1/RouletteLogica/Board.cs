using System;
using System.Drawing;
using System.Collections.Generic;

namespace RouletteLogica
{
    public class Board
    {
        public Number[,] Numbers { get; } = new Number[3, 12];
        public Tile[] NumberTiles { get; } = new Tile[36];
        public Tile[] RightTwelveTiles { get; } = new Tile[3];
        public Tile[] BottomTwelveTiles { get; } = new Tile[3];
        public Tile[] EightTeenTiles { get; } = new Tile[2];
        public Tile[] EvenOddTiles { get; } = new Tile[2];
        public Tile[] RedBlackTiles { get; } = new Tile[2];
        public List<Tile> WinningTiles { get; } = new List<Tile>();

        public Board()
        {
            NumbersBoardFiller();
            RightTwelveTileMaker();
            RunningOverAllNumbers();
        }

        private void NumbersBoardFiller()
        {
            int value = 1;
            for(int j = 0; j < 12; j++) 
            {
                for(int i = 2; i >= 0; i--)
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
            if(value < 11 || (value > 18 && value < 29))
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

        private void RightTwelveTileMaker()
        {
            TileInitializer(RightTwelveTiles, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    RightTwelveTiles[i].AddNumber(Numbers[i, j]);
                    //Console.Write(Numbers[i, j] + ", "); //testcode
                }
                //Console.WriteLine(); //testcode
            }
        }

        private void RunningOverAllNumbers()
        {
            int value = 1;
            TileInitializer(NumberTiles, 36);
            TileInitializer(BottomTwelveTiles, 3);
            TileInitializer(EightTeenTiles, 2);
            TileInitializer(EvenOddTiles, 2);
            TileInitializer(RedBlackTiles, 2);
            for (int j = 0; j < 12; j++) 
            {
                for(int i = 2; i >= 0; i--)
                {
                    NumberTiles[value - 1].AddNumber(Numbers[i, j]);
                    //Console.Write(value + ", ");
                    BottomTwelveTileMaker(value, i, j);
                    EightTeenTileMaker(value, i, j);
                    EvenOddTileMaker(value, i, j);
                    RedBlackTileMaker(i, j);
                    value++;
                }
            }
            /*Console.WriteLine();
            foreach (Tile tile in eightTeenTiles)
            {
                Console.WriteLine(tile);
            }*/
        }

        private void BottomTwelveTileMaker(int value, int row, int column)
        {
            if (value < 13)
            {
                BottomTwelveTiles[0].AddNumber(Numbers[row, column]);
            }
            else if (value > 24)
            {
                BottomTwelveTiles[2].AddNumber(Numbers[row, column]);
            }
            else
            {
                BottomTwelveTiles[1].AddNumber(Numbers[row, column]);
            }
        }

        private void EightTeenTileMaker(int value, int row, int column)
        {
            if (value < 19)
            {
                EightTeenTiles[0].AddNumber(Numbers[row, column]);
            }
            else
            {
                EightTeenTiles[1].AddNumber(Numbers[row, column]);
            }
        }

        private void EvenOddTileMaker(int value, int row, int column)
        {
            if (value % 2 == 0)
            {
                EvenOddTiles[0].AddNumber(Numbers[row, column]);
            }
            else
            {
                EvenOddTiles[1].AddNumber(Numbers[row, column]);
            }
        }

        private void RedBlackTileMaker(int row, int column)
        {
            if (new MyColor(Numbers[row, column].Color).ToString().Equals("Red"))
            {
                RedBlackTiles[0].AddNumber(Numbers[row, column]);
            }
            else
            {
                RedBlackTiles[1].AddNumber(Numbers[row, column]);
            }
        }

        public void WinningTileMaker(int value)
        {
            if(GiveWinningTile(value, NumberTiles) != null)
            {
                WinningTiles.Add(GiveWinningTile(value, NumberTiles));
            }
            if (GiveWinningTile(value, RightTwelveTiles) != null)
            {
                WinningTiles.Add(GiveWinningTile(value, RightTwelveTiles));
            }
            if (GiveWinningTile(value, BottomTwelveTiles) != null)
            {
                WinningTiles.Add(GiveWinningTile(value, BottomTwelveTiles));
            }
            if (GiveWinningTile(value, EightTeenTiles) != null)
            {
                WinningTiles.Add(GiveWinningTile(value, EightTeenTiles));
            }
            if (GiveWinningTile(value, EvenOddTiles) != null)
            {
                WinningTiles.Add(GiveWinningTile(value, EvenOddTiles));
            }
            if (GiveWinningTile(value, RedBlackTiles) != null)
            {
                WinningTiles.Add(GiveWinningTile(value, RedBlackTiles));
            }

            /*foreach(Tile numberTile in numberTiles)
            {
                if(numberTile.GetNumber(0).GetValue() == value)
                {
                    winningTiles.Add(numberTile);
                }
            }
            foreach(Tile rightTwelveTile in rightTwelveTiles)
            {
                for (int i = 0; i < rightTwelveTile.Size(); i++)
                {
                    if (rightTwelveTile.GetNumber(i).GetValue() == value)
                    {
                        winningTiles.Add(rightTwelveTile);
                        //als dit gebeurt is mag de foreach stoppen
                    }
                }
            }*/
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
    }
}
