using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public enum ClassType
{
    Hunter,
    Mage,
    Warrior
};

public class CharacterCreation : MonoBehaviour
{
    public Character CharacterInProgress;

	void Start ()
	{
        CharacterInProgress = new Character();
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height));
        GUILayout.BeginVertical();

        //================
        // Character Name
        //================

        CharacterInProgress.Name = GUILayout.TextArea(CharacterInProgress.Name, GUILayout.Width(300));

        // Format Input
        CharacterInProgress.Name = Regex.Replace(CharacterInProgress.Name, @"[^a-zA-Z]", "");
        if(CharacterInProgress.Name.Length > 10)
        {
            CharacterInProgress.Name = CharacterInProgress.Name.Substring(0, 10);
        }

        GUILayout.BeginHorizontal();

        //==================
        // Class Selection
        //==================

        GUILayout.BeginVertical();

        if(GUILayout.Button("Hunter", GUILayout.Width(100)))
        {
            CharacterInProgress.Class = new HunterClass();
        }
        else if(GUILayout.Button("Mage", GUILayout.Width(100)))
        {
            CharacterInProgress.Class = new MageClass();
        }
        else if(GUILayout.Button("Warrior", GUILayout.Width(100)))
        {
            CharacterInProgress.Class = new WarriorClass();
        }

        GUILayout.EndVertical();

        //==================
        // Gender Selection
        //==================

        GUILayout.BeginVertical();

        if(GUILayout.Button("Male", GUILayout.Width(100)))
        {
            CharacterInProgress.Gender = CharacterGender.Male;
        }
        else if(GUILayout.Button("Female", GUILayout.Width(100)))
        {
            CharacterInProgress.Gender = CharacterGender.Female;
        }

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        //====================
        // Character Creation
        //====================

        if(GUILayout.Button("Create Character"))
        {
            if(CharacterInProgress.Name.Length > 3)
            {
                GenerateCharacter();
            }
            else
            {
                Debug.Log("Warning. Please ensure character name is of sufficient length");
            }
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void GenerateCharacter()
    {
        Debug.Log("Generated Character : " + CharacterInProgress.Name + "(Level " + CharacterInProgress.Level + " " + CharacterInProgress.Class.Name);
    }
}
