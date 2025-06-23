using System;
using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using Assets.App.UIElements.NarrativeSection.DTOs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeSectionUI : MonoBehaviour
{
    public TextMeshProUGUI narrativeText;
    public Transform actionContainer;
    public GameObject actionButtonPrefab;

    public void Set(TextDTO text, List<ActionChoice> actions)
    {
        if (text.StyleOverride != null)
        {
            narrativeText.text = "<style=\"" + text.StyleOverride.ToString() + "\">" + text.ToString() + "</style>";
        }
        else
        {
            narrativeText.text = text.ToString();
        }

        // Clear old buttons
        foreach (Transform child in actionContainer)
        {
            Destroy(child.gameObject);
        }

        if (actions == null) return;
        // Add buttons
        foreach (var action in actions)
        {
            var go = Instantiate(actionButtonPrefab, actionContainer);
            go.GetComponent<TextMeshProUGUI>().text = action.Label;
            go.GetComponent<Button>().onClick.AddListener(() => action.OnClick.Invoke());
        }
    }
}
