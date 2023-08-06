using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MapSelectScript : MonoBehaviour {

    private string CurrentSavedMaps;
    private string TempMap;

    public Dropdown Mappicker;

    // Use this for initialization
    void Start () {
        LoadMaps();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void LoadMaps()
    {
        //Delete all options
        Mappicker.options.Clear();

        //Add defults
        Mappicker.options.Add(new Dropdown.OptionData() { text = "Empty Map" });

        //Load data
        CurrentSavedMaps = PlayerPrefs.GetString("Map");

        //Cut players
        string[] splitcontent = CurrentSavedMaps.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempMap = splitcontent[x];
            Mappicker.options.Add(new Dropdown.OptionData() { text = TempMap });
        }
    }
}
