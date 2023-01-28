// DESCRIPTION: https://leetcode.com/problems/convert-the-temperature/

namespace Problems;

public static class TemperatureConverter
{
    public static double[] ConvertTemperature(double celsius)
    {
        return new[] { CelsiusToKelvin(celsius), CelsiusToFahrenheit(celsius) };
    }

    private static double CelsiusToKelvin(double celsius)
    {
        return celsius + 273.15;
    }

    private static double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 1.8 + 32;
    }
}