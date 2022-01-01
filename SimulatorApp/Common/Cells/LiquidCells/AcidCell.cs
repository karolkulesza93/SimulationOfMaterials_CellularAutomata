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

    public void Devour(CellularAutomata automata)
    {
        Cell c;
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                if (x == X && y == Y) continue;
                c = automata.GetCell(x, y);
                if (c != null && c.GetType() == typeof(WaterCell))
                {
                    var neutralize = Rand.Probability(20);
                    if (neutralize)
                    {
                        automata.SetCellAs(typeof(WaterCell), X, Y);
                    }
                }

                if (c != null && vulnerableCells.Contains(c.GetType()))
                {
                    var acid = Rand.Probability(2);
                    if (acid)
                    {
                        automata.SetCellAs(typeof(SmokeCell), x, y);
                        var dead = Rand.Probability(5);
                        if (dead)
                        {
                            automata.SetCellAs(typeof(SmokeCell), X, Y);
                        }
                    }
                }
            }
        }
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;
        SetColor(Colors.AcidDependingOnDepth(Y));

        ExtinguishFire(automata);

        Devour(automata);

        base.Update(automata);
    }
}
