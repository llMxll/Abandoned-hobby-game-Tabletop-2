using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSaves : MonoBehaviour
{
    public Button BtnFinish;

    private string NewPlayerName;
    private string NewPlayerColorR;
    private string NewPlayerColorG;
    private string NewPlayerColorB;

    public Text FldNameTxt;
    public Text FldColorRTxt;
    public Text FldColorGTxt;
    public Text FldColorBTxt;

    private string CurrentSavedChars;

    public Dropdown DrpCharacterpicker;
    private string LoadCharName;
    public Dropdown DrpCharacterName;

    public Text DrpCharacterNameLabel;

    private string Tempsavestodelete;
    private string TempChars;

    public Dropdown DrpCreature;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConfirmPlayer()
    {
        //Remove Lingering Character Names
        DrpCharacterName.options.Clear();

        //Add Extra
        DrpCharacterName.options.Add(new Dropdown.OptionData() { text = "Name" });

        //Add Character
        LoadCharName = DrpCharacterpicker.options[DrpCharacterpicker.value].text;
        DrpCharacterName.options.Add(new Dropdown.OptionData() { text = LoadCharName });

        DrpCharacterName.value = 2;

        PlayerMinis();
    }

    public void PlayerMinis()
    {
        //Masking for players
        if (LoadCharName != "Dungeon Master")
        {
            DrpCreature.options.Clear();

            DrpCreature.options.Add(new Dropdown.OptionData() { text = "Select Creature" });

            string MyMinis = PlayerPrefs.GetString(DrpCharacterNameLabel.text + "MyMinis");

            string[] splitcontent = MyMinis.Split(';');

            for (int x = 0; x < splitcontent.Length - 1; x++)
            {
                string TempMini = splitcontent[x];
                DrpCreature.options.Add(new Dropdown.OptionData() { text = TempMini });
            }
        }
    }

    public void NewPlayerCreate()
    {
        // Gather info from UI
        NewPlayerName = FldNameTxt.text.ToString();

        NewPlayerColorR = FldColorRTxt.text;
        NewPlayerColorG = FldColorGTxt.text;
        NewPlayerColorB = FldColorBTxt.text;

        //Load current characters
        CurrentSavedChars = PlayerPrefs.GetString("Player");

        //Add new character to current
        CurrentSavedChars += NewPlayerName + ";";

        //Save
        PlayerPrefs.SetString("Player", CurrentSavedChars);

        PlayerPrefs.SetString(NewPlayerName + "ColorRed", NewPlayerColorR);
        PlayerPrefs.SetString(NewPlayerName + "ColorBlue", NewPlayerColorB);
        PlayerPrefs.SetString(NewPlayerName + "ColorGreen", NewPlayerColorG);
    }

    public void PlayerDelete()
    {
        //Delete all Attacks
        Tempsavestodelete = PlayerPrefs.GetString(DrpCharacterNameLabel.text + "Attack");

        string[] splitcontentAttack = Tempsavestodelete.Split(';');

        for (int x = 0; x < splitcontentAttack.Length - 1; x++)
        {
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Attack" + splitcontentAttack[x]);

            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + " " + splitcontentAttack[x] + "Bonus");
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + " " + splitcontentAttack[x] + "Damage");
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + " " + splitcontentAttack[x] + "Range");
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + " " + splitcontentAttack[x] + "Ammo");
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + " " + splitcontentAttack[x] + "Type");
        }

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Attack");

        //Delete all Note
        Tempsavestodelete = PlayerPrefs.GetString(DrpCharacterNameLabel.text + "Note");

        string[] splitcontentNote = Tempsavestodelete.Split(';');

        for (int x = 0; x < splitcontentNote.Length - 1; x++)
        {
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Note" + splitcontentNote[x]);
        }

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Note");

        //Delete all Spell
        Tempsavestodelete = PlayerPrefs.GetString(DrpCharacterNameLabel.text + "Spell");

        string[] splitcontentSpell = Tempsavestodelete.Split(';');

        for (int x = 0; x < splitcontentSpell.Length - 1; x++)
        {
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Spell" + splitcontentSpell[x]);
        }

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Spell");

        //Delete all Inventory
        Tempsavestodelete = PlayerPrefs.GetString(DrpCharacterNameLabel.text + "Item");

        string[] splitcontentItem = Tempsavestodelete.Split(';');

        for (int x = 0; x < splitcontentItem.Length - 1; x++)
        {
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Item" + splitcontentItem[x]);
        }

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Item");

        //Delete all Feats

        Tempsavestodelete = PlayerPrefs.GetString(DrpCharacterNameLabel.text + "Feat");

        string[] splitcontentFeat = Tempsavestodelete.Split(';');

        for (int x = 0; x < splitcontentFeat.Length - 1; x++)
        {
            PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Feat" + splitcontentFeat[x]);
        }

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Feat");

        //Delete Skills
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Acrobatics");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Animal");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Arcana");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Athletics");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Deception");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "History");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Insight");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Intimidation");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Investigation");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Medicine");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Nature");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Perception");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Performance");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Persuasion");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Religion");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Sleight");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Stealth");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Survival");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "PassivePerception");

        //Delete QuickStats

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "AC");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "LvL");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "HPCurrent");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "TempHp");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "HPTotal");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "XP");

        //Delete Attributes
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "HitDice");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ProfBonus");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Initiative");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "Speed");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "StrRaw");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "StrMod");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "StrSav");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "DexRaw");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "DexMod");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "DexSav");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ConRaw");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ConMod");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ConSav");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "IntRaw");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "IntMod");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "IntSav");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "WisRaw");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "WisMod");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "WisSav");

        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ChaRaw");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ChaMod");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ChaSav");

        //Delete player color
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ColorRed");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ColorBlue");
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "ColorGreen");

        //Delete MyMinis
        PlayerPrefs.DeleteKey(DrpCharacterNameLabel.text + "MyMinis");

        //Delete player from list
        CurrentSavedChars = PlayerPrefs.GetString("Player");

        string[] splitcontent = CurrentSavedChars.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempChars = splitcontent[x];

            if (TempChars != DrpCharacterNameLabel.text)
            {
                Tempsavestodelete += TempChars + ";";
            }
        }

        PlayerPrefs.SetString("Player", Tempsavestodelete);

        Tempsavestodelete = null;
    } 

    public void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

