using ClassLibraryBatleShip.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public class Generator
    {
        private readonly int boardWidth;
        private readonly int boardHeight;

        public Generator(int boardWidth, int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
        }

        public List<Ship> ShipsPosition(ShipMastAmount mastType)
        {
            List<Ship> locationShipsOnBoard = new List<Ship>();
            int mastAmount = (int)mastType;

            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (IsEnoughSpaceToPlaceShip(mastAmount, i, boardWidth))
                        locationShipsOnBoard.Add(new Ship()
                        {
                            StartVertical = i,
                            StopVertical = i + mastAmount - 1,
                            StartHorizontal = j,
                            StopHorizontal = j
                        });

                    if (IsEnoughSpaceToPlaceShip(mastAmount, j, boardHeight))
                        locationShipsOnBoard.Add(new Ship()
                        {
                            StartVertical = i,
                            StopVertical = i,
                            StartHorizontal = j,
                            StopHorizontal = j + mastAmount - 1
                        });
                }
            }

            return locationShipsOnBoard;
        }

        private bool IsEnoughSpaceToPlaceShip(int mastAmount, int place, int edge)
        {
            return place < edge - mastAmount;
        }

        public List<Ship> RemoveCrossedShip(List<Ship> shipsLocation, List<Ship> shipList)
        {
            foreach (var item in shipList)
            {
                shipsLocation = shipsLocation.Where(s =>
                  item.StopVertical + 1 < s.StartVertical ||
                  item.StopHorizontal + 1 < s.StartHorizontal ||
                  item.StartVertical - 1 > s.StopVertical ||
                  item.StartHorizontal - 1 > s.StopHorizontal
                ).ToList();
            }

            return shipsLocation;
        }
    }
}
