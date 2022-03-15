using System;

namespace ClassLibraryBatleShip
{
    public class Game
    {
        private static readonly int sleepTimeAfterTurn = 100;
        private readonly Display displayer;
        private readonly Player playerOne;
        private readonly Player playerTwo;

        public Game(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            displayer = new Display();
        }

        public void StartGame()
        {
            bool playerOneMove = true;
            bool playerTwoMove;
            while (true)
            {
                while (playerOneMove)
                {
                    playerOne.MakeMove();
                    playerOneMove = playerOne.LastMoveHit;
                    displayer.Boards(playerOne, playerTwo, "lewo", sleepTimeAfterTurn);
                    if (Inspector.DidAllShipDown(playerOne.PlayerBoard))
                    {
                        Console.WriteLine("Wygrana po lewo, czyli gracza drugiego");
                        return;
                    }
                }
                playerTwoMove = true;
                while (playerTwoMove)
                {
                    playerTwo.MakeMove();
                    playerTwoMove = playerTwo.LastMoveHit;
                    displayer.Boards(playerOne, playerTwo, "prawo", sleepTimeAfterTurn);
                    if (Inspector.DidAllShipDown(playerTwo.PlayerBoard))
                    {
                        Console.WriteLine("Wygrana po prawo, czyli gracz pierwszy");
                        return;
                    }
                }
                playerOneMove = true;
            }
        }
    }
}
