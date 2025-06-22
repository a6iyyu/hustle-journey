using System.Collections;
using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeRenderer : MonoBehaviour
{
    public Transform narrativePanel; // Assign: NarrativePanel
    public GameObject sectionPrefab; // Assign: NarrativeSection prefab


    /// <summary>
    /// Clears all narrative sections from the narrative panel by destroying all its children.
    /// </summary>
    /// 
    public void Clear()
    {
        foreach (Transform child in narrativePanel)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Appends a new narrative section to the narrative panel by instantiating a new
    /// section prefab and setting its text and actions.
    /// </summary>
    /// <param name="section">The NarrativeSectionData object containing the text and actions to display.</param>

    public void Append(NarrativeSectionData section)
    {
        var go = Instantiate(sectionPrefab, narrativePanel);
        var sectionUI = go.GetComponent<NarrativeSectionUI>();
        sectionUI.Set(section.Text, section.Actions);
        // RectTransform rectTransform = GetComponent<RectTransform>();
        // LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        StartCoroutine(RebuildLayout());
    }
    IEnumerator RebuildLayout()
    {
        yield return new WaitForEndOfFrame();
        RectTransform rectTransform = GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }

    /// <summary>
    /// Renders the given list of narrative sections by clearing the existing content
    /// and appending each section to the narrative panel.
    /// </summary>
    /// <param name="sections">A list of NarrativeSectionData objects to be rendered.</param>

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
