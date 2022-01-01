namespace SimulatorApp.Common.Utils;

public static class Rand
{
    private static Random _rnd = new Random();

    public static byte Byte(byte min = 0, byte max = 255)
    {
        if (min < 0 || max < 0 || min > 255 || max > 255)
        {
            throw new ArgumentOutOfRangeException();
        }
        return (byte)_rnd.Next(min, max + 1);
    }

    public static int Int(int min = -1000, int max = 1000)
    {
        return _rnd.Next(min, max + 1);
    }

    public static bool Bool()
    {
        return _rnd.Next(2) == 0;
    }

    public static bool Probability(int percents)
    {
        return _rnd.Next(101) <= percents;
    }
}
