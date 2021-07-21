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
            board = new Board(10, 10, true);
        }

        internal void Play()
        {

            Console.WriteLine(
                "Please select how to initialize board:" +
                "\n1. Generate random board" +
                "\n2. Load board from file");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartGameLoop();
                    break;

                case "2":
                    throw new NotImplementedException();
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
            Console.WriteLine("Game over.");

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

