using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;
public class SaltCell : DynamicSolidCell
{
    public SaltCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Salt);
    }

    public void Dissolve(CellularAutomata automata)
    {
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                Cell c = automata.GetCell(x, y);
                if (c != null && c.GetType().IsSubclassOf(typeof(LiquidCell)))
                {
                    var dissolve = Rand.Probability(1);
                    if (dissolve)
                    {
                        automata.SetCellAs(typeof(AirCell), X, Y);
                    }
                }
            }
        }
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        Dissolve(automata);

        base.Update(automata);
    }
}
