using SimulatorApp.Common.Cells;

namespace SimulatorApp.Application;

#pragma warning disable CS8603
public class CellFactory
{
    public Cell CreateCell(Type cellType, int x, int y)
    {
        switch (cellType.Name)
        {
            case nameof(AirCell): return new AirCell(x, y);
            case nameof(SandCell): return new SandCell(x, y);
            case nameof(WaterCell): return new WaterCell(x, y);
            case nameof(RockCell): return new RockCell(x, y);
            default: return null;
        }
    }
}
