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
                if (i == (int)vVel)
                {
                    automata.SwapCells(p.X, p.Y, X, Y);
                    return;
                }
                continue;
            }
            vVel = 1;
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
                hVel = -1;
                return;
            }
            // slide down-right
            p = automata.GetCell(X + 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel = 1;
                return;
            }
            // move left
            for (int i = -1; i >= hVel; i--)
            {
                p = automata.GetCell(X, Y + (int)hVel);
                if (p != null && (p.GetType() == typeof(AirCell)))
                {
                    if (i == (int)vVel)
                    {
                        automata.SwapCells(p.X, p.Y, X, Y);
                        return;
                    }
                    continue;
                }
            }



            p = automata.GetCell(X - 1, Y);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel -= Settings.LiquidSpeed;
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
                hVel = 1;
                return;
            }
            // slide down-left
            p = automata.GetCell(X - 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel = -1;
                return;
            }
            //move right
            for (int i = 0; i <= hVel; i++)
            {

            }


            p = automata.GetCell(X + 1, Y);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                hVel += Settings.LiquidSpeed;
                return;
            }
        }
        vVel = 1;
    }
}
