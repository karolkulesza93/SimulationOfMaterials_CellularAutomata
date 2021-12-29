using SimulatorApp.Application;

namespace SimulatorApp.Common.Cells.SolidCells.DynamicSolidCells;

public abstract class DynamicSolidCell : SolidCell
{
    public DynamicSolidCell(int x, int y) : base(x, y)
    {

    }

    public override void Update(CellularAutomata automata)
    {
        Cell p;

        AddToVVel(Settings.Gravity);

        // move down
        for (int i = 1; i <= vVel; i++)
        {
            p = automata.GetCell(X, Y + (int)vVel);
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
                return;
            }
            // slide down-right
            p = automata.GetCell(X + 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
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
                return;
            }
            // slide down-left
            p = automata.GetCell(X - 1, Y + 1);
            if (p != null && (p.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(p.X, p.Y, X, Y);
                AddToVVel(Settings.Gravity);
                return;
            }
        }
        vVel = 1;
    }
}
