using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadNotes : MonoBehaviour
{
    public Text CharacterName;

    private string CurrentSavedNotes;
    private string TempNote;
    private string LastNoteSelected;

    public Dropdown Notepicker;

    public Text NoteSaveName;
    public Text Notepicked;

    public InputField NoteDescript;

    private string NewNoteString;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LastNoteSelected != Notepicked.text)
        {
            LoadNoteDetails();
        }
        LastNoteSelected = Notepicked.text;
    }

    public void LoadNotes()
    {
        //Delete all options
        Notepicker.options.Clear();

        //Add defults
        Notepicker.options.Add(new Dropdown.OptionData() { text = "Select a Note" });

        //Load data
        CurrentSavedNotes = PlayerPrefs.GetString(CharacterName.text + "Note");

        //Cut players
        string[] splitcontent = CurrentSavedNotes.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempNote = splitcontent[x];
            Notepicker.options.Add(new Dropdown.OptionData() { text = TempNote });
        }
    }

    public void SaveNote()
    {
        //Load current
        CurrentSavedNotes = PlayerPrefs.GetString(CharacterName.text + "Note");

        //Add new to current
        CurrentSavedNotes += NoteSaveName.text + ";";

        //Save name
        PlayerPrefs.SetString(CharacterName.text + "Note", CurrentSavedNotes);

        LoadNotes();
    }

    public void SaveNoteDetails()
    {
        PlayerPrefs.SetString(CharacterName.text + "Note" + Notepicked.text, NoteDescript.text);
    }

    public void LoadNoteDetails()
    {
        NoteDescript.text = PlayerPrefs.GetString(CharacterName.text + "Note" + Notepicked.text);
    }

    public void DeleteNote()
    {
        PlayerPrefs.DeleteKey(CharacterName.text + "Note" + Notepicked.text);

        CurrentSavedNotes = PlayerPrefs.GetString(CharacterName.text + "Note");

        string[] splitcontent = CurrentSavedNotes.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempNote = splitcontent[x];

            if (TempNote != Notepicked.text)
            {
                NewNoteString += TempNote + ";";
            }
        }

        PlayerPrefs.SetString(CharacterName.text + "Note", NewNoteString);

        LoadNotes();

        NewNoteString = null;
    }

}
