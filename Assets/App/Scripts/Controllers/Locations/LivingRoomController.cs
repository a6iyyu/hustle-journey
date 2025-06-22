using UnityEngine;
using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
public class LivingRoomController : LocationController
{
    [SerializeField] private BedroomController bedroomController;
    public override void RenderLocation()
    {
        try
        {
            var sectionData = new List<NarrativeSectionData>
            {
                new NarrativeSectionData
                {
                    Text = "Your House > Living Room",
                },
                new NarrativeSectionData
                {
                    Text = "You are in the living room.",
                },
                new ()
                {
                    Text = "Several wooden doors lead to other rooms.",
                    Actions = new List<ActionChoice>
                    {
                        new ()
                        {
                            Label = "Go to Bedroom",
                            OnClick = () => navigationManager.NavigateTo("Bedroom")
                        }
                    }
                }
            };
            narrativeRenderer.Render(sectionData);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}