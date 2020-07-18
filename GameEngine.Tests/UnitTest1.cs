using System;
using Xunit;

/*to create xunit test project using command line,open cmd in solution directory 
 * >md GameEngine.Tests
 * >cd GameEngine.Tests
 * >dotnet new xunit
 * >dir
 * >dotnet add reference ../GameEngine/GameEngine.csproj
 * >cd ..
 * >dotnet sln add GameEngine.Tests\GameEngine.Tests.csproj
 * 
 * 
 * 
 * 
 * To test the unittest, goto sulution directory
 * >cd GameEngine.Tests
 * >dotnet test
 * 
 * 
 * 
 * To run unittests with specific trait instead of all tests
 * >dotnet test --filter Category=Enemy
 * >dotnet test --filter Category=Boss
 * or
 * >dotnet test --filter "Category=Enemy|Category=Boss"
 * 
 * 
 * For dotnet test options help
 * >dotnet test /?
 * 
 * For normal verbosity
 * >dotnet test -v n
 * 
 * To view console message after printing using ITestOutputHelper
 * >dotnet test --filter Category=Boss --logger:trx
 * this will create a new file under TestResults folder that has test output message
 * 
 * 
 * 
 */
namespace GameEngine.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
