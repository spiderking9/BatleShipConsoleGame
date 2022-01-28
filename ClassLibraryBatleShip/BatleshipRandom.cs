using ClassLibraryBatleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryBatleShip
{
    public class BatleshipRandom
    {
        private Generator generator;

        public BatleshipRandom(int boardWidth, int boardHeight)
        {
            generator = new Generator(boardWidth, boardHeight);
        }

        public List<Ship> AllTypeShipOnField()
        {
            List<Ship> shipList = new List<Ship>();
            //iteracja po typach enum
            foreach (var amount in Enum.GetValues(typeof(ShipMastAmount)))
            {
                //generuje pozycje danego typu statku
                List<Ship> shipsLocation = generator.ShipsPosition((ShipMastAmount)amount);
                //dodaje odwrotna ilosc statkow do ilosci masztow
                for (int i = 0; i < 5 - (int)amount; i++)
                {
                    shipsLocation = generator.RemoveCrossedShip(shipsLocation, shipList);
                    shipList.Add(Ship(shipsLocation));
                }
            }
            return shipList;
        }

        public Field Field(List<Field> board)
        {
            System.Random rn = new System.Random();
            List<Field> fieldsListWithoutCheckedAndWrack = board.Where(w => w.FieldStatus != FieldStatusEnum.Checked && w.FieldStatus != FieldStatusEnum.Wrack).ToList();
            int index = rn.Next(fieldsListWithoutCheckedAndWrack.Count);

            return fieldsListWithoutCheckedAndWrack[index];
        }

        private Ship Ship(List<Ship> shipLocation)
        {
            //TODO when no shiplocation what to do??
            if (shipLocation.Count == 0) return new Ship();
            System.Random random = new System.Random();
            return shipLocation[random.Next(shipLocation.Count)];
        }
    }
}
