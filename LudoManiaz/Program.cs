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

        static void printBoard(Board board)
        {
            // Draw the map.
            for (int i = 0; i < board.map.GetLength(0); i++)
            {
                for (int j = 0; j < board.map.GetLength(1); j++)
                {
                    printChar(board.map[i, j], board.colors[i, j]);
                }
                Console.WriteLine();
            }
            Console.Write("Pless enter to continue...");
            // Wait for a key press, then clear the board and screen.
            Console.ReadLine();
            //board.clearBoard();
            Console.Clear();
        }

        static bool hasPanOnField(Player player)
        {
            for (int i = 0; i < player.pawnTileLocations.Length; i++)
            {
                // If the pawn isn't in spawn or end.
                if (player.pawnTileLocations[i] >= 0)
                    return true;
            }
            return false;
        }

        static int[] getMoveablePawns(Player player)
        {
            // Define how many moveable pawns there are.
            int moveableInt = 0;
            for (int i = 0; i < player.pawnTileLocations.Length; i++)
            {
                if (player.pawnTileLocations[i] >= 0)
                    moveableInt++;
            }


            // Make the array for the moveable pawns.
            int[] res = new int[moveableInt];   // Result array.
            int pos = 0;                        // Position for result array.

            for (int i=0; i<player.pawnTileLocations.Length; i++)
            {
                if (player.pawnTileLocations[i] >= 0)
                {
                    res[pos] = i;
                    pos++;
                }
            }
            
            return res;
        }

        static bool playNice(Player player, Board board, int roll)
        {
            int[] moveable = getMoveablePawns(player);
            Console.WriteLine("You can move the following pawns: {0}", String.Join(",", moveable.Select(p => p.ToString()).ToArray()));

            // If there only is 1 pawn on the board.
            if (moveable.Length == 1)
            {
                // Just move the one pawn that there is.
                Console.WriteLine("You only have 1 pawn in game, that pawn has been moved");
                return board.movePawn(player, moveable[0], roll);
            }
            else
            {
                // Select the pawn to move, from the possible move list.
                int pawnMove = 0;
                while (pawnMove >= 0 && moveable.Contains(pawnMove))
                {
                    Console.Write("Select the pawn to move: ");
                    if (!int.TryParse(Console.ReadLine(), out pawnMove))
                    {
                        Console.WriteLine("The input is not a number");
                        Console.ReadLine();
                    }
                    else if (pawnMove < 0 || !moveable.Contains(pawnMove))
                    {
                        Console.WriteLine("The selected pawn, doesn't exist");
                    }
                }

                // Move the pawn
                Console.WriteLine("Your pawn has been moved");
                return board.movePawn(player, moveable[pawnMove], roll);
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool gameIsRunning = true;
            int numOfPlayers = 0;
            Player[] players;
            Board board = new Board();
            bool gameOver = false;

            // A little game warning.
            Console.WriteLine("WARNING! Thise game is not very clever, if you try to move to an occupoed space, no matter who is on there," +
                "the game will skip your turn, so keep track of your pawns and their movement.");

            while (gameIsRunning)
            {
                while (numOfPlayers < 2 || numOfPlayers > 4)
                {
                    Console.Write("Please select the number of players (2-4): ");

                    // Try to parse the input as an int.
                    if (!int.TryParse(Console.ReadLine(), out numOfPlayers))
                        Console.WriteLine("The given item is not a number, try again");
                    else if (numOfPlayers > 4 || numOfPlayers < 2)
                        Console.WriteLine("The selected ammount is not valid");
                }

                Console.WriteLine("You have selected {0} players", numOfPlayers);
                // Define the players, to the selected ammount.
                players = new Player[numOfPlayers];

                for (int i=0; i<numOfPlayers; i++)
                {
                    // Set the players.
                    players[i] = new Player((Colors)i);
                }

                int playerTurn = 0;
                while (gameIsRunning)
                {
                    Console.WriteLine("It is player {0}'s turn", playerTurn);
                    Console.Write("Press enter to roll..");
                    Console.ReadLine();
                    int roll = rnd.Next(1, 7);
                    Console.WriteLine("You rolled {0}", roll);

                    if (!hasPanOnField(players[playerTurn]))
                    {
                        if (roll != 6)
                        {
                            Console.WriteLine("You don't have any pawns on the board, and can't use that roll");
                        }
                        else
                        {
                            board.startPawn(players[playerTurn]);
                        }
                    }
                    else
                    {
                        /*if (roll == 6)
                        {
                            bool keep = true;
                            while (keep)
                            {
                                Console.Write("Do you want to spawn a new pawn? (y/n): ");
                                char inp = Console.ReadKey().KeyChar;
                                Console.WriteLine();

                                if (inp == 'y')
                                {
                                    board.startPawn(players[playerTurn]);
                                    keep = false;
                                }
                                else if (inp == 'n')
                                {
                                    keep = false;
                                    gameOver = playNice(players[playerTurn], board, roll);
                                }
                                else
                                {
                                    Console.WriteLine("The input is not recognised");
                                }
                            }
                        }
                        else
                        {*/
                            gameOver = playNice(players[playerTurn], board, roll);
                        //}
                    }

                    // Print the game board.
                    printBoard(board);

                    // Increment the player counter.
                    playerTurn++;
                    // Make sure the counter doesn't surpass the ammount of players there is.
                    if (playerTurn > numOfPlayers - 1)
                        playerTurn = 0;

                    if (gameOver)
                        gameIsRunning = false;
                }

                // Do you want to play again?
                // y = clear
                // n = nothing
            }
        }
    }
}
