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
        var sections = new List<NarrativeSectionData>
        {
            new NarrativeSectionData
            {
                Text = "Gang Mejayan > Rumahku\nIni adalah kamar kecil yang nyaman...",
                // Actions = new List<ActionChoice>()
            },
            new NarrativeSectionData
            {
                Text = "Rena sedang duduk di kasur, menyisir rambutnya.",
                Actions = new List<ActionChoice>
                {
                    new ActionChoice { Label = "Ajak bicara Rena", OnClick = () => Debug.Log("Ngobrol dengan Rena...") },
                    new ActionChoice { Label = "Tanyakan kabar", OnClick = () => Debug.Log("Kamu bertanya kabar...") }
                }
            },
            new NarrativeSectionData
            {
                Text = "Kulkas berdengung pelan. Sedikit berdebu.",
                Actions = new List<ActionChoice>
                {
                    new ActionChoice { Label = "Ambil kue", OnClick = () => Debug.Log("Kamu ambil kue.") },
                    new ActionChoice { Label = "Bersihkan kulkas", OnClick = () => Debug.Log("Membersihkan...") }
                }
            },
            new NarrativeSectionData
            {
                Text = "Pintu kamar terbuka menuju ruang tengah.",
                Actions = new List<ActionChoice>
                {
                    new ActionChoice { Label = "Keluar kamar", OnClick = () => Debug.Log("Keluar ke ruang tengah.") }
                }
            }
        };
        FindFirstObjectByType<NarrativeRenderer>().Render(sections);
        StartCoroutine(RebuildLayout());

    }
    IEnumerator RebuildLayout()
    {
        // yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);
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