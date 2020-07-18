using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    //--------TO SHARE GmaeState() OBJECT ACROSS MULTIPLE CLASSES(NOT ONLY IN SINGLE CLASS LIKE USING FIXTURE AND CONSTRUCTOR)--------
    [CollectionDefinition("GameState Collection")]
    public class GameStateCollection : ICollectionFixture<GameStateFixture>
    {
    }
}
