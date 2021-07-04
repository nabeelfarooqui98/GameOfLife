using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10,10,true);
            for (int i = 0; i < 50; i++)
            {
                Console.Clear();
                Console.Write(board);
                Thread.Sleep(500);
                board.UpdateBoard();
            }            
        }
    }
}
