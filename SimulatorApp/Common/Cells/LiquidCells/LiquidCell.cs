using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public abstract class LiquidCell : Cell
{
    public LiquidCell(int x, int y) : base(x, y)
    {

    }

    public void ExtinguishFire(CellularAutomata automata)
    {
        Cell c;
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                if (x == X && y == Y) continue;
                c = automata.GetCell(x, y);
                if (c != null && (c.GetType() == typeof(FireCell) || c.GetType() == typeof(FlameCell)))
                {
                    automata.SetCellAs(typeof(SteamCell), x, y);
                    automata.SetCellAs(typeof(SteamCell), X, Y);
                }
            }
        }
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;
        hasBeenUpdated = true;

        Cell c;

        AddToYVel(Settings.Gravity);

        // down
        for (int i = 1; i <= yVel; i++)
        {
            c = automata.GetCell(X, Y + 1);
            if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) &&
                (c.GetType() == typeof(AirCell) ||
                (GetType() != typeof(OilCell) && c.GetType() == typeof(OilCell)) ||
                c.GetType().IsSubclassOf(typeof(GasCell))))
            {
                automata.SwapCells(c.X, c.Y, X, Y);
                xVel = yVel;
                if (i == (int)yVel)
                {
                    return;
                }
                continue;
            }
        }

        // slides
        int side = Rand.Bool() ? 1 : -1;
        for (int i = 1; i <= yVel / 2 + 1; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                side = -side;
                c = automata.GetCell(X + side, Y + 1);
                if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) &&
                    (c.GetType() == typeof(AirCell) ||
                    (GetType() != typeof(OilCell) && c.GetType() == typeof(OilCell)) ||
                    c.GetType().IsSubclassOf(typeof(GasCell))))
                {
                    automata.SwapCells(c.X, c.Y, X, Y);
                    xVel = side * (yVel + 3);
                    if (i == (int)yVel)
                    {
                        yVel = Settings.MaxVelocityV / 2;
                        return;
                    }
                    continue;
                }
            }
        }

        // horizontal
        for (int i = 0; i < 2; i++)
        {
            for (int j = 1; j <= Math.Abs(xVel) + 1; j++)
            {
                c = automata.GetCell(X + side, Y);
                if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) &&
                    (c.GetType() == typeof(AirCell) ||
                    (GetType() != typeof(OilCell) && c.GetType() == typeof(OilCell)) ||
                    c.GetType().IsSubclassOf(typeof(GasCell))))
                {
                    automata.SwapCells(c.X, c.Y, X, Y);
                    AddToXVel(-side * Settings.LiquidSpeed);
                    c = automata.GetCell(X + side, Y + 1);
                    if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) &&
                        (c.GetType() == typeof(AirCell) ||
                        (GetType() != typeof(OilCell) && c.GetType() == typeof(OilCell)) ||
                        c.GetType().IsSubclassOf(typeof(GasCell))))
                    {
                        automata.SwapCells(c.X, c.Y, X, Y);
                        AddToYVel(Settings.Gravity * 0.5f);
                        return;
                    }
                    if (j == Math.Abs(xVel) + 1)
                    {
                        return;
                    }
                    continue;
                }
                break;
            }
            side = -side;
        }
        yVel = 1;
        xVel = 0;
    }
}
