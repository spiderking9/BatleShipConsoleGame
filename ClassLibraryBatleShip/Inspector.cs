using ClassLibraryBatleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public class Inspector
    {
        public static bool DidAllShipDown(List<Field> board)
        {
            return board.FirstOrDefault(z => z.FieldStatus == FieldStatusEnum.Ship) == null;
        }
    }
}
