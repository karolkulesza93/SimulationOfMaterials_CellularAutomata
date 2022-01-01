using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class WaterCell : LiquidCell
{
    public WaterCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Water);
    }

    public override void Update(CellularAutomata automata)
    {
        SetColor(Colors.WaterDependingOnDepth(Y));

        // extinnguish fire
        Cell c;
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                if (x == X && y == Y) continue;
                c = automata.GetCell(x, y);
                if (c != null && (c.GetType() == typeof(FireCell) || c.GetType() == typeof(FlameCell)))
                {
                    automata.Cells[X, Y] = new SteamCell(x, y);
                }
            }
        }

        base.Update(automata);
    }
}
