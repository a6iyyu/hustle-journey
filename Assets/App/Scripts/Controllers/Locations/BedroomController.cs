using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using UnityEngine;

public class BedroomController : LocationController
{
    [SerializeField] LivingRoomController livingRoomController;
    private List<NarrativeSectionData> sectionData;
    // private void Start()
    // {
    //     NarrativeRenderer = FindFirstObjectByType<NarrativeRenderer>();
    // }
    void Awake()
    {
        try
        {
            sectionData = new List<NarrativeSectionData>{

                new ()
                {
                    Text = "Your House > Bedroom",
                },
                new ()
                {
                    Text = "You are in the bedroom.",
                },
                new ()
                {
                    Text = "Behind the wooden door, you can go to the living room.",
                    Actions = new List<ActionChoice>
                    {
                        new()
                        {
                            Label = "Go to Living Room",
                            OnClick = () => navigationManager.NavigateTo("LivingRoom")
                        }
                    }
                },
            };
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    public override void RenderLocation()
    {
        if (narrativeRenderer == null)
        {
            Debug.LogError("NarrativeRenderer is not set. Cannot render location.");
            return;
        }
        narrativeRenderer.Render(sectionData);
    }
}