using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        //------------------FLOATING POINT ASSERTS------------------------------------------------------
        [Fact]
        [Trait("Category","Boss")]//for filtering the tests in test explorer
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);//3 decimal places precision will automatically round off the value
        }

        //-------------WRITING CUSTOM TEST OUTPUT MESSAGES---------------
        private readonly ITestOutputHelper _output;
        public BossEnemyShould(ITestOutputHelper output)//constructor
        {
            _output = output;
        }

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower1()
        {
            //Console.WriteLine("message to print on console"); won't work
            _output.WriteLine("Creating Boss Enemy");

            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
