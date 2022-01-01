using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public abstract class GasCell : Cell
{
    public GasCell(int x, int y) : base(x, y)
    {

    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;
        hasBeenUpdated = true;

        yVel = -1;

        Cell c;

        // up
        c = automata.GetCell(X, Y - 1);
        if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) && (c.GetType() == typeof(AirCell)))
        {
            automata.SwapCells(c.X, c.Y, X, Y);
        }

        // floats
        int side = Rand.Bool() ? 1 : -1;
        for (int i = 0; i < 2; i++)
        {
            side = -side;
            c = automata.GetCell(X + side, Y - 1);
            if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) && (c.GetType() == typeof(AirCell)))
            {
                automata.SwapCells(c.X, c.Y, X, Y);
                return;
            }
        }
    }
}
