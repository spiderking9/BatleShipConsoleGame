using ClassLibraryBatleShip.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ClassLibraryBatleShip
{
    public class Display
    {
        public void Boards(Player playerOne, Player playerTwo, string whoMove, int sleepTimeAfterTurn)
        {
            OnConsole(playerOne.PlayerBoard, 2);
            OnConsole(playerTwo.PlayerBoard);
            Console.CursorTop = 20;
            Console.WriteLine($"Ruch ma gracz po {whoMove}");
            Console.CursorTop = 0;
            Thread.Sleep(sleepTimeAfterTurn);
        }

        private static void OnConsole(List<Field> board, int pushRight = 0)
        {
            foreach (var item in board)
            {
                SetCursorAtItemPosition(item, pushRight);

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

        private static void SetCursorAtItemPosition(Field item, int pushRight)
        {
            Console.CursorLeft = item.Horizontal * 4 + pushRight * 30;
            Console.CursorTop = item.Vertical * 2;
        }
    }
}
