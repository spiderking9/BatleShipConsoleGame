using System;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public class HumanConsolePlayer : Player
    {
        public HumanConsolePlayer(BoardMaker boardMaker) : base(boardMaker)
        {
        }

        public override void MakeMove(int horizontal, int vertical)
        {
            int horiz = InputHorizontal();
            int vert = InputVertical();
            ChosenFieldOnOponentBoard = PlayerBoard.FirstOrDefault(w => w.Vertical == vert & w.Horizontal == horiz);

            base.MakeMove();
        }

        private static int InputVertical()
        {
            Console.WriteLine("podaj pion");
            int vertical = int.Parse(Console.ReadLine());
            return vertical;
        }

        private static int InputHorizontal()
        {
            Console.WriteLine("");
            Console.WriteLine("podaj poziom");
            int horizontal = int.Parse(Console.ReadLine());
            return horizontal;
        }
    }
}
