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

    public static int Int(int min, int max)
    {
        return _rnd.Next(min, max + 1);
    }

    public static int Int(int max)
    {
        return _rnd.Next(max + 1);
    }

    public static bool Bool()
    {
        return _rnd.Next(2) == 0;
    }

    public static bool Probability(float percents)
    {
        if (percents < 0) throw new ArgumentOutOfRangeException();
        if (percents < 1) return _rnd.Next(10000) <= percents * 100;
        return _rnd.Next(101) <= percents;
    }
}
