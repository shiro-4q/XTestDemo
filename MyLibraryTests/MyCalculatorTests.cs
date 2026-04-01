using MyLibrary;

namespace MyLibraryTests
{
    public class MyCalculatorTests
    {
        [Fact]
        public void Add_Test()
        {
            // Arrange
            int i = 1;
            int j = 2;
            // Act
            MyCalculator sut = new MyCalculator();
            var actualResult = sut.Add(i, j);
            // Assert
            var expectedResult = 3;
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 4, 6)]
        public void Add_TestV2(int i, int j, int expectedResult)
        {
            // Act
            MyCalculator sut = new MyCalculator();
            var actualResult = sut.Add(i, j);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
