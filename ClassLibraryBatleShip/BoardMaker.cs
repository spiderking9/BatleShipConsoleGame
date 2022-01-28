using ClassLibraryBatleShip.Models;
using System.Collections.Generic;

namespace ClassLibraryBatleShip
{
    public class BoardMaker
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public BoardMaker(int width = 10, int height = 10)
        {
            Width = width;
            Height = height;
        }

        public IEnumerable<Field> Create(IEnumerable<Ship> shipList)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    yield return new Field()
                    {
                        Vertical = i,
                        Horizontal = j,
                        FieldStatus = ChangeStatusIfShip(i, j, shipList)
                    };
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
