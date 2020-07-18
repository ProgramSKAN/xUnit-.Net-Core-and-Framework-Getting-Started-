using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    //-------------FOR SHARING CONTENT BETWEEN TESTS DURING EXECUTION--------------------
    public class GameStateFixture : IDisposable
    {
        public GameState State { get; private set; }

        public GameStateFixture()
        {
            State = new GameState();
        }

        public void Dispose()
        {
            //Cleanup
        }
    }
}
