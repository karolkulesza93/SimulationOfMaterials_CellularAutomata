using SFML.Graphics;

namespace SimulatorApp.Common;

public static class Colors
{
    public static Color Grid
    {
        get => Settings.LightMode ? Color.Black : Color.White;
    }

    public static Color Air
    {
        get => Settings.LightMode ? new Color(198, 214, 244) : new Color(16, 21, 35);
    }
    
    public static Color Sand
    {
        get
        {
            byte c = Rand.Byte(200);
            return new Color(c, (byte)(c - 55), (byte)(c - 200));
        }
    }

    public static Color Water
    {
        get => new Color(0, 180, 255);
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
            byte c = Rand.Byte(30, 100);
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

    public static Color Fire
    {
        get
        {
            byte c = Rand.Byte();
            return new Color(255, c, 100);
        }
    }

    public static Color Flame
    {
        get
        {
            byte c = Rand.Byte();
            return new Color(255, c, 0);
        }
    }
}
