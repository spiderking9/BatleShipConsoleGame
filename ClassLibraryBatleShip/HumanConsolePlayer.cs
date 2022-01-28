using System;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public class HumanPlayer : Player
    {
        private int horizontal;
        private int vertical;
        public HumanPlayer(BoardMaker boardMaker) : base(boardMaker)
        {
        }

        public override void MakeMove(int horizontal, int vertical)
        {
            ChosenFieldOnOponentBoard = PlayerBoard.FirstOrDefault(w => w.Vertical == vertical & w.Horizontal == horizontal);

            base.MakeMove();
        }
    }
}
