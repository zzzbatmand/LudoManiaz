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
        public int boardSize = 52;

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

        private void removePawnAt(int pos)
        {

            // Remove the pawn from the previous space.
            setPlayPos(Program.Colors.WHITE, pos);
            // Remove the pawn from logic.
            occupiedSpaces.RemoveAll(p => p == pos);
        }

        // Test functions, move these to other files.
        // This sets a specific color at a specefic position in the possible path... Just try it.
        public int setPlayPos(Program.Colors ePlayer, int pos)
        {
            // Just to make sure it doesn't crash if the value is above 51
            while (pos > boardSize - 1)
            {
                pos -= boardSize;
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

            return pos;
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
            int color = (int)player.color;

            // Check if the spawn is empty before trying to spawn.
            if (!isSpaceFree(spawn[color]))
            {
                Console.WriteLine("Can't spawn any pawns, your spawn is blocked.");
                return;
            }

            // Itterates throug each pawn, to see if any of them is in spawn.
            for (int i=0; i<player.pawnLocations.GetLength(0); i++)
            {
                if (game.int2DTo1D(player.pawnLocations, i).SequenceEqual(game.int3DTo1D(home, color, i)))
                //if (game.int2DTo1D(player.pawnLocations, i).SequenceEqual(new int[] { 0, 0 }))
                {
                    occupiedSpaces.Add(spawn[color]);

                    player.pawnLocations[i, 0] = path[spawn[color], 0];
                    player.pawnLocations[i, 1] = path[spawn[color], 1];
                    player.pawnTileLocations[i] = spawn[color];

                    Console.WriteLine("Pawn spawned.");
                    int x = home[color, i, 0];
                    int y = home[color, i, 1];
                    map[x, y] = ' ';

                    setPlayPos(player.color, spawn[color]);
                    
                    // If a spawn is triggered, then just return to caller.
                    return;
                }
            }

            // This is only triggere, if there is noone to spawn.
            Console.WriteLine("You can't do that. There is no one in spawn.");
        }

        /// <summary>
        /// Move a paticular players pawn
        /// </summary>
        /// <param name="player">The player to select</param>
        /// <param name="nr">The pawn nr. to move</param>
        /// <param name="ammount">How mutch to move it</param>
        public void movePawn(Player player, int nr, int ammount)
        {
            if (nr > 4)
            {
                Console.WriteLine("Something went wrong, the selected pawn is too high: " + nr);
                // return false
            }

            bool movePawn = false;
            int pawnNewLocation = player.pawnTileLocations[nr] + ammount;

            
            // If the selected pawn, isn't in spawn AND it isn't in goal (0, 0)
            if (game.int2DTo1D(player.pawnLocations, nr) != game.int3DTo1D(home, (int)player.color, nr) &&
                game.int2DTo1D(player.pawnLocations, nr) != new int[] { 0, 0 })
            {
                // If the pawn position is less than the last position. This reduces checks, if the pawn isn't nearing its end.
                if (player.pawnTileLocations[nr] <= player.lastBlock)
                {
                    // Check if the move will make it pass its last tile.
                    if ((player.pawnTileLocations[nr] + ammount) <= player.lastBlock)
                    {
                        // If the tile is free, then go there.
                        if (isSpaceFree(pawnNewLocation))
                            movePawn = true;
                        else
                            Console.WriteLine("You can't move that pawn. The space is occupied.");
                    }
                    else
                    {
                        Console.WriteLine("You are at last point");
                    }
                }
                else
                {
                    // If the location for the new pawn is free, then move it, otherwise leave it.
                    if (isSpaceFree(pawnNewLocation))
                        movePawn = true;
                    else
                        Console.WriteLine("You can't move that pawn. The space is occupied.");
                }
            }

            if (movePawn)
            {
                // Remove the pawn from the previous space.
                removePawnAt(player.pawnTileLocations[nr]);
                // Set the pawn at a new position.
                player.pawnTileLocations[nr] = setPlayPos(player.color, player.pawnTileLocations[nr] + ammount);
            }
        }
    }
}
