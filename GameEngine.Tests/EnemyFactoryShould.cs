using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        //-------------MAKING ASSERTS AGANIST OBJECT TYPES-----------------------------------
        [Fact]
        //[Trait("Category","Enemy")]//we can keep this at class level to make all the tests in the class to be Category Enemy
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        //[Fact]
        [Fact(Skip ="Don't need to run this")]//to skip test.(mention reason)
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedByExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            //Additional asserts on types object
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);//returns BossEnemy type

            //Assert.IsType<Enemy>(enemy); this will fails even BossEnemy type derived from Enemy type
            Assert.IsAssignableFrom<Enemy>(enemy);//this will consider inheritance types also unlike Assert.Istype which is strict
        }

        //------------------------ASSERTING ON OBJECT TYPES-----------------------------------
        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);//check both Enemy objects are not same onject references
        }

        //------------------------ASSERTING THAT CODE THROWS CORRECT EXCEPTIONS------------------
        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            //or
            Assert.Throws<ArgumentNullException>("name",() => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex=
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie",true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
