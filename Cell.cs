using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell
    {
        /// <summary>
        /// Cell class
        /// </summary>
        /// <value name="IsAlive">cell state false - dead/dies true - alive/borns</value>
        /// <value name="x">position x on grid</value>
        /// <value name="y">position y on grid</value>      
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
