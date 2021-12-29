namespace SimulatorApp.Common.Cells.LiquidCells;

public class WaterCell : LiquidCell
{
    public WaterCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Water);
    }
}
