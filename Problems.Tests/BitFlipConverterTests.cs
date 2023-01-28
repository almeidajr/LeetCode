namespace Problems.Tests;

public class BitFlipConverterTests
{
    [Theory]
    [InlineData(0b1010, 0b0111, 3)]
    [InlineData(0b0011, 0b0100, 3)]
    [InlineData(0b0100, 0b0101, 1)]
    [InlineData(0b0111, 0b0111, 0)]
    [InlineData(0b1100, 0b1111, 2)]
    public void MinBitFlips_WhenCalled_ShouldReturnCorrectNumberOfFlips(int start, int goal, int expected)
    {
        // Act
        var actual = BitFlipConverter.MinBitFlips(start, goal);

        // Assert
        actual.Should().Be(expected);
    }
}