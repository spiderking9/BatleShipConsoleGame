using ConsoleAppStatki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppStatki
{
    class ShipGenerator
    {
        private int maxVertical;
        private int maxHorizontal;

        public ShipGenerator(int maxVertical, int maxHorizontal)
        {
            this.maxVertical = maxVertical;
            this.maxHorizontal = maxHorizontal;
        }
        /// <summary>
        /// Create random list of 10 ships (one with 4 mast, two with 3 mast, three with 2 mast and four with 1 mast) 
        /// </summary>
        /// <returns>return ten random placed ships</returns>
        public List<Ship> RandomAllShipOnField()
        {
            List<Ship> shipList = new List<Ship>();
            //Romieszczanie statkow 4 maszztowych
            #region 4 mast

            List<Ship> location4mast = new List<Ship>();
            CountAllShipPosition(location4mast, 4);
            DrawXMast(location4mast, shipList);

            #endregion 4 mast
            //Romieszczanie statkow 3 maszztowych
            #region 3 mast
            List<Ship> location3mast = new List<Ship>();
            CountAllShipPosition(location3mast, 3);

            for (int i = 0; i < 2; i++)
            {
                location3mast = RemoveCrossedShip(location3mast, shipList);
                DrawXMast(location3mast, shipList);
            }

            #endregion 3 mast
            //Romieszczanie statkow 2 maszztowych
            #region 2 mast

            List<Ship> location2mast = new List<Ship>();
            //tworzymy liste wszystkich wariantow rozmieszczenia statkow na planszy
            CountAllShipPosition(location2mast, 2);

            for (int i = 0; i < 3; i++)
            {
                location2mast = RemoveCrossedShip(location2mast, shipList);
                DrawXMast(location2mast, shipList);
            }

            #endregion 2 mast

            #region 1 mast

            List<Ship> location1mast = new List<Ship>();
            //tworzymy liste wszystkich wariantow rozmieszczenia statkow na planszy
            CountAllShipPosition(location1mast, 1);

            for (int i = 0; i < 4; i++)
            {
                location1mast = RemoveCrossedShip(location1mast, shipList);
                DrawXMast(location1mast, shipList);
            }

            #endregion 1 mast
            return shipList;
        }
        private void CountAllShipPosition(List<Ship> locationXMast, int mastCount = 4)
        {
            //zapisanie wszystkich mozliwych rozmieszczen statkow
            for (int i = 0; i < maxVertical; i++)
            {
                for (int j = 0; j < maxHorizontal; j++)
                {
                    if (i < maxVertical - mastCount)
                        //dodanie pionowego
                        locationXMast.Add(new Ship()
                        {
                            StartVertical = i,
                            StopVertical = i + mastCount - 1,
                            StartHorizontal = j,
                            StopHorizontal = j
                        });

                    if (j < maxHorizontal - mastCount)
                        //dodanie poziomego
                        locationXMast.Add(new Ship()
                        {
                            StartVertical = i,
                            StopVertical = i,
                            StartHorizontal = j,
                            StopHorizontal = j + mastCount - 1
                        });
                }
            }
        }
        private void DrawXMast(List<Ship> locationXMast, List<Ship> shipList)
        {
            Random random = new Random();

            //losowanie z dostepnej puli
            var ship = locationXMast[random.Next(locationXMast.Count)];

            //dodanie do listy
            shipList.Add(ship);
        }
        private  List<Ship> RemoveCrossedShip(List<Ship> locationXMast, List<Ship> shipList)
        {
            foreach (var item in shipList)
            {
                locationXMast = locationXMast.Where(s =>
                  item.StopVertical + 1 < s.StartVertical ||
                  item.StopHorizontal + 1 < s.StartHorizontal ||
                  item.StartVertical - 1 > s.StopVertical ||
                  item.StartHorizontal - 1 > s.StopHorizontal
                ).ToList();
            }

            return locationXMast;
        }
    }
}
