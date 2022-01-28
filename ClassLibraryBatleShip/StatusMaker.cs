using ClassLibraryBatleShip.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public class StatusMaker
    {
        private readonly List<Field> board;
        private readonly List<Ship> shipList;

        public StatusMaker(List<Field> board, List<Ship> shipList)
        {
            this.board = board;
            this.shipList = shipList;
        }

        public bool ChangeFieldStatus(Field fieldToChange)
        {
            if (fieldToChange.FieldStatus == FieldStatusEnum.Ship)
            {
                fieldToChange.FieldStatus = FieldStatusEnum.Wrack;

                if (AllPartsShipDown(fieldToChange))
                {
                    //caly statek padl wiec pola wokol niego zaznacz na sprawdzone
                    ChangeOutFieldChecked(fieldToChange);
                }
                return true;
            }

            fieldToChange.FieldStatus = FieldStatusEnum.Checked;
            return false;
        }
        private bool AllPartsShipDown(Field chosenField)
        {
            Ship hitedShip = shipList.FirstOrDefault(w =>
                chosenField.Vertical >= w.StartVertical &&
                chosenField.Vertical <= w.StopVertical &&
                chosenField.Horizontal >= w.StartHorizontal &&
                chosenField.Horizontal <= w.StopHorizontal
            );
            int balanceHitedShipParts = 0;
            for (int i = hitedShip.StartVertical; i <= hitedShip.StopVertical; i++)
            {
                for (int j = hitedShip.StartHorizontal; j <= hitedShip.StopHorizontal; j++)
                {
                    balanceHitedShipParts++;
                    if (board.FirstOrDefault(w => w.Vertical == i && w.Horizontal == j).FieldStatus == FieldStatusEnum.Wrack) balanceHitedShipParts--;
                }
            }

            return balanceHitedShipParts == 0;
        }
        private void ChangeOutFieldChecked(Field field)
        {
            List<Field> outsideField = new List<Field>()
                        {
                            board.FirstOrDefault(w => w.Vertical == field.Vertical + 1 && w.Horizontal == field.Horizontal + 1),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical + 1 && w.Horizontal == field.Horizontal),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical + 1 && w.Horizontal == field.Horizontal - 1),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical && w.Horizontal == field.Horizontal - 1),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical - 1 && w.Horizontal == field.Horizontal - 1),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical - 1 && w.Horizontal == field.Horizontal),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical - 1 && w.Horizontal == field.Horizontal + 1),
                            board.FirstOrDefault(w => w.Vertical == field.Vertical && w.Horizontal == field.Horizontal + 1)
                        };
            foreach (var item in outsideField)
            {
                if (item != null && item.FieldStatus == FieldStatusEnum.Empty) item.FieldStatus = FieldStatusEnum.Checked;
            }
        }
    }
}
