using System;
using System.Collections.Generic;
using Assets.App.Scripts.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationSO", menuName = "LocationSO", order = 0)]
public class LocationSO : ScriptableObject
{
    public int Id;
    public string Name;
    public string[] Trails;
    public LocationType Type;
    public List<int> AdjecantLocationIds;
}