using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell
    {
        public State CurrentState { get; set; }
        public State FutureState { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Cell(State state = State.Dead)
        {
            CurrentState = state;
            FutureState = state;
        }
        override
        public String ToString()
        {
            return CurrentState == State.Alive ? "O" : "X";
        }

        internal void UpdateFutureState(int numOfNeighbours)
        {
            switch (numOfNeighbours)
            {
                case 2:
                    FutureState = CurrentState;
                    break;
                case 3:
                    FutureState = State.Alive;
                    break;
                default:
                    FutureState = State.Dead;
                    break;
            }
        }

        internal void UpdateCurrentState()
        {
            CurrentState = FutureState;
        }
    }

    enum State
    {
        Alive,
        Dead
    }
}
