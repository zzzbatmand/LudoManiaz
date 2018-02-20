using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoManiaz
{
    class Game
    {
        /// <summary>
        /// Converts a 3D int array to a 2D, by using input parameters and preset pos. 0/1
        /// </summary>
        /// <param name="inp"></param>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <returns></returns>
        public int[,] int3DTo2D(int[,,] inp, int item0, int item1)
        {
            int[,] res = new int[,]
            {
                { inp[ item0, item1, 0], inp[ item0, item1, 1] }
            };

            return res;
        }

        /// <summary>
        /// Converts a 3D int array to a 1D, by using input parameters and preset pos. 0/1
        /// </summary>
        /// <param name="inp"></param>
        /// <param name="item0"></param>
        /// <param name="item1"></param>
        /// <returns>1 dimentional array</returns>
        public int[] int3DTo1D(int[,,] inp, int item0, int item1)
        {
            int[] res = new int[]
            {
                inp[ item0, item1, 0],
                inp[ item0, item1, 1]
            };

            return res;
        }
        public int[] int2DTo1D(int[,] inp, int item)
        {
            int[] res = new int[]
            {
                inp[item, 0],
                inp[item, 1]
            };

            return res;
        }
    }
}
