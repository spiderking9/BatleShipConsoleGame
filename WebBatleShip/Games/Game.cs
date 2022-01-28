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
        public WhoWin whoWin { get; set; }

        public Game()
        {
            whoWin = WhoWin.WhaitingForScore;
            boardMaker = new BoardMaker();
            player1 = new ComputerPlayer(boardMaker);
            player2 = new ComputerPlayer(boardMaker);
        }

        public void PlayerOneMove()
        {
            player1.MakeMove();
            whoWin = player1.LastMoveHit ? WhoWin.Player1 : WhoWin.Player2;
            if (Inspector.DidAllShipDown(player1.PlayerBoard))
            {
                whoWin = WhoWin.PlayerOneWin;
            }
        }
        public void PlayerTwoMove()
        {
            player2.MakeMove();
            whoWin = player2.LastMoveHit ? WhoWin.Player2 : WhoWin.Player1;
            if (Inspector.DidAllShipDown(player2.PlayerBoard))
            {
                whoWin = WhoWin.PlayerTwoWin;
            }
        }
        public void HumanMove(int vertical, int horizontal)
        {
            player2.MakeMove(horizontal, vertical);
            whoWin = player2.LastMoveHit ? WhoWin.Player2 : WhoWin.Player1;
            if (Inspector.DidAllShipDown(player2.PlayerBoard))
            {
                whoWin = WhoWin.PlayerTwoWin;
            }
        }
    }

}
