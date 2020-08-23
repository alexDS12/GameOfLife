using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameOfLife
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <value name="SIZE">size of matrix (SIZE x SIZE)</value>
        /// <value name="game">new game instance</value>
        #region variables
        private const int SIZE = 20;
        private static Game game;
        #endregion

        [STAThread]
        static void Main()
        {
            game = new Game(SIZE, SIZE);
        }
    }
}
