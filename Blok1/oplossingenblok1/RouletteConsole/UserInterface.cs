using System;
using System.Collections.Generic;
using RouletteLogica;

namespace RouletteConsole
{

    class UserInterface
    {

        private readonly Board board;
        private Player player;

        public UserInterface()
        {
            board = new Board();
            player = new Player("dummy", 100);
        }

        public void Run()
        {
            DrawNumbers();
            DrawBottomTwelveTiles();
            DrawLastRow();
            StartQuestion();
        }

        private void DrawNumbers()
        {
            int[] dimLength = GetDimLength();
            string boarder = GiveBoarder(dimLength);
            boarder += "------|";
            string numberLine = "";
            //int extraTwelve = 0; //testcode
            for (int i = 0; i < dimLength[0]; i++)
            {
                Console.WriteLine(boarder);
                numberLine = GiveNumberline(dimLength, i);
                //numberLine = GiveNumberline(extraTwelve, i);//testcode
                Console.WriteLine(numberLine);
                // extraTwelve += 12;//testcode
            }
            Console.WriteLine(boarder);
        }

        private void DrawBottomTwelveTiles()
        {
            int[] dimLength = GetDimLength();
            Console.WriteLine(GiveBottomTwelveTiles());
            Console.WriteLine(GiveBoarder(dimLength));
        }

        private void DrawLastRow()
        {
            int[] dimLength = GetDimLength();
            Console.Write(GiveEightTeenTiles());
            Console.Write(GiveEvenOddTiles());
            Console.WriteLine(GiveRedBlackTiles());
            Console.WriteLine(GiveBoarder(dimLength));
        }

        private int[] GetDimLength()
        {
            int rank = board.GetNumbers().Rank;
            int[] dimLength = new int[rank];
            for (int i = 0; i < rank; i++)
            {
                dimLength[i] = board.GetNumbers().GetLength(i);
            }
            return dimLength;
        }

        private string GiveBoarder(int[] dimLength)
        {
            string boarder = "|";
            for (int j = 0; j < dimLength[1]; j++)
            {
                boarder += "---------|";
            }
            return boarder;
        }

        private string GiveNumberline(int[] dimLength, int lineNumber)
        {
            String numberLine = "|";
            Number[,] numbers = board.GetNumbers();
            for (int j = 0; j < dimLength[1]; j++)
            {
                if (numbers[lineNumber, j].GetValue() < 10)
                {
                    numberLine += string.Format("{0,0}/{1,-7}", numbers[lineNumber, j].GetValue().ToString(), new MyColor(numbers[lineNumber, j].GetColor()).ToString());
                }
                else
                {
                    numberLine += string.Format("{0,0}/{1,-6}", numbers[lineNumber, j].GetValue().ToString(), new MyColor(numbers[lineNumber, j].GetColor()).ToString());
                }
                numberLine += "|";
            }
            numberLine += GiveRightTwelveTiles(lineNumber);
            return numberLine;
        }

        //testcode
        /*fout bij tekenen
        private string GiveNumberline(int extraTwelve, int lineNumber)
        {
            String numberLine = "|";
            Tile[] numberTiles = board.GetNumberTiles();
            for (int j = 0 + extraTwelve; j < 12 + extraTwelve; j++)
            {
                if (numberTiles[j].GetNumber(0).GetValue() < 10)
                {
                    numberLine += string.Format("{0,0}/{1,-7}", numberTiles[j].GetNumber(0).GetValue().ToString(), new MyColor(numberTiles[j].GetNumber(0).GetColor()).ToString());
                }
                else
                {
                    numberLine += string.Format("{0,0}/{1,-6}", numberTiles[j].GetNumber(0).GetValue().ToString(), new MyColor(numberTiles[j].GetNumber(0).GetColor()).ToString());
                }
                numberLine += "|";
            }
            numberLine += GiveRightTwelveTiles(lineNumber);
            return numberLine;
        }*/


        private string GiveRightTwelveTiles(int lineNumber)
        {
            Tile[] rightTwelveTiles = board.GetRightTwelveTiles();
            string rightTwelveTile = "";
            rightTwelveTile = string.Format("{0,0}-{1,-4}", rightTwelveTiles[lineNumber].GetNumber(0).GetValue().ToString(), rightTwelveTiles[lineNumber].GetNumber(rightTwelveTiles[lineNumber].Size() - 1).GetValue().ToString());
            rightTwelveTile += "|";
            return rightTwelveTile;

        }

        private string GiveBottomTwelveTiles()
        {
            Tile[] bottomTwelveTiles = board.GetBottomTwelveTiles();
            string bottomTwelveTile = "|";
            for (int i = 0; i < bottomTwelveTiles.Length; i++)
            {
                bottomTwelveTile += string.Format("{0,19}-{1,-19}", bottomTwelveTiles[i].GetNumber(0).GetValue().ToString(), bottomTwelveTiles[i].GetNumber(bottomTwelveTiles[i].Size() - 1).GetValue().ToString());
                bottomTwelveTile += "|";
            }
            return bottomTwelveTile;
        }

