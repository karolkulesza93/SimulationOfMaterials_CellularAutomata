using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class FireCell : DynamicSolidCell
{
    public FireCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Fire);
        life = Rand.Int(30, 150);
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
                    var lightUp = Rand.Probability(0.5f);
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

    public void ProduceSmoke(CellularAutomata automata)
    {
        var produce = Rand.Probability(10);
        if (produce)
        {
            Cell c = automata.GetCell(X, Y - 1);
            if (c != null && c.GetType() == typeof(AirCell) && c.GetType() != typeof(FireCell))
            {
                automata.SetCellAs(typeof(SmokeCell), X, Y - 1);
            }
        }
    }

    public void ProduceFlame(CellularAutomata automata)
    {
        var produce = Rand.Probability(50);
        if (produce)
        {
            Cell c = automata.GetCell(X, Y - 1);
            if (c != null && (c.Flamable || c.GetType() == typeof(AirCell)) && c.GetType() != typeof(FireCell))
            {
                automata.SetCellAs(typeof(FlameCell), X, Y - 1);
            }
        }
    }


    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        SetColor(Colors.Fire);

        DrainLife(automata);

        Ignite(automata);

        ProduceSmoke(automata);

        ProduceFlame(automata);

        base.Update(automata);
    }
}
