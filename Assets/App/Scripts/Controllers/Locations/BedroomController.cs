using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using Assets.App.UIElements.NarrativeSection.DTOs;
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
                    Text = new TextDTO("Bedroom", TextStyle.Breadcrumb),
                },
                new ()
                {
                    Text = new TextDTO("You are in a cozy bedroom with a large bed, a wardrobe, and a wooden door leading to the living room."),
                },
                new ()
                {
                    Text = new TextDTO("The room is softly lit, and you can hear the faint sound of a clock ticking in the background."),
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