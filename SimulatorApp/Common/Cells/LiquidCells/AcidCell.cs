using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class AcidCell : LiquidCell
{
    private Type[] vulnerableCells;

    public AcidCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Acid);
        vulnerableCells = new Type[] { typeof(SteelCell), typeof(WoodCell), typeof(LeavesCell) };
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;
        SetColor(Colors.AcidDependingOnDepth(Y));

        // acid
        Cell c;
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                c = automata.GetCell(x, y);
                if (c != null && c.GetType() == typeof(WaterCell))
                {

                }

                if (c != null && vulnerableCells.Contains(c.GetType()))
                {
                    var acid = Rand.Probability(2);
                    if (acid)
                    {
                        automata.Cells[x, y] = new AirCell(x, y);
                    }
                }
            }
        }

        base.Update(automata);
    }
}
