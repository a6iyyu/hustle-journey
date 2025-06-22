using UnityEngine;

namespace Assets.App.Scripts.Interfaces
{
    public interface ILocationController
    {
        int CurrentLocationId { get; }
        NarrativeRenderer NarrativeRenderer { get; }
        public void RenderLocation();
    }
}