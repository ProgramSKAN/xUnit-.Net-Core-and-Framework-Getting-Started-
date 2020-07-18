using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


/*to create xunit for .net framework, add .net framework class library and add nuget package xUnit,xUnit.Runner.
 * 
 * */
namespace xUnitForFullFramework
{
    public class Class1
    {
        public class UnitTest1
        {
            //------------------BOOLEAN ASSERTS------------------------------------------------------
            [Fact]
            public void BeInexperiencedWhenNew()
            {
                //sut=system under test (naming convention)
                PlayerCharacter sut = new PlayerCharacter();

                Assert.True(sut.IsNoob);
            }

            //------------------STRING ASSERTS------------------------------------------------------
            [Fact]
            public void CalculateFullName()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.FirstName = "Tom";
                sut.LastName = "Hanks";

                Assert.Equal("Tom Hanks", sut.FullName);
            }

            [Fact]
            public void HaveFullNameStartingWithFirstName()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.FirstName = "Tom";
                sut.LastName = "Hanks";

                Assert.StartsWith("Tom", sut.FullName);
            }

            [Fact]
            public void HaveFullNameEndingWithLastName()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.LastName = "Hanks";

                Assert.EndsWith("Hanks", sut.FullName);
            }

            [Fact]
            public void CalculateFullName_IgnoreCaseAssertExample()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.FirstName = "TOM";
                sut.LastName = "HANKS";

                Assert.Equal("Tom Hanks", sut.FullName, ignoreCase: true);
            }

            [Fact]
            public void CalculateFullName_SubstringAssertExample()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.FirstName = "Tom";
                sut.LastName = "Hanks";

                Assert.Contains("om Ha", sut.FullName);
            }

            [Fact]
            public void CalculateFullNameWithTitleCase()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.FirstName = "Tom";
                sut.LastName = "Hanks";

                Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);//uppercase first letter for first and last name
            }

            //------------------NUMERIC VALUES ASSERTS------------------------------------------------------
            [Fact]
            public void StartWithDefaultHealth()
            {
                PlayerCharacter sut = new PlayerCharacter();

                Assert.Equal(100, sut.Health);
            }

            [Fact]
            public void StartWithDefaultHealth_NotEqualExample()
            {
                PlayerCharacter sut = new PlayerCharacter();

                Assert.NotEqual(0, sut.Health);
            }

            [Fact]
            public void IncreaseHealthAfterSleeping()
            {
                PlayerCharacter sut = new PlayerCharacter();

                sut.Sleep();//Expect increase between 1 to 100 inclusive (randomly).since initial health=100,s0 100+random value

                //Assert.True(sut.Health >= 101 && sut.Health <= 200);
                //or
                Assert.InRange<int>(sut.Health, 101, 200);//<int> not necessary because compiler can infer type
            }
        }
    }
}
