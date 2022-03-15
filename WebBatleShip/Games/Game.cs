using ClassLibraryBatleShip;
using WebBatleShip.Models;

namespace WebBatleShip.Games
{
    public class Game : IGame
    {
        public BoardMaker boardMaker { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        //public bool playerOneMove { get; set; }
        //public bool playerTwoMove { get; set; }
        public WhoWin whichPlayerTurns { get; set; }

        public Game()
        {
            whichPlayerTurns = WhoWin.WhaitingForScore;
            boardMaker = new BoardMaker();
            player1 = new ComputerPlayer(boardMaker);
            player2 = new ComputerPlayer(boardMaker);
        }

        public void PlayerOneMove()
        {
            player1.MakeMove();
            whichPlayerTurns = player1.LastMoveHit ? WhoWin.Player1 : WhoWin.Player2;
            if (Inspector.DidAllShipDown(player1.PlayerBoard))
            {
                whichPlayerTurns = WhoWin.PlayerOneWin;
            }
        }
        public void PlayerTwoMove()
        {
            player2.MakeMove();
            whichPlayerTurns = player2.LastMoveHit ? WhoWin.Player2 : WhoWin.Player1;
            if (Inspector.DidAllShipDown(player2.PlayerBoard))
            {
                whichPlayerTurns = WhoWin.PlayerTwoWin;
            }
        }
        public void HumanMove(int vertical, int horizontal)
        {
            player2.MakeMove(horizontal, vertical);
            whichPlayerTurns = player2.LastMoveHit ? WhoWin.Player2 : WhoWin.Player1;
            if (Inspector.DidAllShipDown(player2.PlayerBoard))
            {
                whichPlayerTurns = WhoWin.PlayerTwoWin;
            }
        }
    }

}
