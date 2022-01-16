using ConsoleAppStatki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleAppStatki
{
    class Game
    {
        private static readonly int maxVertical = 10;
        private static readonly int maxHorizontal = 10;
        private static readonly int sleepTimeAfterTurn = 500; 

        private readonly Displayer displayer;
        private readonly BoardMaker boardGenerator;
        private readonly ShipGenerator shipGenerator;
        private readonly StatusMaker statusMaker;

        private Field randomBlueShip;
        private Field randomRedShip;

        private List<Field> redBoard;
        private List<Ship> redShipList;
        private List<Field> blueBoard;
        private List<Ship> blueaShipList;
        public Game()
        {
            displayer = new Displayer();
            boardGenerator = new BoardMaker(maxVertical, maxHorizontal);
            shipGenerator = new ShipGenerator(maxVertical,maxHorizontal);
            statusMaker = new StatusMaker();

            redBoard = new List<Field>();
            blueBoard = new List<Field>();
        }

        public void StartGame()
        {
            redShipList = shipGenerator.RandomAllShipOnField();
            boardGenerator.CreateField(redBoard, redShipList);
            displayer.PaintConsole(redBoard);

            blueaShipList = shipGenerator.RandomAllShipOnField();
            boardGenerator.CreateField(blueBoard, blueaShipList);
            displayer.PaintConsole(blueBoard, 2);

            while (true)
            {
                //displayer.TakeDataFromHumanPlayer(redBoard);
                #region firstPlayerTurn
                randomBlueShip = boardGenerator.DrawField(redBoard);
                statusMaker.ChangeFieldStatus(redBoard, redShipList, randomBlueShip);

                if (AllShipDown(redBoard))
                {
                    Console.WriteLine("Wygrana Niebieskiego");
                    break;
                }
                #endregion firstPlayerTurn
                
                Thread.Sleep(sleepTimeAfterTurn);

                #region secondPlayerTurn

                randomRedShip = boardGenerator.DrawField(blueBoard);
                statusMaker.ChangeFieldStatus(blueBoard, blueaShipList, randomRedShip);

                if (AllShipDown(blueBoard))
                {
                    Console.WriteLine("Wygrana czerownego");
                    break;
                }
                #endregion secondPlayerTurn
                Console.Clear();

                displayer.PaintConsole(redBoard);
                displayer.PaintConsole(blueBoard, 2);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Check if All ship on board are down, to finish game
        /// </summary>
        /// <param name="board">Player board</param>
        /// <returns></returns>
        private bool AllShipDown(List<Field> board)
        {
            return board.FirstOrDefault(z => z.FieldStatus == FieldStatusEnum.Ship) == null;
        }
    }
}
