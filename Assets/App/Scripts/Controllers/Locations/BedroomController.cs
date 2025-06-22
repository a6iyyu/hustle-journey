using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using Assets.App.Scripts.Interfaces;
using Assets.App.Scripts.Singletons;
using UnityEngine;

public class BedroomController : MonoBehaviour, ILocationController{
    public int CurrentLocationId { get; private set; }

    public NarrativeRenderer NarrativeRenderer { get; private set; }


    private void Start()
    {
        CurrentLocationId = 0;
        NarrativeRenderer = FindFirstObjectByType<NarrativeRenderer>();
    }
    public void RenderLocation()
    {
        Location location;
        try
        {
            location = Indexer.Instance.Locations[CurrentLocationId];
            if (location == null)
            {
                Debug.LogError($"Location with ID {CurrentLocationId} not found.");
                return;
            }

            List<NarrativeSectionData> sectionData = new List<NarrativeSectionData>()
            {
                new() {
                    Text = location.Trails != null && location.Trails.Length > 0
                        ? string.Join(" > ", location.Trails)
                        : "No trails available."
                },
                new() {
                    Text=location.Name
                },
            };

            NarrativeRenderer.Render(sectionData);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}