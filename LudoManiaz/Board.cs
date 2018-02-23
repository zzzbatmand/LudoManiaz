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
        // Map and colors for the board.
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

        // Spawn blocks for the colors.
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

        private void removePawnAtVal(int value, Program.Colors clear = Program.Colors.WHITE)
        {
            // Remove the pawn from the previous space.
            setPlayPos(Program.Colors.WHITE, value, (int)clear);
            // Remove the pawn from logic.
            occupiedSpaces.RemoveAll(p => p == value);
        }

        // Test functions, move these to other files.
        // This sets a specific color at a specefic position in the possible path... Just try it.
        public int setPlayPos(Program.Colors ePlayer, int pos, int playerColor = 4)
        {
            int pColor = (int)ePlayer;  // Convert Program.Colors to int.
            int x = 0, y = 0;

            // If the pawn is on the end line.
            if (pos > 100)
            {
                pos -= 100;     // Remove 100 from the result, so i can work with it.
                // Just to make sure it doesn't crash if the value is above 51
                while (pos > goal.GetLength(1) - 1)
                {
                    pos -= goal.GetLength(1);
                }
                if (playerColor != 4)
                {
                    x = goal[playerColor, pos, 0];
                    y = goal[playerColor, pos, 1];
                }
                else
                {
                    x = goal[pColor, pos, 0];
                    y = goal[pColor, pos, 1];
                }
                

                pos += 100;     // Add 100, so I keep it in the end line.
            }
            else
            {
                // Just to make sure it doesn't crash if the value is above 51
                while (pos > boardSize - 1)
                {
                    pos -= boardSize;
                }

                x = path[pos, 0];
                y = path[pos, 1];
            }
            

            char color = 'w';
            // Set the item, so it can be removed in the switch.
            map[x, y] = 'O';
            switch (pColor)
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
        /// <returns>Weather the player has won or not</returns>
        public bool movePawn(Player player, int nr, int ammount)
        {
            if (nr > 3)
            {
                Console.WriteLine("Something went wrong, the selected pawn is too high: " + nr);
                return false;
            }

            bool movePawn = false;
            int pawnNewLocation = player.pawnTileLocations[nr] + ammount;


            // If the selected pawn, isn't in spawn AND it isn't in goal (0, 0)
            if (game.int2DTo1D(player.pawnLocations, nr) != game.int3DTo1D(home, (int)player.color, nr) &&
                player.pawnTileLocations[nr] > -1)
            {
                // If the pawn is at end
                if (player.pawnTileLocations[nr] > 100)
                {
                    // If the pawn will hit goal.
                    if ((pawnNewLocation - 100) == goal.GetLength(1) - 1)
                    {
                        Console.WriteLine("I hit the goal");
                        // Remove the item from everywhere
                        removePawnAtVal(player.pawnTileLocations[nr], player.color);  // Remove the player from board.
                        player.pawnTileLocations[nr] = -1;              // Pawn is -1 (goal)
                        player.pawnLocations[nr, 0] = 0;                // Set the x variable.
                        player.pawnLocations[nr, 1] = 0;                // Set the y variable.

                        bool gameOver = true;
                        for (int i=0; i<player.pawnTileLocations.Length; i++)
                        {
                            // If a pawn hasn't ended. Basically skipped if player wins.
                            if (player.pawnTileLocations[i] != -1)
                                gameOver = false;
                        }

                        if (gameOver)
                        {
                            Console.WriteLine("You win");
                            return true;
                        }
                            
                    }

                    // If the throw, would make the pawn pass the last goal item.
                    else if (pawnNewLocation > goal.GetLength(1))
                    {
                        // Get the distance to move back
                        int moveBack = (pawnNewLocation + 1) - goal.GetLength(1) - 100;   // Remove the goal checker (100)
                        // Set the pawn location, to the new location.
                        pawnNewLocation = goal.GetLength(1) - moveBack - 1 + 100;   // Add the goal checker (100)

                        if (isSpaceFree(pawnNewLocation))
                            movePawn = true;
                        else
                            Console.WriteLine("You can't move that pawn. The space is occupied.");
                    }
                    else
                    {
                        if (isSpaceFree(pawnNewLocation))
                            movePawn = true;
                        else
                            Console.WriteLine("You can't move that pawn. The space is occupied.");
                    }
                }


                // If the pawn position is less than the last position. This reduces checks, if the pawn isn't nearing its end.
                else if (player.pawnTileLocations[nr] <= player.lastBlock)
                {
                    // Check if the move will make it pass its last tile.
                    if (pawnNewLocation <= player.lastBlock)
                    {
                        // If the tile is free, then go there.
                        if (isSpaceFree(pawnNewLocation))
                            movePawn = true;
                        else
                            Console.WriteLine("You can't move that pawn. The space is occupied.");
                    }
                    else if (pawnNewLocation > player.lastBlock)
                    {
                        Console.WriteLine("I am now attaking");
                        int remaining = pawnNewLocation - player.lastBlock;
                        pawnNewLocation = remaining - 1 + 100; // Set the location to the new value for the goal line, -1 to start at 0, then add 100 to tell that it is the goal line.

                        // If the tile is free, then go there.
                        if (isSpaceFree(pawnNewLocation))
                            movePawn = true;
                        else
                            Console.WriteLine("You can't move that pawn. The space is occupied.");
                    }
                    else
                    {
                        Console.WriteLine("You are at the last point");
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
            else if (player.pawnTileLocations[nr] == -2)
            {
                Console.WriteLine("The pawn is in spawn");
            }
            else
            {
                Console.WriteLine("The pawn is in goal");
            }

            if (movePawn)
            {
                if (pawnNewLocation >= 100)
                    removePawnAtVal(player.pawnTileLocations[nr], player.color);   // Remove the pawn from the previous space.
                        // I need this to remove a crash, where white didn't exist in the goal line.
                else
                    removePawnAtVal(player.pawnTileLocations[nr]);   // Remove the pawn from the previous space.
                
                // Set the pawn at a new position.
                player.pawnTileLocations[nr] = setPlayPos(player.color, pawnNewLocation);
            }

            return false;
        }
    }
}
