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
        private int[] pawnLocations = new int[] { 0, 0, 0, 0 }; // 0 = home
        private char color = 'w'; // Default is (w)hite
        private int startLocation = 0; // Start location for a new pawn.
    }
}