        private string GiveEightTeenTiles()
        {
            Tile[] eightTeenTiles = board.GetEightTeenTiles();
            string eightTeenTile = "|";
            for (int i = 0; i < eightTeenTiles.Length; i++)
            {
                eightTeenTile += string.Format("{0,9}-{1,-9}", eightTeenTiles[i].GetNumber(0).GetValue().ToString(), eightTeenTiles[i].GetNumber(eightTeenTiles[i].Size() - 1).GetValue().ToString());
                eightTeenTile += "|";
            }
            return eightTeenTile;
        }

        private string GiveEvenOddTiles()
        {
            Tile[] evenOddTiles = board.GetEvenOddTiles();
            string[] words = { "even", "odd", "" };
            string evenOddTile = "";
            //string numberSeq =  "";
            for (int i = 0; i < evenOddTiles.Length; i++)
            {
                evenOddTile += string.Format("{0,11}{1,-8}", words[i], words[2]);
                evenOddTile += "|";
                /*for(int j = 0; j < evenOddTiles[i].Size(); j++)
                {
                    numberSeq += evenOddTiles[i].GetNumber(j).GetValue().ToString() + ",";
                }
                Console.WriteLine(numberSeq);
                numberSeq = "";*/
            }
            return evenOddTile;
        }

        private string GiveRedBlackTiles()
        {
            Tile[] redBlackTiles = board.GetRedBlackTiles();
            string[] words = { "Red", "Black", "" };
            string redBlackTile = "";
            //string numberSeq =  "";
            for (int i = 0; i < redBlackTiles.Length; i++)
            {
                redBlackTile += string.Format("{0,11}{1,-8}", words[i], words[2]);
                redBlackTile += "|";
                /*for(int j = 0; j < redBlackTiles[i].Size(); j++)
                {
                    numberSeq += new MyColor(redBlackTiles[i].GetNumber(j).GetColor()).ToString() + ",";
                }
                Console.WriteLine(numberSeq);
                numberSeq = "";*/
            }
            return redBlackTile;
        }

        private void StartQuestion()
        {
            Console.WriteLine("Wil je op een nummer of een speciale tegel inzetten?");
            Console.WriteLine("type 1 voor nummer en 2 voor speciale tegel.");
            ReadInputStart();
        }

        private void ReadInputStart()
        {
            string input1 = string.Empty;
            input1 = Console.ReadLine();
            if (input1.Equals("1"))
            {
                NumberQuestion();
            }
            else if (input1.Equals("2"))
            {
                TileQuestion();
            }
            else
            {
                Console.WriteLine("geef 1 of 2 in.");
                StartQuestion();
            }
        }

        private void NumberQuestion()
        {
            Console.WriteLine("Type op welk nummer je wilt inzetten (1->36)");
            ReadNumber();

        }

        private void TileQuestion()
        {
            Console.WriteLine("Op welk soort tegel wil je inzetten?");
            Console.WriteLine("Type 1 voor rechter 12 tegels, type 2 voor onder 12 tegels, type 3 voor 18 tegels, type 4 voor even/oneven tegels, type 5 voor rood/zwart");
            ReadTile();
        }

        private void ReadTile()
        {
            int input2 = int.MaxValue;
            try
            {
                input2 = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Geef een nummer in");
                TileQuestion();
            }
            if (input2 < 1|| input2 > 5)
            {
                Console.WriteLine("Geef een nummer tussen 1->5 in");
                TileQuestion();
            }
             switch (input2)
            {
                case 1:
                    RightTwelveTileQuestion();
                    break;
                case 2:
                    BottomTwelveTileQuestion();
                    break;
                case 3:
                    EightTeenTileQuestion();
                    break;
                case 4:
                    EvenOddTileQuestion();
                    break;
                case 5:
                    //functioon
                    break;
            }
        }

        private void RightTwelveTileQuestion()
        {
            Console.WriteLine("type 1 voor de nummers tussen 3->36, 2 voor de nummers tussen 2->35, 3 voor de nummers tussen 1->34");
            ReadRightTwelveTile();
        }
        
        private void BottomTwelveTileQuestion()
        {
            Console.WriteLine("type 1 voor de nummers tussen 1->12, 2 voor de nummers tussen 13->24, 3 voor de nummers tussen 1->36");
            ReadBottomTwelveTile();
        }

        private void EightTeenTileQuestion()
        {
            Console.WriteLine("type 1 voor de nummers tussen 1->18, 2 voor de nummers tussen 19->36");
            ReadEightTeenTile();
        }

        private void EvenOddTileQuestion()
        {
            Console.WriteLine("type 1 voor even nummers, 2 voor oneven nummers");
            ReadEvenOddTile();
        }

