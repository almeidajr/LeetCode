// DESCRIPTION: https://leetcode.com/problems/minimum-bit-flips-to-convert-number/

namespace Problems;

public static class BitFlipConverter
{
    public static int MinBitFlips(int start, int goal)
    {
        var flip = start ^ goal;
        var count = 0;
        while (flip != 0)
        {
            flip &= flip - 1;
            count++;
        }

        return count;
    }
}