using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSaveListEditor : MonoBehaviour {
    public InputField InputCharEdit;
    public InputField InputMapEdit;

    public Dropdown DrpCharToEditPicker;
    private string playerlist;
    private string TempChar;

    public Text DrpCharToEditPickerText;
    public InputField InputAttackEdit;
    public InputField InputFeatEdit;
    public InputField InputSpellEdit;
    public InputField InputItemEdit;
    public InputField InputNoteEdit;
    public InputField InputMiniEdit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSaveListEditor()
    {
        InputCharEdit.text = PlayerPrefs.GetString("Player");
        InputMapEdit.text = PlayerPrefs.GetString("Map");

        //Delete all options
        DrpCharToEditPicker.options.Clear();

        //Add Observer and DM
        DrpCharToEditPicker.options.Add(new Dropdown.OptionData() { text = "Observer" });
        DrpCharToEditPicker.options.Add(new Dropdown.OptionData() { text = "Dungeon Master" });

        //Load data
        playerlist = PlayerPrefs.GetString("Player");

        //Cut players
        string[] splitcontent = playerlist.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempChar = splitcontent[x];
            DrpCharToEditPicker.options.Add(new Dropdown.OptionData() { text = TempChar });
        }

        DrpCharToEditPicker.value = 0;
    }

    public void LoadCharToEdit()
    {
        InputAttackEdit.text = PlayerPrefs.GetString(DrpCharToEditPickerText.text + "Attack");
        InputFeatEdit.text = PlayerPrefs.GetString(DrpCharToEditPickerText.text + "Feat");
        InputSpellEdit.text = PlayerPrefs.GetString(DrpCharToEditPickerText.text + "Spell");
        InputItemEdit.text = PlayerPrefs.GetString(DrpCharToEditPickerText.text + "Item");
        InputNoteEdit.text = PlayerPrefs.GetString(DrpCharToEditPickerText.text + "Note");
        InputMiniEdit.text = PlayerPrefs.GetString(DrpCharToEditPickerText.text + "MyMinis");
    }

    public void SaveEditedChars()
    {
        PlayerPrefs.SetString("Player", InputCharEdit.text);
    }

    public void SaveEditedMaps()
    {
        PlayerPrefs.SetString("Map", InputMapEdit.text);
    }

    public void SaveEditedAttacks()
    {
        PlayerPrefs.SetString(DrpCharToEditPickerText.text + "Attack", InputCharEdit.text);
    }

    public void SaveEditedFeats()
    {
        PlayerPrefs.SetString(DrpCharToEditPickerText.text + "Feat", InputFeatEdit.text);
    }

    public void SaveEditedSpells()
    {
        PlayerPrefs.SetString(DrpCharToEditPickerText.text + "Spell", InputSpellEdit.text);
    }

    public void SaveEditedItems()
    {
        PlayerPrefs.SetString(DrpCharToEditPickerText.text + "Item", InputItemEdit.text);
    }

    public void SaveEditedNotes()
    {
        PlayerPrefs.SetString(DrpCharToEditPickerText.text + "Note", InputNoteEdit.text);
    }

    public void SaveEditedMinis()
    {
        PlayerPrefs.SetString(DrpCharToEditPickerText.text + "MyMinis", InputMiniEdit.text);
    }
}

