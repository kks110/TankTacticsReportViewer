namespace TankTacticsReportViewer.Models;

using System;
using System.Collections.Generic;

public class Game
{
    public int max_x { get; set; }
    public int max_y { get; set; }
    public bool first_blood { get; set; }
}

public class City
{
    public int x { get; set; }
    public int y { get; set; }
    public string? player { get; set; }
}

public class EnergyCell
{
    public int x { get; set; }
    public int y { get; set; }
}

public class PeaceVote
{
    public String player { get; set; }
    public DateTime created_at { get; set; }
}

public class Player
{
    public string name { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int energy { get; set; }
    public int hp { get; set; }
    public int range { get; set; }
    public DateTime? disabled_until { get; set; }
    public int? shot_count { get; set; }
    public DateTime? shot_created_at { get; set; }
    
    public bool isDead()
    {
        return hp <= 0;
    }

    public bool isDisabled()
    {
        return disabled_until != null;
    }
}

public class BattleReport
{
    public DateTime timestamp { get; set; }
    public string command_run { get; set; }
    public string player_name { get; set; }
    public int? amount { get; set; }
    public string? target_name { get; set; }
    public Game game { get; set; }
    public EnergyCell? energy_cell { get; set; }
    public List<City> cities { get; set; }
    public List<PeaceVote> peace_votes { get; set; }
    public List<Player> players { get; set; }
}