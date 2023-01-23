namespace Problems.Tests;

public class ChessboardKnightProbabilityTests
{
    [Theory]
    [InlineData(3, 2, 0, 0, 0.0625)]
    [InlineData(1, 0, 0, 0, 1)]
    [InlineData(3, 3, 0, 0, 0.01562)]
    [InlineData(8, 30, 6, 4, 0.00019)]
    public void KnightProbability_WhenCalled_ReturnsExpectedProbability(
        int n,
        int k,
        int row,
        int column,
        double expected)
    {
        // Arrange
        var calculator = new ChessboardKnightProbability();

        // Act
        var actualProbability = calculator.KnightProbability(n, k, row, column);

        // Assert
        actualProbability.Should().BeApproximately(expected, 0.0001);
    }
}