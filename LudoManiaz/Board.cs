using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoManiaz
{
    class Board
    {
        public char[,] map = new char[,]
        {
            { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
            { '|', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
            { '|', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '|', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '|' },
            { '|', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '|' },
            { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' }
        };

        public char[,] colors = new char[,]
        {
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'g', 'w', 'w', 'g', 'w', 'w', 'w', 'w', 'w', 'y', 'w', 'w', 'y', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'g', 'w', 'w', 'g', 'w', 'w', 'w', 'w', 'w', 'y', 'w', 'w', 'y', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'r', 'w', 'w', 'r', 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w', 'b', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'r', 'w', 'w', 'r', 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w', 'b', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' }
        };

        // Sets the spawn for the four colors, this is presat and shoul't be changed.
        // 0 = red, 1 = green, 2 = yellow, 3 = blue.
        public int[,,] home = new int[,,]
        {
            // Red
            {
                { 02, 11 },
                { 02, 14 },
                { 05, 11 },
                { 05, 14 }
            },
            // Green
            {
                { 02, 02 },
                { 02, 05 },
                { 05, 02 },
                { 05, 05 }
            },
            // Yellow
            {
                { 11, 02 },
                { 11, 05 },
                { 14, 02 },
                { 14, 05 }
            },
            // Blue
            {
                { 11, 11 },
                { 11, 14 },
                { 14, 11 },
                { 14, 14 }
            }
        };

        /*public int[,,] spawn = new int[,,]
        {
            // Red
            {
                { 8, 15 }
            },
            // Green
            {
                { 2, 8 }
            },
            // Yellow
            {
                { 8,  }
            }
        }*/

        public int[,] path = new int[,]
        {
            { 14, 07 }, { 13, 07 }, { 12, 07 }, { 11, 07 },
            { 10, 07 }, { 09, 06 }, { 09, 05 }, { 09, 04 },
            { 09, 03 }, { 09, 02 }, { 09, 01 }, { 08, 01 },
            { 07, 01 }, { 07, 02 }, { 07, 03 }, { 07, 04 },
            { 07, 05 }, { 07, 06 }, { 06, 07 }, { 05, 07 },
            { 04, 07 }, { 03, 07 }, { 02, 07 }, { 01, 07 },
            { 01, 08 }, { 01, 09 }, { 02, 09 }, { 03, 09 },
            { 04, 09 }, { 05, 09 }, { 06, 09 }, { 07, 10 },
            { 07, 11 }, { 07, 12 }, { 07, 13 }, { 07, 14 },
            { 07, 15 }, { 08, 15 }, { 09, 15 }, { 09, 14 },
            { 09, 13 }, { 09, 12 }, { 09, 11 }, { 09, 10 },
            { 10, 09 }, { 11, 09 }, { 12, 09 }, { 13, 09 },
            { 14, 09 }, { 15, 09 }, { 15, 08 }, { 15, 07 }
        };

        public int[,,] goal = new int[,,]
        {
            // Red
            {
                { 14, 08 }, { 13, 08 }, { 12, 08 }, { 11, 08 }, { 10, 08 }
            },
            // Green
            {
                { 08, 02 }, { 08, 03 }, { 08, 04 }, { 08, 05 }, { 08, 06 }
            },
            // Yellow
            {
                { 02, 08 }, { 03, 08 }, { 04, 08 }, { 05, 08 }, { 06, 08 }
            },
            // Blue
            {
                { 10, 08 }, { 11, 08 }, { 12, 08 }, { 13, 08 }, { 14, 08 }
            }
        };

        public List<int> occupiedSpaces = new List<int> { };
        //public int[] occupiedSpaces = new int[16]; // Need to store the occupied spaces, don't really care who stands there.


        // Test functions, move these to other files.
        // This sets a specific color at a specefic position in the possible path... Just try it.
        public void setPlayPos(Program.Colors ePlayer, int pos)
        {
            // Just to make sure it doesn't crash if the value is above 51
            while (pos > 51)
            {
                pos -= 52;
            }


            int player = (int)ePlayer;  // Convert Program.Colors to int.
            int x = path[pos, 0], y = path[pos, 1];
            char color = 'w';
            // Set the item, so it can be removed in the switch.
            map[x, y] = 'O';
            switch (player)
            {
                case 0:
                    color = 'r';
                    break;
                case 1:
                    color = 'g';
                    break;
                case 2:
                    color = 'y';
                    break;
                case 3:
                    color = 'b';
                    break;
                case 4:
                    color = 'w';
                    map[x, y] = ' ';
                    break;
            }

            // Set the pre defined color.
            colors[x, y] = color;
            occupiedSpaces.Add(pos);
        }

        // Remove all items from the board.
        public void clearBoard()
        {
            for (int i = occupiedSpaces.Count - 1; i >= 0; i--)
            {
                setPlayPos(Program.Colors.WHITE, occupiedSpaces[i]);
                occupiedSpaces.RemoveAt(i);
            }

            // Use later
            //newPersonList.RemoveAll(p => p.name == "A");
        }

        // Function to move a pawn out of spawn.
        //public void startPawn(Player)
    }
}
