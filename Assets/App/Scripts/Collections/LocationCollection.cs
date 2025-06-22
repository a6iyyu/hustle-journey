using System.Collections.Generic;
using UnityEngine;

namespace Assets.App.Scripts.Collections
{
    public class LocationCollection : MonoBehaviour
    {
        public Dictionary<int, Location> locations { get; private set; }
        public ScriptableObject[] dataLocations;

        void Awake()
        {
            locations = new Dictionary<int, Location>();
            foreach (var item in dataLocations)
            {
                if (item is LocationSO locationSO)
                {
                    var location = new Location(
                        locationSO.Id,
                        locationSO.Name,
                        locationSO.Trails,
                        locationSO.Type,
                        locationSO.AdjecantLocationIds
                    );
                    locations.Add(location.Id, location);
                }
                else
                {
                    Debug.LogError($"Item {item.name} is not a LocationSO.");
                }
            }
        }
    }
}