using ClassLibraryBatleShip;
using WebBatleShip.Models;

namespace WebBatleShip.Games
{
    public interface IGame
    {
        public BoardMaker boardMaker { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        //public bool playerOneMove { get; set; }
        //public bool playerTwoMove { get; set; }
        public WhoWin whoWin { get; set; }
        public void PlayerOneMove();
        public void PlayerTwoMove();
        public void HumanMove(int vertical, int horizontal);
    }
}
