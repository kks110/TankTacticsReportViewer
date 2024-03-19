using System.Text.Json;
using TankTacticsReportViewer.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace TankTacticsReportViewer.Services;

public class BattleReportLoader
{
    public async Task<List<BattleReport>> LoadFile(InputFileChangeEventArgs e)
    {
        List<BattleReport> reports = new();
        foreach (var file in e.GetMultipleFiles(1))
        {
            try
            {
                string fileContent;
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    fileContent = await streamReader.ReadToEndAsync();
                }

                var lines = fileContent.Split("\n");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    BattleReport report = JsonSerializer.Deserialize<BattleReport>(lines[i]);
                    reports.Add(report);
                }
            }
            catch (Exception ex)
            {
            }
        }

        reports = reports.OrderBy(x => x.timestamp).ToList();
        return reports;
    }
}