using SFML.Graphics;

namespace SimulatorApp.Common.Utils;

public static class Colors
{
    public static Color Grid
    {
        get => Settings.LightMode ? Color.Black : Color.White;
    }

    public static Color Background
    {
        get => Settings.LightMode ? new Color(198, 214, 244) : new Color(5, 10, 15);
    }

    public static Color Air
    {
        get => new Color(0, 0, 0, 0);
    }

    public static Color Sand
    {
        get
        {
            byte c = Rand.Byte(220);
            return new Color(c, (byte)(c - 55), (byte)(c - 190));
        }
    }

    public static Color Water
    {
        get => new Color(0, 180, 255, 120);
    }

    public static Color WaterDependingOnDepth(int d)
    {
        float x = (float)d / (float)Settings.Y;
        return new Color(0, (byte)(255 - 150 * x), (byte)(255 - 255 * x), 120);
    }

    public static Color Rock
    {
        get
        {
            byte c = Rand.Byte(50, 120);
            return new Color(c, c, c);
        }
    }

    public static Color Wood
    {
        get
        {
            byte c = Rand.Byte(50, 120);
            return new Color(c, (byte)(c / 2), 0);
        }
    }

    public static Color Leaves
    {
        get
        {
            byte c = Rand.Byte(50, 120);
            return new Color(0, c, 0);
        }
    }

    public static Color Smoke
    {
        get
        {
            byte c = Rand.Byte(100, 150);
            return new Color(c, c, c);
        }
    }

    public static Color Steam
    {
        get
        {
            byte c = Rand.Byte(180, 240);
            return new Color(c, c, c);
        }
    }

    public static Color Flame
    {
        get
        {
            byte c = Rand.Byte();
            return new Color(255, c, 130);
        }
    }

    public static Color Fire
    {
        get
        {
            byte c = Rand.Byte();
            return new Color(255, c, 0);
        }
    }

    public static Color Acid
    {
        get
        {
            byte c = Rand.Byte(180, 230);
            return new Color(c, 255, c, 120);
        }
    }

    public static Color AcidDependingOnDepth(int d)
    {
        float x = (float)d / (float)Settings.Y;
        return new Color(0, (byte)(255 - 150 * x), 0, 120);
    }

    public static Color Steel
    {
        get
        {
            byte c = Rand.Byte(200, 210);
            return new Color(c, c, c);
        }
    }
}
