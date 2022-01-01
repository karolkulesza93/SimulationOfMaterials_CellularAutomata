using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public abstract class DynamicSolidCell : SolidCell
{
    public DynamicSolidCell(int x, int y) : base(x, y)
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
            c = automata.GetCell(X, Y + 1);
            if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) && (c.GetType() == typeof(AirCell) || c.GetType().IsSubclassOf(typeof(LiquidCell))))
            {
                automata.SwapCells(c.X, c.Y, X, Y);
                if (c.GetType().IsSubclassOf(typeof(LiquidCell)))
                {
                    yVel = 1;
                }
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
                if (c != null && !c.GetType().IsSubclassOf(typeof(SolidCell)) && (c.GetType() == typeof(AirCell) || c.GetType().IsSubclassOf(typeof(LiquidCell))))
                {
                    automata.SwapCells(c.X, c.Y, X, Y);
                    if (c.GetType().IsSubclassOf(typeof(LiquidCell)))
                    {
                        yVel = 1;
                    }
                    if (i == (int)yVel)
                    {
                        yVel = Settings.MaxVelocityV / 2;
                        return;
                    }
                    continue;
                }
            }
        }



        yVel = 1;
    }
}
