namespace Problems.Tests;

public class TemperatureConverterTests
{
    [Fact]
    public void ConvertTemperature_WhenCalled_ShouldReturnArrayLength2()
    {
        // Act
        var actual = TemperatureConverter.ConvertTemperature(0);

        // Assert
        actual.Length.Should().Be(2);
    }

    [Theory]
    [InlineData(36.50, new[] { 309.65, 97.7 })]
    [InlineData(122.11, new[] { 395.26, 251.798 })]
    public void ConvertTemperature_WithCelsiusTemperature_ShouldReturnFahrenheitAndKelvin(
        double celsius,
        double[] expected)
    {
        // Act
        var actual = TemperatureConverter.ConvertTemperature(celsius);

        // Assert
        actual[0].Should().BeApproximately(expected[0], 1e-5);
        actual[1].Should().BeApproximately(expected[1], 1e-5);
    }
}