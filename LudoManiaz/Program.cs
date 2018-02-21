using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoManiaz
{
    class Program
    {
        public enum Colors { RED, GREEN, YELLOW, BLUE, WHITE };

        static void printChar(char item, char color)
        {
            switch (color)
            {
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 'g':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case 'y':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 'b':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.Write(item);

            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Board board = new Board();
            Player player1 = new Player(Colors.GREEN);
            Player player2 = new Player(Colors.BLUE);
            //Player red = new Player()

            while (true)
            {
                //Console.Write("Write number for location: ");
                Console.Write("Just press enter.");
                //int place = Convert.ToInt32(Console.ReadLine());
                Console.ReadLine();

                // board.setPlayPos(Colors.GREEN, place);
                //board.setPlayPos(Colors.BLUE, 12);
                board.startPawn(player1);
                board.movePawn(player1, 0, 5);
                board.startPawn(player2);

                // Draw the map.
                for (int i = 0; i < board.map.GetLength(0); i++)
                {
                    for (int j = 0; j < board.map.GetLength(1); j++)
                    {
                        printChar(board.map[i, j], board.colors[i, j]);
                    }
                    Console.WriteLine();
                }
                // Wait for a key press, then clear the board and screen.
                Console.ReadLine();
                //board.clearBoard();
                Console.Clear();
            }
        }
    }
}
