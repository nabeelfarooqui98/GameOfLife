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
        public Board board { get; set; }
        public Game()
        {

        }

        internal void Play()
        {

            Console.WriteLine(
                "Please select how to initialize board:" +
                "\n1. Generate random board" +
                "\n2. Load board from file");

            var input = Console.ReadLine();
            bool status = false;

            switch (input)
            {
                case "1":
                    status = InitializeBoard();
                    break;

                case "2":
                    Console.WriteLine("Not implemented yet");
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
            if (status)
                StartGameLoop();

            Console.WriteLine("Game over.");

        }

        private bool InitializeBoard()
        {
            Console.WriteLine("Dimensions:\nRows: ");
            var rows = Console.ReadLine();

            Console.WriteLine("Coloumns: ");
            var cols = Console.ReadLine();

            try
            {
                board = new Board(Convert.ToInt32(rows), Convert.ToInt32(cols), true);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to initialize board. Exception: " + e.Message);
                return false;
            }
        }
        private void StartGameLoop()
        {

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

