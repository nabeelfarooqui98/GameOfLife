using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        private int rows;
        private int cols;
        private Cell[,] board;

        public Board(int rows, int cols, bool random = false)
        {
            this.rows = rows;
            this.cols = cols;

            board = new Cell[rows, cols];

            if (random)
            {
                generateRandomBoard();
            }
            else
            {
                generateBoard();
            }
            
        }

        public void UpdateBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int numOfNeighbours = GetNumberOfNeighbours(i, j);
                    board[i, j].UpdateFutureState(numOfNeighbours);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j].UpdateCurrentState();
                }
            }
        }

        private int GetNumberOfNeighbours(int i, int j)
        {
            int num = 0;

            if(IsCellAlive(i-1, j-1)) num += 1;
            if(IsCellAlive(i-1, j)) num += 1;
            if(IsCellAlive(i-1, j+1)) num += 1;
            
            if(IsCellAlive(i, j-1)) num += 1;
            if(IsCellAlive(i, j+1)) num += 1;

            if(IsCellAlive(i+1, j-1)) num += 1;
            if(IsCellAlive(i+1, j)) num += 1;
            if(IsCellAlive(i+1, j+1)) num += 1;

            return num;
        }

        private bool IsCellAlive(int i, int j)
        {
            return i>=0 && i<rows && j >= 0 && j < cols && board[i, j].CurrentState == State.Alive;
        }

        override
        public String ToString()
        {
            String result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += board[i, j].ToString() + " ";
                }
                result += "\n";
            }
            return result;
        }

        private void generateBoard()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = new Cell();
                }
            }
        }

        private void generateRandomBoard()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = new Cell((State)random.Next(2));
                }
            }
        }
    }
}
