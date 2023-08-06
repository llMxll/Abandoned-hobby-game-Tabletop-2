using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class CharacterSelect : MonoBehaviour {

    private string playerlist;
    private string TempChar;

    public Dropdown Characterpicker;

	// Use this for initialization
	void Start () {
        LoadChars();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void LoadChars()
    {
        //Delete all options
        Characterpicker.options.Clear();

        //Add Observer and DM
        Characterpicker.options.Add(new Dropdown.OptionData() { text = "Observer" });
        Characterpicker.options.Add(new Dropdown.OptionData() { text = "Dungeon Master" });

        PlayerPrefs.SetString("Observer" + "ColorRed", "255");
        PlayerPrefs.SetString("Observer" + "ColorGreen", "255");
        PlayerPrefs.SetString("Observer" + "ColorBlue", "255");

        PlayerPrefs.SetString("Dungeon Master" + "ColorRed", "0");
        PlayerPrefs.SetString("Dungeon Master" + "ColorGreen", "0");
        PlayerPrefs.SetString("Dungeon Master" + "ColorBlue", "0");

        //Load data
        playerlist = PlayerPrefs.GetString("Player");

        //Cut players
        string[] splitcontent = playerlist.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempChar = splitcontent[x];
            Characterpicker.options.Add(new Dropdown.OptionData() {text = TempChar});
        }

        Characterpicker.value = 0;
    }
}
