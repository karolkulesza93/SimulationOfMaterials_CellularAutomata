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

        Cell p;

        AddToVVel(Settings.Gravity);

        // move down
        for (int i = 1; i <= vVel; i++)
        {
            p = automata.GetCell(X, Y + i);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                if (i == (int)vVel)
                {
                    return;
                }
                continue;
            }
        }

        // slides
        bool side = Rand.Bool();
        if (!side)
        {
            // slide down-left
            p = automata.GetCell(X - 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel = -vVel;
                return;
            }
            // slide down-right
            p = automata.GetCell(X + 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel = vVel;
                return;
            }

        }
        else
        {
            // slide down-right
            p = automata.GetCell(X + 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel = vVel;
                return;
            }
            // slide down-left
            p = automata.GetCell(X - 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel = -vVel;
                return;
            }

        }

        // multiple horizontal movment
        if (hVel < 0)
        {

        }
        else if (hVel > 0)
        {

        }

        // horizontal movment
        if (!side)
        {
            // move left
            p = automata.GetCell(X - 1, Y);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel -= Settings.LiquidSpeed;
                return;
            }
            hVel = 0;
        }
        else
        {
            //move right
            p = automata.GetCell(X + 1, Y);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel += Settings.LiquidSpeed;
                return;
            }
            hVel = 0;
        }

        vVel = 1;
    }
}
