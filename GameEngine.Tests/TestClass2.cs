using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    //-----------TO USE SHARED GameState() OBJECT HERE AS WELL AS TestClass1-------------
    //----------NO INTERFACE NEEDED TO IMPLEMENT LIKE :IClassFixture<GameStateFixture>----- 
    [Collection("GameState Collection")]
    public class TestClass2
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public TestClass2(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }
        
        [Fact]
        public void Test1()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }
        [Fact]
        public void Test2()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }
    }
}
