using ConsoleAppStatki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppStatki
{
    class StatusMaker
    {
        /// <summary>
        /// Changing choosen field status on player board depend on status
        /// </summary>
        /// <param name="board">Player board</param>
        /// <param name="shipList">Player ship list</param>
        /// <param name="fieldToChange">Choosen field, we want to check in board</param>
        public void ChangeFieldStatus(List<Field> board, List<Ship> shipList, Field fieldToChange)
        {
            if (fieldToChange.FieldStatus == FieldStatusEnum.Ship)
            {
                fieldToChange.FieldStatus = FieldStatusEnum.Wrack;

                if (AllPartsShipDown(board, shipList, fieldToChange))
                {
                    //caly statek padl wiec pola wokol niego zaznacz na sprawdzone
                    ChangeOutFieldChecked(board, fieldToChange);
                }
            }
            else
            {
                fieldToChange.FieldStatus = FieldStatusEnum.Checked;
            }
        }
        private bool AllPartsShipDown(List<Field> board, List<Ship> shipList, Field chosenField)
        {
            var hitedShip = shipList.FirstOrDefault(w =>
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
        private void ChangeOutFieldChecked(List<Field> board, Field field)
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
