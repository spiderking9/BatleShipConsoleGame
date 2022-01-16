using ConsoleAppStatki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppStatki
{
    class BoardMaker
    {
        private int maxVertical;
        private int maxHorizontal;

        public BoardMaker(int maxVertical, int maxHorizontal)
        {
            this.maxVertical = maxVertical;
            this.maxHorizontal = maxHorizontal;
        }
        /// <summary>
        /// Random field from board, cant select Checked or Wrack fields
        /// </summary>
        /// <param name="board">Player board</param>
        /// <returns></returns>
        public Field DrawField(List<Field> board)
        {
            Random rn = new Random();
            var fieldList = board.Where(w => w.FieldStatus != FieldStatusEnum.Checked && w.FieldStatus != FieldStatusEnum.Wrack).ToList();
            int index = rn.Next(fieldList.Count);
            return fieldList[index]; ;
        }
        /// <summary>
        /// Create field - take ship position and put in board
        /// </summary>
        /// <param name="board">Player board</param>
        /// <param name="shipList">Ship list</param>
        public void CreateField(List<Field> board, List<Ship> shipList)
        {
            for (int i = 0; i < maxVertical; i++)
            {
                for (int j = 0; j < maxHorizontal; j++)
                {
                    board.Add(new Field()
                    {
                        Vertical = i,
                        Horizontal = j,
                        FieldStatus = ChangeStatusIfShip(i, j, shipList)
                    });
                }
            }
        }
        private FieldStatusEnum ChangeStatusIfShip(int vertical, int horizontal, IEnumerable<Ship> shipsList)
        {
            foreach (var statek in shipsList)
            {
                if ((statek.StartVertical >= vertical &&
                    statek.StopVertical <= vertical &&
                    statek.StartHorizontal >= horizontal &&
                    statek.StopHorizontal <= horizontal) ||
                    (statek.StartVertical <= vertical &&
                    statek.StopVertical >= vertical &&
                    statek.StartHorizontal <= horizontal &&
                    statek.StopHorizontal >= horizontal))
                    return FieldStatusEnum.Ship;
            }

            return FieldStatusEnum.Empty;
        }
    }
}
