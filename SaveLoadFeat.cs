using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadFeat : MonoBehaviour
{
    public Text CharacterName;

    private string CurrentSavedFeats;
    private string TempFeat;
    private string LastFeatSelected;

    public Dropdown Featpicker;

    public Text FeatSaveName;
    public Text Featpicked;

    public InputField FeatDescript;

    private string NewFeatString;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LastFeatSelected != Featpicked.text)
        {
            LoadFeatDetails();
        }
        LastFeatSelected = Featpicked.text;
    }

    public void LoadFeats()
    {
        //Delete all options
        Featpicker.options.Clear();

        //Add defults
        Featpicker.options.Add(new Dropdown.OptionData() { text = "Select a feat" });

        //Load data
        CurrentSavedFeats = PlayerPrefs.GetString(CharacterName.text + "Feat");

        //Cut players
        string[] splitcontent = CurrentSavedFeats.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempFeat = splitcontent[x];
            Featpicker.options.Add(new Dropdown.OptionData() { text = TempFeat });
        }
    }

    public void SaveFeat()
    {
        //Load current
        CurrentSavedFeats = PlayerPrefs.GetString(CharacterName.text + "Feat");

        //Add new to current
        CurrentSavedFeats += FeatSaveName.text + ";";

        //Save name
        PlayerPrefs.SetString(CharacterName.text + "Feat", CurrentSavedFeats);

        LoadFeats();
    }

    public void SaveFeatDetails()
    {
        PlayerPrefs.SetString(CharacterName.text + "Feat" + Featpicked.text, FeatDescript.text);
    }

    public void LoadFeatDetails()
    {
        FeatDescript.text = PlayerPrefs.GetString(CharacterName.text + "Feat" + Featpicked.text);
    }

    public void DeleteFeat()
    {
        PlayerPrefs.DeleteKey(CharacterName.text + "Feat" + Featpicked.text);

        CurrentSavedFeats = PlayerPrefs.GetString(CharacterName.text + "Feat");

        string[] splitcontent = CurrentSavedFeats.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempFeat = splitcontent[x];

            if (TempFeat != Featpicked.text)
            {
                NewFeatString += TempFeat + ";";
            }
        }

        PlayerPrefs.SetString(CharacterName.text + "Feat", NewFeatString);

        LoadFeats();

        NewFeatString = null;
    }
}
