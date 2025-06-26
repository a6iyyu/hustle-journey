using System.Text;
using Assets.App.Scripts.Player;
using Assets.App.Scripts.Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeedSectionUI : MonoBehaviour
{
    public string needName;
    public TextMeshProUGUI nameDisplay;
    public Image barFill;
    private Need needObject;

    void Start()
    {
        needObject = Indexer.Instance.Player.Needs.GetNeedByName(needName);
        if (needObject == null)
        {
            Debug.LogError($"Need '{needName}' not found in player's needs.");
            return;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    void Update()
    {
        barFill.fillAmount = needObject.Value / needObject.MaxValue;
    }
    void OnValidate()
    {
        nameDisplay.text = TitleCase(needName);
    }

    private string TitleCase(string str)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (i == 0)
            {
                sb.Append(char.ToUpper(str[i]));
            }
            else
            {
                if (char.IsUpper(str[i]))
                {
                    sb.Append(' ');
                    sb.Append(char.ToLower(str[i]));
                }
                else
                {
                    sb.Append(str[i]);
                }
            }
        }
        return sb.ToString();

    }

}