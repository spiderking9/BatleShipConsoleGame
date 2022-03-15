using ClassLibraryBatleShip.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public abstract class Player : IPlayerTurn
    {
        public Field ChosenFieldOnOponentBoard { get; set; } = new Field();
        public List<Field> PlayerBoard { get; set; } = new List<Field>();
        public List<Ship> ShipList { get; set; } = new List<Ship>();
        public bool LastMoveHit { get; set; }

        private readonly StatusMaker statusMaker;
        protected BatleshipRandom random;

        public Player(BoardMaker boardMaker)
        {
            random = new BatleshipRandom(boardMaker.Width, boardMaker.Height);
            ShipList = random.AllTypeShipOnField();
            PlayerBoard = boardMaker.Create(ShipList).ToList();
            statusMaker = new StatusMaker(PlayerBoard, ShipList);
        }

        public virtual void MakeMove(int horizontal = 0, int vertical = 0)
        {
            LastMoveHit = statusMaker.ChangeFieldStatus(ChosenFieldOnOponentBoard);
        }
    }
}
