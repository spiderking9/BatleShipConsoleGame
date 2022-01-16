using ConsoleAppStatki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppStatki
{
    class Displayer
    {
        /// <summary>
        /// Take data from input in console from human player
        /// </summary>
        /// <param name="board">Player board</param>
        public void TakeDataFromHumanPlayer(List<Field> board)
        {
            Console.WriteLine("");
            Console.WriteLine("podaj poziom");
            int horizontal = int.Parse(Console.ReadLine());
            Console.WriteLine("podaj pion");
            int vertical = int.Parse(Console.ReadLine());
            var choosenField = board.FirstOrDefault(w => w.Vertical == vertical & w.Horizontal == horizontal);
            if (choosenField.FieldStatus == FieldStatusEnum.Ship) choosenField.FieldStatus = FieldStatusEnum.Wrack;
            else
            {
                choosenField.FieldStatus = FieldStatusEnum.Checked;
            }
        }
        /// <summary>
        /// Display board in console
        /// </summary>
        /// <param name="board">Player board</param>
        /// <param name="pushLeft">Push displayed board from left in rows*30</param>
        public void PaintConsole(List<Field> board, int pushLeft = 0)
        {
            foreach (var item in board)
            {
                Console.CursorLeft = item.Horizontal * 4 + pushLeft * 30;
                Console.CursorTop = item.Vertical * 2;
                switch (item.FieldStatus)
                {
                    case FieldStatusEnum.Ship:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                        break;
                    case FieldStatusEnum.Empty:
                        Console.Write("0");
                        break;
                    case FieldStatusEnum.Checked:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("S");
                        Console.ResetColor();
                        break;
                    case FieldStatusEnum.Wrack:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("X");
                        Console.ResetColor();
                        break;
                    case FieldStatusEnum.ShipNeighbor:
                        Console.Write("P");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
