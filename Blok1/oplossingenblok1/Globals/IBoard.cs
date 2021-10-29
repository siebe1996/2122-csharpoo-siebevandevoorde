using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals
{
    public interface IBoard
    {
        Tile[] BottomTwelveTiles { get; }
        Tile[] EightTeenTiles { get; }
        Tile[] EvenOddTiles { get; }
        Number[,] Numbers { get; }
        Tile[] NumberTiles { get; }
        List<Player> Players { get; }
        Tile[] RedBlackTiles { get; }
        Tile[] RightTwelveTiles { get; }
        List<Tile> WinningTiles { get; }

        void CheckIfPlayerExists(string name);
        Tile CheckWin();
        void WinningTileMaker(int value);
    }
}
