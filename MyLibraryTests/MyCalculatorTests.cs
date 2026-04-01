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

        // 可以使用参数定义准备数据和预期结果
        // 当定义参数的情况，需要使用[Theory]标签；使用InlineData设置传入的参数，可以设置多组
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
