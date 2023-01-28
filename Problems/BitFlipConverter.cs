// DESCRIPTION: https://leetcode.com/problems/minimum-bit-flips-to-convert-number/

namespace Problems;

public static class BitFlipConverter
{
    public static int MinBitFlips(int start, int goal)
    {
        var flip = start ^ goal;
        return Convert.ToString(flip, 2).Count(c => c == '1');
    }
}