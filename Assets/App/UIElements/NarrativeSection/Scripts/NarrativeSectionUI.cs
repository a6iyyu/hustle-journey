using System;
using System.Collections.Generic;
using App.UIElements.NarrativeSection.DTOs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeSectionUI : MonoBehaviour
{
    public TextMeshProUGUI narrativeText;
    public Transform actionContainer;
    public GameObject actionButtonPrefab;

    public void Set(string text, List<ActionChoice> actions)
    {
        narrativeText.text = text;

        // Clear old buttons
        foreach (Transform child in actionContainer)
        {
            Destroy(child.gameObject);
        }

        // Add buttons
        foreach (var action in actions)
        {
            var go = Instantiate(actionButtonPrefab, actionContainer);
            go.GetComponent<TextMeshProUGUI>().text = action.Label;
            go.GetComponent<Button>().onClick.AddListener(() => action.OnClick.Invoke());
        }
    }
}
