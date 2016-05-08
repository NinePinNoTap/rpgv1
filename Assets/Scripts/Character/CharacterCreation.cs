using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public enum ClassType
{
    Hunter = 0,
    Mage = 1,
    Warrior = 2
};

public class CharacterCreation : MonoBehaviour
{
    public GameObject MaleObj;
    public GameObject FemaleObj;
    public Character CharacterInProgress;
    private ClassType SelectedClass;
    private CharacterGender SelectedGender;

	void Start ()
	{
        CharacterInProgress = new Character();
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(30,30, Screen.width * 0.3f, Screen.height - 30));
        GUILayout.BeginVertical();

        //================
        // Character Name
        //================

        GUILayout.Label("Character Name");
        CharacterInProgress.Name = GUILayout.TextArea(CharacterInProgress.Name, GUILayout.Width(300));

        // Format Input
        CharacterInProgress.Name = Regex.Replace(CharacterInProgress.Name, @"[^a-zA-Z]", "");
        if(CharacterInProgress.Name.Length > 10)
        {
            CharacterInProgress.Name = CharacterInProgress.Name.Substring(0, 10);
        }

        GUILayout.Space(15);

        GUILayout.BeginHorizontal();

        //==================
        // Class Selection
        //==================

        GUILayout.BeginVertical();

        SelectedClass = (ClassType)GUILayout.SelectionGrid((int)SelectedClass, new string[] { "Hunter", "Mage", "Warrior" }, 1);

        switch(SelectedClass)
        {
            case ClassType.Hunter:
                CharacterInProgress.Class = new HunterClass();
                break;
            case ClassType.Mage:
                CharacterInProgress.Class = new MageClass();
                break;
            case ClassType.Warrior:
                CharacterInProgress.Class = new WarriorClass();
                break;
        }

        GUILayout.EndVertical();

        //==================
        // Gender Selection
        //==================

        GUILayout.BeginVertical();

        SelectedGender = (CharacterGender)GUILayout.SelectionGrid((int)SelectedGender, new string[] { "Male", "Female" }, 1);

        switch(SelectedGender)
        {
            case CharacterGender.Male:
                CharacterInProgress.Gender = CharacterGender.Male;
                MaleObj.SetActive(true);
                FemaleObj.SetActive(false);
                break;

            case CharacterGender.Female:
                CharacterInProgress.Gender = CharacterGender.Female;
                MaleObj.SetActive(false);
                FemaleObj.SetActive(true);
                break;
        }

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.Space(30);

        //====================
        // Character Creation
        //====================

        if(GUILayout.Button("Create", GUILayout.Width(100)))
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
