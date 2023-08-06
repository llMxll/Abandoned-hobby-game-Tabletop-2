using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadSpell : MonoBehaviour
{
    public Text CharacterName;

    private string CurrentSavedSpells;
    private string TempSpell;
    private string LastSpellSelected;

    public Dropdown Spellpicker;

    public Text SpellSaveName;
    public Text Spellpicked;

    public InputField SpellDescript;

    private string NewSpellString;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LastSpellSelected != Spellpicked.text)
        {
            LoadSpellDetails();
        }
        LastSpellSelected = Spellpicked.text;
    }

    public void LoadSpells()
    {
        //Delete all options
        Spellpicker.options.Clear();

        //Add defults
        Spellpicker.options.Add(new Dropdown.OptionData() { text = "Select a spell" });

        //Load data
        CurrentSavedSpells = PlayerPrefs.GetString(CharacterName.text + "Spell");

        //Cut players
        string[] splitcontent = CurrentSavedSpells.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempSpell = splitcontent[x];
            Spellpicker.options.Add(new Dropdown.OptionData() { text = TempSpell });
        }
    }

    public void SaveSpell()
    {
        //Load current
        CurrentSavedSpells = PlayerPrefs.GetString(CharacterName.text + "Spell");

        //Add new to current
        CurrentSavedSpells += SpellSaveName.text + ";";

        //Save name
        PlayerPrefs.SetString(CharacterName.text + "Spell", CurrentSavedSpells);

        LoadSpells();
    }

    public void SaveSpellDetails()
    {
        PlayerPrefs.SetString(CharacterName.text + "Spell" + Spellpicked.text, SpellDescript.text);
    }

    public void LoadSpellDetails()
    {
        SpellDescript.text = PlayerPrefs.GetString(CharacterName.text + "Spell" + Spellpicked.text);
    }

    public void DeleteSpell()
    {
        PlayerPrefs.DeleteKey(CharacterName.text + "Spell" + Spellpicked.text);

        CurrentSavedSpells = PlayerPrefs.GetString(CharacterName.text + "Spell");

        string[] splitcontent = CurrentSavedSpells.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempSpell = splitcontent[x];

            if (TempSpell != Spellpicked.text)
            {
                NewSpellString += TempSpell + ";";
            }
        }

        PlayerPrefs.SetString(CharacterName.text + "Spell", NewSpellString);

        LoadSpells();

        NewSpellString = null;
    }
}
