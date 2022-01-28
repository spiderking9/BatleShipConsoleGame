using ClassLibraryBatleShip.Models;
using System.Collections.Generic;

namespace WebBatleShip.Models
{
    public class MsgToFront
    {
        public IEnumerable<Field> FieldsListPlayer1 { get; set; }
        public IEnumerable<Field> FieldsListPlayer2 { get; set; }
        public WhoWin IsMyTurn { get; set; }
    }
    public enum WhoWin
    {
        Player1, Player2, WhaitingForScore, PlayerOneWin, PlayerTwoWin
    }
}


