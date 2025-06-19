using System;
using Assets.App.Models;
using Assets.App.Enums;
using UnityEngine;
using System.Reflection;
using System.Text;
using Assets.App.Scripts.Singletons;
using App.UIElements.NarrativeSection.DTOs;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using Assets.App.Entities;

public class Testing1 : MonoBehaviour
{
    public RectTransform canvas;
    void Start()
    {
        // Test();
        Test2();
    }

    public void Test()
    {
        Debug.Log("Test");
        var character = new CharacterModel { Name = "Alan", Age = 20, Sex = SexType.Male };
        Debug.Log(VarDump(character));
        character.Save();
        var characterFromDict = CharacterModel.Find(character.Id);
        Debug.Log(VarDump(character));
        Debug.Log(VarDump(characterFromDict));
        var myPet = new PetModel { Name = "Luna", Age = 5, Breed = "Husky", Sex = SexType.Female, Owner = character };
        Debug.Log(VarDump(myPet));
        myPet.Save();
        var petFromDict = PetModel.Find(myPet.Id);
        Debug.Log(VarDump(myPet));
        Debug.Log(VarDump(petFromDict));

    }
    public void Test2()
    {
        var narrativeRenderer = FindFirstObjectByType<NarrativeRenderer>();
        CharacterModel jonas = new CharacterModel
        {
            Name = "Jonas",
            Age = 20,
            Sex = SexType.Male,
            Physique = new PhysiqueModel { HeightPoint = 77, FatPoint = 1, MusclePoint = 1 }
        };
        jonas.Save();
        jonas.Physique.Save();

        var sections = new List<NarrativeSectionData>()
        {
            new NarrativeSectionData
            { Text = "Character",
                Actions = new List<ActionChoice>()
            {
                new ActionChoice
                { Label = "Show Character",
                    OnClick = () =>
                    {
                        narrativeRenderer.Append(new NarrativeSectionData
                        {
                            Text = VarDump(jonas)+"\n"+VarDump(jonas.Physique)+jonas.Physique.Height(),
                        });
                        StartCoroutine(RebuildLayout());
                    }
                },
                new ActionChoice{
                    Label = "Makan popcorn-nya.",
                    OnClick = () =>
                    {
                        Debug.Log(jonas.Name + " makan popcorn-nya.");
                    }
                },
            }
            }
        };
        narrativeRenderer.Render(sections);
        StartCoroutine(RebuildLayout());

    }
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