using SimulatorApp.Application;

namespace SimulatorApp.Common.Cells.LiquidCells;

public abstract class LiquidCell : Cell
{
    public LiquidCell(int x, int y) : base(x, y)
    {

    }

    public override void Update(CellularAutomata automata)
    {
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
