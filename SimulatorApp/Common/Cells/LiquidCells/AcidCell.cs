using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class AcidCell : LiquidCell
{
    public AcidCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Acid);
    }

    public void ProduceVapor(CellularAutomata automata)
    {
        var produce = Rand.Probability(5);
        if (produce)
        {
            Cell c = automata.GetCell(X, Y - 1);
            if (c != null && c.GetType() == typeof(AirCell))
            {
                automata.SetCellAs(typeof(AcidVaporCell), X, Y - 1);
            }
        }
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

                if (c != null && c.Digestable)
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

        ProduceVapor(automata);

        base.Update(automata);
    }
}
