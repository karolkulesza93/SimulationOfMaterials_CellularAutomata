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
            case nameof(FireCell): return new FireCell(x, y);
            case nameof(FlameCell): return new FlameCell(x, y);
            case nameof(WoodCell): return new WoodCell(x, y);
            case nameof(LeavesCell): return new LeavesCell(x, y);
            case nameof(SmokeCell): return new SmokeCell(x, y);
            case nameof(SteamCell): return new SteamCell(x, y);
            case nameof(AcidCell): return new AcidCell(x, y);
            case nameof(SteelCell): return new SteelCell(x, y);
            case nameof(OilCell): return new OilCell(x, y);
            case nameof(GunPowderCell): return new GunPowderCell(x, y);
            case nameof(AcidVaporCell): return new AcidVaporCell(x, y);
            case nameof(SaltCell): return new SaltCell(x, y);
            default: throw new KeyNotFoundException(cellType.Name);
        }
    }
}
