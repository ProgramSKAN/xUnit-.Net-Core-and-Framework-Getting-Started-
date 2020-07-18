using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        //-----REDUCING DUPLICATED TEST CODE--------------------
        //Instead of creating PlayerCharacter object in every test,we can initiate once in the constructor.Also add ITestOutputHelper
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;
        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating new PlayerCharacter");

            _sut = new PlayerCharacter();
        }

        public void Dispose()
        {
            //this will execute after every test method
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");

            //write clean up code here
            //_sut.Dispose();
        }
        //------------------------------------------------------

            //------------------BOOLEAN ASSERTS------------------------------------------------------
            [Fact]
            public void BeInexperiencedWhenNew()
            {
                //sut=system under test (naming convention)
               // PlayerCharacter sut = new PlayerCharacter();

                Assert.True(_sut.IsNoob);
            }

            //------------------STRING ASSERTS------------------------------------------------------
            [Fact]
            public void CalculateFullName()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.FirstName = "Tom";
                _sut.LastName = "Hanks";

                Assert.Equal("Tom Hanks", _sut.FullName);
            }

            [Fact]
            public void HaveFullNameStartingWithFirstName()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.FirstName = "Tom";
                _sut.LastName = "Hanks";

                Assert.StartsWith("Tom", _sut.FullName);
            }

            [Fact]
            public void HaveFullNameEndingWithLastName()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.LastName = "Hanks";

                Assert.EndsWith("Hanks", _sut.FullName);
            }

            [Fact]
            public void CalculateFullName_IgnoreCaseAssertExample()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.FirstName = "TOM";
                _sut.LastName = "HANKS";

                Assert.Equal("Tom Hanks", _sut.FullName, ignoreCase:true);
            }

            [Fact]
            public void CalculateFullName_SubstringAssertExample()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.FirstName = "Tom";
                _sut.LastName = "Hanks";

                Assert.Contains("om Ha", _sut.FullName);
            }

            [Fact]
            public void CalculateFullNameWithTitleCase()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.FirstName = "Tom";
                _sut.LastName = "Hanks";

                Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);//uppercase first letter for first and last name
            }

            //------------------NUMERIC VALUES ASSERTS------------------------------------------------------
            [Fact]
            public void StartWithDefaultHealth()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.Equal(100, _sut.Health);
            }

            [Fact]
            public void StartWithDefaultHealth_NotEqualExample()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.NotEqual(0, _sut.Health);
            }

            [Fact]
            public void IncreaseHealthAfterSleeping()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                _sut.Sleep();//Expect increase between 1 to 100 inclusive (randomly).since initial health=100,s0 100+random value

                //Assert.True(sut.Health >= 101 && sut.Health <= 200);
                //or
                Assert.InRange<int>(_sut.Health, 101, 200);//<int> not necessary because compiler can infer type
            }
            //------------------ASSERTING NULL VALUES------------------------------------------------------
            [Fact]
            public void NotHaveNickNameByDefault()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.Null(_sut.Nickname);
            }
            //------------------ASSERTING WITH COLLECTIONS------------------------------------------------------
            [Fact]
            public void HaveALongBow()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.Contains("Long Bow",_sut.Weapons);//List
            }

            [Fact]
            public void NotHaveAStaffOfWonder()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);//List
            }

            [Fact]
            public void HaveAtLeastOneKindOfSword()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));//verify list collection contains "sword"
            }

            [Fact]
            public void HaveAllExpectedWeapons()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                var expectedWeapons = new[]
                {
                "Long Bow",
                "Short Bow",
                "Short Sword",
                 };

                Assert.Equal(expectedWeapons, _sut.Weapons);//verify both sequences are equal
            }

            [Fact]
            public void HaveNoEmptyDefaultWeapons()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));//verifies all the items in the collection dont have null or white space
            }

            //---------------ASSERTING THAT THE EVENTS ARE RAISED----------------------------
            [Fact]
            public void RaiseSleptEvent()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.Raises<EventArgs>(
                    handler => _sut.PlayerSlept += handler,
                    handler => _sut.PlayerSlept -= handler,
                    () => _sut.Sleep());//when Sleep() is called PlayerSlept event should raise
            }

            [Fact]
            public void RaisePropertyChangedEvent()
            {
                //PlayerCharacter sut = new PlayerCharacter();

                Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
            }
    }
}

