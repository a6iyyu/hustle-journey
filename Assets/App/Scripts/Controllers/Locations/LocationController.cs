using System.Collections.Generic;
using UnityEngine;

public abstract class LocationController : MonoBehaviour, ILocationController
{
    protected NarrativeRenderer narrativeRenderer { get; set; }
    protected NavigationManager navigationManager { get; private set; }
    protected virtual void Start()
    {
        narrativeRenderer = FindFirstObjectByType<NarrativeRenderer>();
        if (narrativeRenderer == null)
        {
            Debug.LogError("NarrativeRenderer not found in the scene.");
        }
        navigationManager = FindFirstObjectByType<NavigationManager>();
        if (navigationManager == null)
        {
            Debug.LogError("NavigationManager not found in the scene.");
        }
    }
    public abstract void RenderLocation();
}