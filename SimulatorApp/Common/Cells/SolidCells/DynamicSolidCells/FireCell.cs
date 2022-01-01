using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class FireCell : DynamicSolidCell
{
    public FireCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Fire);
        life = Rand.Int(20, 100);
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
    public void ProduceSmokeAndFlame(CellularAutomata automata)
    {
        var produce = Rand.Probability(10);
        if (produce)
        {
            Cell c = automata.GetCell(X, Y - 1);
            if (c != null && c.GetType() == typeof(AirCell))
            {
                var dec = Rand.Bool();
                if (dec)
                {
                    automata.SetCellAs(typeof(FlameCell), X, Y);
                }
                else
                {
                    automata.SetCellAs(typeof(SmokeCell), X, Y);
                }
            }
        }
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        SetColor(Colors.Fire);
        life--;
        if (life <= 0)
        {
            automata.SetCellAs(typeof(AirCell), X, Y);
            return;
        }

        Ignite(automata);

        ProduceSmokeAndFlame(automata);

        base.Update(automata);
    }
}
