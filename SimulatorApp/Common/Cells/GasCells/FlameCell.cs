using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class FlameCell : GasCell
{
    public FlameCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Flame);
        life = Rand.Int(1, 20);
    }

    public void Ignite(CellularAutomata automata)
    {
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                Cell c = automata.GetCell(x, y);
                if (c != null && c.Flamable)
                {
                    var lightUp = Rand.Probability(1);
                    if (lightUp)
                    {
                        automata.SetCellAs(typeof(FireCell), x, y);
                        life++;
                    }
                    if (c.GetType() == typeof(OilCell) || c.GetType() == typeof(GunPowderCell))
                    {
                        lightUp = Rand.Probability(15);
                        if (lightUp)
                        {
                            automata.SetCellAs(typeof(FireCell), x, y);
                        }
                    }
                }
            }
        }
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        DrainLife(automata);

        Ignite(automata);

        base.Update(automata);
    }
}
