﻿using System;
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
        }; // 0 = home
        
        public Program.Colors color = Program.Colors.WHITE; // Default is (w)hite
        private int startLocation = 0; // Start location for a new pawn.

        public Player(Program.Colors colorz)
        {
            int player = (int)colorz;
            color = colorz;

            for (int i = 0; i < pawnLocations.GetLength(0); i++)
            {
                pawnLocations[i, 0] = board.home[player, i, 0];
                pawnLocations[i, 1] = board.home[player, i, 1];
            }

            //pawnLocations = board.home.GetValue(player)
        }
    }
}
