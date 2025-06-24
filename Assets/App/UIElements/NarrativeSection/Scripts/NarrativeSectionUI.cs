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

    public void Set(List<TextDTO> texts, List<ActionChoice> actions)
    {
        string combinedText = CombineTexts(texts);

        narrativeText.text = combinedText;

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
    private string CombineTexts(List<TextDTO> texts)
    {
        string combinedText = string.Empty;
        foreach (var textDTO in texts)
        {
            if (textDTO.StyleOverride != null)
            {
                combinedText += $"<style=\"{textDTO.StyleOverride}\">{textDTO.Text}</style>";
            }
            else
            {
                combinedText += textDTO.Text;
            }
        }
        return combinedText;
    }
}
