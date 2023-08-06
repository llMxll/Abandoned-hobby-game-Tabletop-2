using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadInv : MonoBehaviour
{
    public Text CharacterName;

    private string CurrentSavedItems;
    private string TempItem;
    private string LastItemSelected;

    public Dropdown Itempicker;

    public Text ItemSaveName;
    public Text Itempicked;

    public InputField ItemDescript;

    private string NewItemString;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LastItemSelected != Itempicked.text)
        {
            LoadItemDetails();
        }
        LastItemSelected = Itempicked.text;
    }

    public void LoadItems()
    {
        //Delete all options
        Itempicker.options.Clear();

        //Add defults
        Itempicker.options.Add(new Dropdown.OptionData() { text = "Select a item" });

        //Load data
        CurrentSavedItems = PlayerPrefs.GetString(CharacterName.text + "Item");

        //Cut players
        string[] splitcontent = CurrentSavedItems.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempItem = splitcontent[x];
            Itempicker.options.Add(new Dropdown.OptionData() { text = TempItem });
        }
    }

    public void SaveItem()
    {
        //Load current
        CurrentSavedItems = PlayerPrefs.GetString(CharacterName.text + "Item");

        //Add new to current
        CurrentSavedItems += ItemSaveName.text + ";";

        //Save name
        PlayerPrefs.SetString(CharacterName.text + "Item", CurrentSavedItems);

        LoadItems();
    }

    public void SaveItemDetails()
    {
        PlayerPrefs.SetString(CharacterName.text + "Item" + Itempicked.text, ItemDescript.text);
    }

    public void LoadItemDetails()
    {
        ItemDescript.text = PlayerPrefs.GetString(CharacterName.text + "Item" + Itempicked.text);
    }

    public void DeleteItem()
    {
        PlayerPrefs.DeleteKey(CharacterName.text + "Item" + Itempicked.text);

        CurrentSavedItems = PlayerPrefs.GetString(CharacterName.text + "Item");

        string[] splitcontent = CurrentSavedItems.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempItem = splitcontent[x];

            if (TempItem != Itempicked.text)
            {
                NewItemString += TempItem + ";";
            }
        }

        PlayerPrefs.SetString(CharacterName.text + "Item", NewItemString);

        LoadItems();

        NewItemString = null;
    }
}
