using System;
using System.Collections.Generic;
using Assets.App.Scripts.Enums;

public class Location
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string[] Trails { get; private set; }
    public LocationType Type { get; private set; }
    public List<int> AdjecantLocationIds { get; private set; }
    public Location(int id, string name, string[] trails, LocationType type, List<int> adjecantLocationIds)
    {
        Id = id;
        Name = name;
        Trails = trails;
        Type = type;
        AdjecantLocationIds = adjecantLocationIds ?? new List<int>();
    }
}