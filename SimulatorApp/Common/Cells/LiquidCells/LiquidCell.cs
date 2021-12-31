using SimulatorApp.Application;

namespace SimulatorApp.Common.Cells;

public abstract class LiquidCell : Cell
{
    public LiquidCell(int x, int y) : base(x, y)
    {

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
            c = automata.GetCell(X, Y + i);
            if (c != null && (c.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(c.X, c.Y, X, Y);
                if (i == (int)yVel)
                {
                    return;
                }
                continue;
            }
        }

        // slides
        int side = Rand.Bool() ? 1 : -1;
        for (int i = 0; i < 2; i++)
        {
            side = -side;
            c = automata.GetCell(X + side, Y + 1);
            if (c != null && (c.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(c.X, c.Y, X, Y);
                AddToYVel(Settings.Gravity * 0.5f);
                xVel = side * yVel;
                return;
            }
        }

        // horizontal
        for (int i = 0; i < 2; i++)
        {
            for (int j = 1; j <= Math.Abs(xVel) + 1; j++)
            {
                xVel += side * Settings.LiquidSpeed;
                c = automata.GetCell(X + side * j, Y);
                if (c != null && (c.GetType() == typeof(AirCell)))
                {
                    automata.SwapCells(c.X, c.Y, X, Y);
                    if (j == Math.Abs(xVel) + 1)
                    {
                        return;
                    }
                    c = automata.GetCell(X + side, Y + 1);
                    if (c != null && (c.GetType() == typeof(AirCell)))
                    {
                        automata.SwapCells(c.X, c.Y, X, Y);
                        AddToYVel(Settings.Gravity * 0.5f);
                        xVel = side * yVel;
                        return;
                    }
                    continue;
                }
            }
            side = -side;
        }

        yVel = 1;
        xVel = 0;
    }
}
