using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        /// <summary>
        /// Game class
        /// </summary>
        /// <value name="grid">grid of cells</value>
        /// <value name="_rows">height of game</value>
        /// <value name="_columns">width of game</param>
        /// <value name="Generation">current generation that is running</value>
        #region variables
        private Cell[,] grid;
        private int _rows;
        private int _columns;
        public int Generation { get; set; }
        public bool IsRunning { get; set; }
        #endregion

        public Game(int rows, int columns)
        {
            Generation = 0;
            IsRunning = true;
            _rows = rows;
            _columns = columns;
            grid = new Cell[_rows, _columns];
            PopulateGrid();
            new Thread(new ThreadStart(RunGame)).Start();
        }

        /// <summary>
        /// Populate grid with cells based on random integers
        /// </summary>
        private void PopulateGrid()
        {
            Random r = new Random();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Cell newCell = new Cell();
                    newCell.X = i; 
                    newCell.Y = j;
                    if (r.Next(5) == 1)
                    {
                        newCell.IsAlive = true;
                    }
                    else
                    {
                        newCell.IsAlive = false;
                    }
                    grid[i, j] = newCell;
                }
            }
        }

        /// <summary>
        /// Returns number of neighbors alive for a specific cell at row, column
        /// </summary>
        /// <param name="row">Row of the cell</param>
        /// <param name="column">Column of the cell</param>
        /// <returns>number of neighbors alive</returns>
        private int GetAliveNeighbors(int row, int column)
        {
            int alive = 0;

            if (row > 0 && grid[row - 1, column].IsAlive) alive++;

            if (row < _columns - 1 && grid[row + 1, column].IsAlive) alive++;

            if (column > 0 && grid[row, column - 1].IsAlive) alive++;

            if (column < _rows - 1 && grid[row, column + 1].IsAlive) alive++;

            if (row > 0 && column > 0 && grid[row - 1, column - 1].IsAlive) alive++;

            if (row < _columns - 1 && column > 0 && grid[row + 1, column - 1].IsAlive) alive++;

            if (row < _columns - 1 && column < _rows - 1 && grid[row + 1, column + 1].IsAlive) alive++;

            if (row > 0 && column < _rows - 1 && grid[row - 1, column + 1].IsAlive) alive++;

            return alive;
        }

        /// <summary>
        /// Runs game in a separate Thread
        /// </summary>
        private void RunGame()
        {
            while (IsRunning)
            {
                Console.Clear();
                DrawGame();
                Tick();
                Generation++;
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Draws board (TODO: visual game)
        /// </summary>
        private void DrawGame()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (grid[i, j].IsAlive)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Runs the game 1 tick to get next generation (TODO: check stability and stop the game when grid and nextGeneration are the identical
        /// </summary>
        private void Tick()
        {
            Cell[,] nextGeneration = (Cell[,])grid.Clone();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    int aliveNeighbors = GetAliveNeighbors(i, j);

                    nextGeneration[i, j].IsAlive = (aliveNeighbors == 3 || (grid[i, j].IsAlive && aliveNeighbors == 2)) ? true : false;
                }
            }
            grid = nextGeneration;
        }
    }
}
