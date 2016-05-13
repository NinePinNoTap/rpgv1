using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using CharacterConfig;

public class CharacterCreation : MonoBehaviour
{
	[Header("Prefabs")]
    public GameObject maleCharacter;
    public GameObject femaleCharacter;

	[Header("Character Studio")]
	public int maximumNameLength = 10;
	public Character inProgress;

	private string selectedName;
	private GameGender selectedGender;
    private GameClass selectedClass;
	private GameRace selectedRace;

	void Start ()
	{
        inProgress = new Character();
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(30,30, Screen.width * 0.3f, Screen.height - 30));
        GUILayout.BeginVertical();

        //================
        // Character Name
        //================

        GUILayout.Label("Character Name");
		selectedName = GUILayout.TextArea(selectedName, GUILayout.Width(300));
		FormatName();

        GUILayout.Space(15);

		GUILayout.BeginHorizontal();
		
		//==================
		// Class Selection
		//==================
		
		GUILayout.BeginVertical();
		
		selectedClass = (GameClass)GUILayout.SelectionGrid((int)selectedClass, new string[] { "Hunter", "Mage", "Warrior" }, 1);
		
		GUILayout.EndVertical();
		
		//==================
		// Race Selection
		//==================
		
		GUILayout.BeginVertical();
		
		selectedRace = (GameRace)GUILayout.SelectionGrid((int)selectedRace, new string[] { "Human" }, 1);

		GUILayout.EndVertical();

        //==================
        // Gender Selection
        //==================

        GUILayout.BeginVertical();

        selectedGender = (GameGender)GUILayout.SelectionGrid((int)selectedGender, new string[] { "Male", "Female" }, 1);

        switch(selectedGender)
        {
            case GameGender.Male:
                maleCharacter.SetActive(true);
                femaleCharacter.SetActive(false);
                break;

            case GameGender.Female:
                maleCharacter.SetActive(false);
                femaleCharacter.SetActive(true);
                break;

			case GameGender.Other:
				// TODO
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
            if(inProgress.characterName.Length > 3)
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
		inProgress.characterName = selectedName;

		switch(selectedClass)
		{
			case GameClass.Hunter:
				inProgress.characterClass = new HunterClass();
				break;

			case GameClass.Mage:
				inProgress.characterClass = new MageClass();
				break;

			case GameClass.Warrior:
				inProgress.characterClass = new WarriorClass();
				break;
		}
		
		switch(selectedGender)
		{
			case GameGender.Male:
				inProgress.characterGender = GameGender.Male;
				break;
				
			case GameGender.Female:
				inProgress.characterGender = GameGender.Female;
				break;
		}

        Debug.Log("Generated Character : " + inProgress.characterName + "(Level " + inProgress.characterLevel + " " + inProgress.characterClass.className);
    }

	void FormatName()
	{
		selectedName = Regex.Replace(selectedName, @"[^a-zA-Z]", "");
		if(selectedName.Length > maximumNameLength)
		{
			selectedName = selectedName.Substring(0, maximumNameLength);
		}
	}
}