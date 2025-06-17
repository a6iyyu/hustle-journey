using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using UnityEngine;

public class NarrativeRenderer : MonoBehaviour
{
    public Transform narrativePanel; // Assign: NarrativePanel
    public GameObject sectionPrefab; // Assign: NarrativeSection prefab

    public void Clear()
    {
        foreach (Transform child in narrativePanel)
        {
            Destroy(child.gameObject);
        }
    }

    public void Append(NarrativeSectionData section)
    {
        var go = Instantiate(sectionPrefab, narrativePanel);
        var sectionUI = go.GetComponent<NarrativeSectionUI>();
        sectionUI.Set(section.Text, section.Actions);
    }

    public void Render(List<NarrativeSectionData> sections)
    {
        Clear();
        foreach (var section in sections)
        {
            Append(section);
        }

        // ScrollToBottom(); // optional
    }
}
