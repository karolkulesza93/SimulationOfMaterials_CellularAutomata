using SimulatorApp.Application;

namespace SimulatorApp.Common.Cells;

public class FireCell : DynamicSolidCell
{
    public FireCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Fire);
    }

    public override void Update(CellularAutomata automata)
    {
        base.Update(automata);
        SetColor(Colors.Fire);

        // TODO
    }
}
