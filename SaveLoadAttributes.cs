using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveLoadAttributes : MonoBehaviour {

    public Text CharacterName;

    public InputField HitDice;
    public InputField ProfBonus;
    public InputField Initiative;
    public InputField Speed;

    public InputField StrRaw;
    public InputField StrMod;
    public InputField StrSav;

    public InputField DexRaw;
    public InputField DexMod;
    public InputField DexSav;

    public InputField ConRaw;
    public InputField ConMod;
    public InputField ConSav;

    public InputField IntRaw;
    public InputField IntMod;
    public InputField IntSav;

    public InputField WisRaw;
    public InputField WisMod;
    public InputField WisSav;

    public InputField ChaRaw;
    public InputField ChaMod;
    public InputField ChaSav;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void SaveAttributes()
    {
        PlayerPrefs.SetString(CharacterName.text + "HitDice", HitDice.text);
        PlayerPrefs.SetString(CharacterName.text + "ProfBonus", ProfBonus.text);
        PlayerPrefs.SetString(CharacterName.text + "Initiative", Initiative.text);
        PlayerPrefs.SetString(CharacterName.text + "Speed", Speed.text);

        PlayerPrefs.SetString(CharacterName.text + "StrRaw", StrRaw.text);
        PlayerPrefs.SetString(CharacterName.text + "StrMod", StrMod.text);
        PlayerPrefs.SetString(CharacterName.text + "StrSav", StrSav.text);

        PlayerPrefs.SetString(CharacterName.text + "DexRaw", DexRaw.text);
        PlayerPrefs.SetString(CharacterName.text + "DexMod", DexMod.text);
        PlayerPrefs.SetString(CharacterName.text + "DexSav", DexSav.text);

        PlayerPrefs.SetString(CharacterName.text + "ConRaw", ConRaw.text);
        PlayerPrefs.SetString(CharacterName.text + "ConMod", ConMod.text);
        PlayerPrefs.SetString(CharacterName.text + "ConSav", ConSav.text);

        PlayerPrefs.SetString(CharacterName.text + "IntRaw", IntRaw.text);
        PlayerPrefs.SetString(CharacterName.text + "IntMod", IntMod.text);
        PlayerPrefs.SetString(CharacterName.text + "IntSav", IntSav.text);

        PlayerPrefs.SetString(CharacterName.text + "WisRaw", WisRaw.text);
        PlayerPrefs.SetString(CharacterName.text + "WisMod", WisMod.text);
        PlayerPrefs.SetString(CharacterName.text + "WisSav", WisSav.text);

        PlayerPrefs.SetString(CharacterName.text + "ChaRaw", ChaRaw.text);
        PlayerPrefs.SetString(CharacterName.text + "ChaMod", ChaMod.text);
        PlayerPrefs.SetString(CharacterName.text + "ChaSav", ChaSav.text);
    }

    public void LoadAttributes()
    {
        HitDice.text = PlayerPrefs.GetString(CharacterName.text + "HitDice");
        ProfBonus.text = PlayerPrefs.GetString(CharacterName.text + "ProfBonus");
        Initiative.text = PlayerPrefs.GetString(CharacterName.text + "Initiative");
        Speed.text = PlayerPrefs.GetString(CharacterName.text + "Speed");

        StrRaw.text = PlayerPrefs.GetString(CharacterName.text + "StrRaw");
        StrMod.text = PlayerPrefs.GetString(CharacterName.text + "StrMod");
        StrSav.text = PlayerPrefs.GetString(CharacterName.text + "StrSav");

        DexRaw.text = PlayerPrefs.GetString(CharacterName.text + "DexRaw");
        DexMod.text = PlayerPrefs.GetString(CharacterName.text + "DexMod");
        DexSav.text = PlayerPrefs.GetString(CharacterName.text + "DexSav");

        ConRaw.text = PlayerPrefs.GetString(CharacterName.text + "ConRaw");
        ConMod.text = PlayerPrefs.GetString(CharacterName.text + "ConMod");
        ConSav.text = PlayerPrefs.GetString(CharacterName.text + "ConSav");

        IntRaw.text = PlayerPrefs.GetString(CharacterName.text + "IntRaw");
        IntMod.text = PlayerPrefs.GetString(CharacterName.text + "IntMod");
        IntSav.text = PlayerPrefs.GetString(CharacterName.text + "IntSav");

        WisRaw.text = PlayerPrefs.GetString(CharacterName.text + "WisRaw");
        WisMod.text = PlayerPrefs.GetString(CharacterName.text + "WisMod");
        WisSav.text = PlayerPrefs.GetString(CharacterName.text + "WisSav");

        ChaRaw.text = PlayerPrefs.GetString(CharacterName.text + "ChaRaw");
        ChaMod.text = PlayerPrefs.GetString(CharacterName.text + "ChaMod");
        ChaSav.text = PlayerPrefs.GetString(CharacterName.text + "ChaSav");
    }
}
