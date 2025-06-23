using System;
using UnityEngine;
using System.Reflection;
using System.Text;
using Assets.App.Scripts.Singletons;
using App.UIElements.NarrativeSection.DTOs;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework.Internal;
using Assets.App.Scripts.Player;
using Assets.App.Scripts.Enums;
using Assets.App.Scripts.Models;
using Assets.App.UIElements.NarrativeSection.DTOs;

public class Testing1 : MonoBehaviour
{
    public RectTransform canvas;
    void Start()
    {
        // Test();
        // Test2();
        // Test3();
    }

    void Test3()
    {
        var narrativeRenderer = FindFirstObjectByType<NarrativeRenderer>();

        Player player = new()
        {
            Name = "Test Player",
            Age = 30,
            Physique = new PhysiqueModel { Sex = SexType.Male, HeightPoint = 100, FatPoint = 50, MusclePoint = 0 },
        };
        player.Needs.Satiety = 50;
        Debug.Log(player.Needs.Satiety);

        var sections = new List<NarrativeSectionData>()
        {
            new NarrativeSectionData
            {
                Text = new TextDTO("Player Info", TextStyle.Breadcrumb),
            }
        };
    }
    // public void Test2()
    // {
    //     var narrativeRenderer = FindFirstObjectByType<NarrativeRenderer>();
    //     CharacterModel jonas = new CharacterModel
    //     {
    //         Name = "Jonas",
    //         Age = 20,
    //         Physique = new PhysiqueModel {Sex = SexType.Male, HeightPoint = 100, FatPoint = 50, MusclePoint = 0 }
    //     };

    //     CharacterModel jannet = new CharacterModel
    //     {
    //         Name = "Jannet",
    //         Age = 20,
    //         Physique = new PhysiqueModel { Sex = SexType.Female, HeightPoint = 0, FatPoint = 100, MusclePoint = 0 }
    //     };
    //     CharacterModel michael = new CharacterModel
    //     {
    //         Name = "Michael",
    //         Age = 20,
    //         Physique = new PhysiqueModel { Sex = SexType.Male, HeightPoint = 70, FatPoint = 50, MusclePoint = 0 }
    //     };
    //     CharacterModel micah = new CharacterModel
    //     {
    //         Name = "Micah",
    //         Age = 20,
    //         Physique = new PhysiqueModel { Sex = SexType.Male, HeightPoint = 80, FatPoint = 35, MusclePoint = 20 }
    //     };
    //     CharacterModel hoss = new CharacterModel
    //     {
    //         Name = "Hoss",
    //         Age = 20,
    //         Physique = new PhysiqueModel { Sex = SexType.Male, HeightPoint = 50, FatPoint = 50, MusclePoint = 0 }
    //     };

    //     Debug.Log(jonas.Name+"\n"+jonas.Physique.Height+"\n"+jonas.Physique.Weight);
    //     Debug.Log(jannet.Name + "\n" + jannet.Physique.Height + "\n" + jannet.Physique.Weight);
    //     Debug.Log(michael.Name + "\n" + michael.Physique.Height + "\n" + michael.Physique.Weight);
    //     Debug.Log(micah.Name + "\n" + micah.Physique.Height + "\n" + micah.Physique.Weight);
    //     Debug.Log(hoss.Name + "\n" + hoss.Physique.Height + "\n" + hoss.Physique.Weight);

    //     var sections = new List<NarrativeSectionData>()
    //     {
    //         new NarrativeSectionData
    //         { Text = "Jonas",
    //             Actions = new List<ActionChoice>()
    //         {
    //             new ActionChoice{
    //                 Label = "-1 Fat",
    //                 OnClick = () => {
    //                     jonas.Physique.FatPoint -= 1;
    //                     Debug.Log(jonas.Physique.FatPoint+"; "+jonas.Physique.Weight);
    //                 }
    //             }
    //         }
    //         }
    //     };
    //     narrativeRenderer.Render(sections);
    //     StartCoroutine(RebuildLayout());

    // }


    IEnumerator RebuildLayout()
    {
        // yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.5f);
        LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
    }
    /// <summary>
    /// Dumps the given object's properties and values to a string.
    /// </summary>
    /// <param name="obj">Object to dump.</param>
    /// <returns>A string containing the object's properties and values.</returns>
    /// <remarks>
    /// This function is useful for debugging, since it shows the object's properties and values
    /// in a readable format.
    /// <para>
    /// It uses reflection to get the object's properties, and <see cref="StringBuilder"/> to
    /// build the string.
    /// </para>
    /// <para>
    /// It also handles exceptions that may occur while getting a property's value, and
    /// shows the exception message instead of the value.
    /// </para>
    /// </remarks>
    public static string VarDump(object obj)
    {
        var result = new StringBuilder();
        Type type = obj.GetType();
        result.AppendLine($"object({type.Name}) {{");

        foreach (PropertyInfo property in type.GetProperties())
        {
            try
            {
                // Hindari properti usang atau internal Unity yang bermasalah
                if (property.Name == "rigidbody") continue;

                var value = property.GetValue(obj, null);
                result.AppendLine($"  [{property.Name}] => {value}");
            }
            catch (Exception ex)
            {
                result.AppendLine($"  [{property.Name}] => (Error: {ex.Message})");
            }
        }

        result.AppendLine("}");
        return result.ToString();
    }
}