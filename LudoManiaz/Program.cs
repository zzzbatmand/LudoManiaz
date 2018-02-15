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

        static void printChar(char item, char color = 'w')
        {
            if (color == 'r')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == 'g')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (color == 'y')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (color == 'b')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write(item);

            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Board board = new Board();

            while (true)
            {
                Console.Write("Write number for location: ");
                int place = Convert.ToInt32(Console.ReadLine());

                board.setPlayPos(Colors.RED, place);
                //board.setPlayPos(Colors.BLUE, 12);

                for (int i = 0; i < board.map.GetLength(0); i++)
                {
                    for (int j = 0; j < board.map.GetLength(1); j++)
                    {
                        printChar(board.map[i, j], board.colors[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
                board.clearBoard();
                Console.Clear();
            }
        }
    }
}
