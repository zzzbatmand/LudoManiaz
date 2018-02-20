using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoManiaz
{
    class Board
    {
        Game game = new Game();

        #region Preset arrays
        public char[,] map = new char[,]
        {
            { '╔', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '╗' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '║' },
            { '║', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '║' },
            { '║', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '║', '#', 'O', '#', '#', 'O', '#', ' ', ' ', ' ', '#', 'O', '#', '#', 'O', '#', '║' },
            { '║', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '║' },
            { '╚', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '═', '╝' }
        };

        public char[,] colors = new char[,]
        {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', 'g', ' ', ' ', 'g', ' ', ' ', ' ', ' ', ' ', 'y', ' ', ' ', 'y', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', 'g', ' ', ' ', 'g', ' ', ' ', ' ', ' ', ' ', 'y', ' ', ' ', 'y', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', 'r', ' ', ' ', 'r', ' ', ' ', ' ', ' ', ' ', 'b', ' ', ' ', 'b', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', 'r', ' ', ' ', 'r', ' ', ' ', ' ', ' ', ' ', 'b', ' ', ' ', 'b', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
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

        public int[] spawn = new int[]
        {
            // Red
            0,
            // Green
            13,
            // Yellow
            26,
            // Blue
            39
        };

        // Predefine the path a pawn can walk.
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

        // Predefines the last 6 blocks for the colors goal.
        public int[,,] goal = new int[,,]
        {
            // Red
            {
                { 14, 08 }, { 13, 08 }, { 12, 08 }, { 11, 08 }, { 10, 08 }, { 09, 08 }
            },
            // Green
            {
                { 08, 02 }, { 08, 03 }, { 08, 04 }, { 08, 05 }, { 08, 06 }, { 08, 07 }
            },
            // Yellow
            {
                { 02, 08 }, { 03, 08 }, { 04, 08 }, { 05, 08 }, { 06, 08 }, { 07, 08 }
            },
            // Blue
            {
                { 08, 14 }, { 08, 13 }, { 08, 12 }, { 08, 11 }, { 08, 10 }, { 08, 09 }
            }
        };

        public List<int> occupiedSpaces = new List<int> { };
        //public int[] occupiedSpaces = new int[16]; // Need to store the occupied spaces, don't really care who stands there.
        #endregion

        /// <summary>
        /// Checks if a position from the "occupiedSpaces" list is free
        /// </summary>
        /// <param name="pos">Position to check</param>
        /// <returns></returns>
        private bool isSpaceFree(int pos)
        {
            if (occupiedSpaces.Contains(pos))
            {
                return false;
            }

            // Basically, if pos is free, then return true.
            return true;
        }

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
        public void startPawn(Player player)
        {
            bool empty = true;
            for (int i=0; i<player.pawnLocations.GetLength(0); i++)
            {
                int color = (int)player.color;

                if (game.int2DTo1D(player.pawnLocations, i).SequenceEqual(game.int3DTo1D(home, color, i)))
                //if (game.int2DTo1D(player.pawnLocations, i).SequenceEqual(new int[] { 0, 0 }))
                {
                    empty = false;
                    occupiedSpaces.Add(spawn[color]);

                    player.pawnLocations[i, 0] = path[spawn[color], 0];
                    player.pawnLocations[i, 1] = path[spawn[color], 1];

                    Console.WriteLine("Pawn spawned.");
                    int x = home[color, i, 0];
                    int y = home[color, i, 1];
                    map[x, y] = ' ';

                    setPlayPos(player.color, spawn[color]);


                    break;
                }
            }
            if (empty)
            {
                Console.WriteLine("You can't do that. There is no one in spawn.");
            }
        }

    }
}
