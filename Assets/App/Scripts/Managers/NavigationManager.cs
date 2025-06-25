using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    private List<LocationController> locationControllers;
    private ILocationController currentLocation;

    private void Start()
    {
        locationControllers = new List<LocationController>(GetComponentsInChildren<LocationController>());
        Debug.Log($"Found {locationControllers.Count} location controllers in the scene.");
    }

    public void NavigateTo(string locationName)
    {
        var target = locationControllers.Find(match: lc => lc.name == locationName);
        if (target != null)
        {
            currentLocation = target;
            target.RenderLocation();
        }
        else
        {
            Debug.LogError($"Location {locationName} not found");
        }
    }
}