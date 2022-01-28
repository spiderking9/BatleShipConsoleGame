namespace ClassLibraryBatleShip
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(BoardMaker boardMaker) : base(boardMaker)
        {
        }

        public override void MakeMove(int horizontal, int vertical)
        {
            ChosenFieldOnOponentBoard = random.Field(PlayerBoard);
            base.MakeMove();
        }
    }
}
