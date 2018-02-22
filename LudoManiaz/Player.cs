using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoManiaz
{
    /// <summary>
    /// This class is used to track the 4 pawns and their location.
    /// Each version controles each color.
    /// </summary>
    class Player
    {
        Board board = new Board();

        public int[,] pawnLocations = new int[,]
        {
            { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }
        }; // 0 = end

        public int[] pawnTileLocations = new int[]
        {
            -2, -2, -2, -2
        }; // -2 = spawn, -1 = end
        
        public Program.Colors color = Program.Colors.WHITE; // Default is (w)hite
        private int startLocation = 0; // Start location for a new pawn.
        public int lastBlock = 0;       // Last touchable block before going to goal.

        public Player(Program.Colors colorz)
        {
            int player = (int)colorz;
            color = colorz;

            for (int i = 0; i < pawnLocations.GetLength(0); i++)
            {
                pawnLocations[i, 0] = board.home[player, i, 0];
                pawnLocations[i, 1] = board.home[player, i, 1];
            }

            // If the last block, would be negative, then start from the end and go forth.
            // Otherwise, just remove 2 from the spawn position.
            if (board.spawn[player] - 2 < 0)
                lastBlock = board.boardSize - 2;
            else
                lastBlock = board.spawn[player] - 2;

            //pawnLocations = board.home.GetValue(player)
        }
    }
}
