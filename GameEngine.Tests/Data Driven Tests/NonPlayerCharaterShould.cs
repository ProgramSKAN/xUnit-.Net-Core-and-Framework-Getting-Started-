using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests.Data_Driven_Tests
{
    public class NonPlayerCharaterShould 
    {


        /*[Fact]
        public void TakeZeroDamage()
        {
            _sut.TakeDamage(0);

            Assert.Equal(100, _sut.Health);
        }
        [Fact]
        public void TakeSmallDamage()
        {
            _sut.TakeDamage(1);

            Assert.Equal(99, _sut.Health);
        }
        [Fact]
        public void TakeMediumDamage()
        {
            _sut.TakeDamage(50);

            Assert.Equal(50, _sut.Health);
        }
        [Fact]
        public void TakeLargeDamage()
        {
            _sut.TakeDamage(101);

            Assert.Equal(1, _sut.Health);
        }


        OR
    */

        //---------------------DATA DRIVEN TEST------------------------
        [Theory]//tell xUnit that this test method should execute multiple times with test data
        [InlineData(0,100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamage(int damage,int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        //OR
        //-------------USING INTERNAL SHARING DATA ACROSS TESTS----------------------------
        [Theory]
        //[MemberData("TestData",MemberType =typeof(InternalHealthDamageTestData))]//or
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamage1(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        //OR
        //-----------USE EXTERNAL DATA FROM CSV FILE ACROSS TESTS--------------
        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamage2(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        //OR
        //--------------USE CUSTOM DATA SOURCE ATTRIBUTE TO USE ACROSS TESTS---------
        [Theory]
        [CustomData_HealthDamageData]
        public void TakeDamage3(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

    }
}