        private void ReadNumber()
        {
            int input2 = int.MaxValue;
            try{
                input2 = Convert.ToInt32(Console.ReadLine());
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine("Geef een nummer in");
                NumberQuestion();
            }
            if (input2 > 0 && input2 < 37)
            {
                Tile[] numberTiles = board.GetNumberTiles();
                BetQuestion(numberTiles[input2 - 1]);
            }
            else
            {
                Console.WriteLine("Geef een geldig nummer in");
                NumberQuestion();
            }
        }

        private void ReadRightTwelveTile()
        {
            int input3 = int.MaxValue;
            try
            {
                input3 = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Geef een nummer in");
                RightTwelveTileQuestion();
            }
            if (input3 > 0 && input3 < 4)
            {
                Tile[] RightTwelveTiles = board.GetRightTwelveTiles();
                Console.WriteLine(RightTwelveTiles[input3 - 1]);
                BetQuestion(RightTwelveTiles[input3 - 1]);
            }
            else
            {
                Console.WriteLine("Geef een geldig nummer in");
                RightTwelveTileQuestion();
            }
        }

        private void ReadBottomTwelveTile()
        {
            int input3 = int.MaxValue;
            try
            {
                input3 = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Geef een nummer in");
                BottomTwelveTileQuestion();
            }
            if (input3 > 0 && input3 < 4)
            {
                Tile[] BottomTwelveTiles = board.GetBottomTwelveTiles();
                Console.WriteLine(BottomTwelveTiles[input3 - 1]);
                BetQuestion(BottomTwelveTiles[input3 - 1]);
            }
            else
            {
                Console.WriteLine("Geef een geldig nummer in");
                BottomTwelveTileQuestion();
            }
        }

        private void ReadEightTeenTile()
        {
            int input3 = int.MaxValue;
            try
            {
                input3 = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Geef een nummer in");
                EightTeenTileQuestion();
            }
            if (input3 > 0 && input3 < 3)
            {
                Tile[] EightTeenTiles = board.GetEightTeenTiles();
                Console.WriteLine(EightTeenTiles[input3 - 1]);
                BetQuestion(EightTeenTiles[input3 - 1]);
            }
            else
            {
                Console.WriteLine("Geef een geldig nummer in");
                EightTeenTileQuestion();
            }
        }

        private void ReadEvenOddTile()
        {
            int input3 = int.MaxValue;
            try
            {
                input3 = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Geef een nummer in");
                EvenOddTileQuestion();
            }
            if (input3 > 0 && input3 < 3)
            {
                Tile[] evenOddTiles = board.GetEvenOddTiles();
                Console.WriteLine(evenOddTiles[input3 - 1]); //testcode
                BetQuestion(evenOddTiles[input3 - 1]);
            }
            else
            {
                Console.WriteLine("Geef een geldig nummer in");
                EvenOddTileQuestion();
            }
        }

        private void BetQuestion(Tile tile)
        {
            //krijgt een tile en vraagt om een input van een inzet
            Console.WriteLine("hoeveel wil je inzetten?");
            ReadBet(tile);
        }

        private void ReadBet(Tile tile)
        {
            int input4 = int.MaxValue;
            try
            {
                input4 = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Geef een inzet in");
                BetQuestion(tile);
            }
            try
            {
                player.PlaceBet(tile, input4);
                CheckWin();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e);
                BetQuestion(tile);
            }
        }

        private int Roll()
        {
            return RouletteWheel.Turn();
        }

        private void CheckWin()
        {
            //int outcome = Roll();
            int outcome = 15;
            Console.WriteLine(outcome + " is gerolt");
            board.WinningTileMaker(outcome);
            foreach(Tile winningTile in board.GetWinningTiles())
            {
                if (player.GetBets().ContainsKey(winningTile))
                {
                    player.AddWinning(player.GetBets()[winningTile] * winningTile.GetMultiplier());
                    PrintWiningAndPlayerInfo(winningTile);
                }
            }
            player.GetBets().Clear();
            PlayAgainQuestion();
        }

        private void PrintWiningAndPlayerInfo(Tile winningTile)
        {
            Console.WriteLine("je hebt " + player.GetBets()[winningTile] + " ingezet op " + winningTile+", je hebt "+(player.GetBets()[winningTile] * winningTile.GetMultiplier())+" gewonnen");
        }

        private void PlayAgainQuestion()
        {
            Console.WriteLine("Wil je nog eens Spelen? [y/n]");
            PlayAgainRead();
        }

        private void PlayAgainRead()
        {
            string input4 = Console.ReadLine();
            if (input4.Equals("y"))
            {
                StartQuestion();
            }
            else if (input4.Equals("n"))
            {
                Environment.Exit(0);
            }
            else
            {
                PlayAgainQuestion();
            }
        }
    }
}
