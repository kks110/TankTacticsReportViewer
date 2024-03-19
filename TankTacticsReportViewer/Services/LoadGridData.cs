using TankTacticsReportViewer.Models;

namespace TankTacticsReportViewer.Services;

public class LoadGridData
{
    public Dictionary<(int, int), object> grid = new Dictionary<(int, int), object>();
    
    public LoadGridData(BattleReport battleReport) {

        for (int i = 0; i < battleReport.players.Count(); i++)
        {
            grid.Add((battleReport.players[i].x, battleReport.players[i].y), battleReport.players[i]);
        }
        for (int i = 0; i < battleReport.cities.Count(); i++)
        {
            grid.Add((battleReport.cities[i].x, battleReport.cities[i].y), battleReport.cities[i]);
        }

        if (battleReport.energy_cell != null)
        {
            grid.Add((battleReport.energy_cell.x, battleReport.energy_cell.y), battleReport.energy_cell);
        }
    }
}
