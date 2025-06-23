using UnityEngine;
using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using Assets.App.UIElements.NarrativeSection.DTOs;
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
                    Text = new TextDTO("Living Room", TextStyle.Breadcrumb),
                },
                new NarrativeSectionData
                {
                    Text = new TextDTO("You are in a spacious living room with a large sofa, a coffee table, and a fireplace. The walls are adorned with paintings and family photos."),
                },
                new ()
                {
                    Text = new TextDTO("The room is warmly lit, and you can hear the crackling of the fire in the fireplace."),
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