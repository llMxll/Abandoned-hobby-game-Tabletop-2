using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadAttacks : MonoBehaviour
{
    public Text CharacterName;

    private string CurrentSavedAttacks;
    private string TempAttack;
    private string LastAttackSelected;

    public Dropdown Attackpicker;

    public Text AttackSaveName;
    public Text Attackpicked;

    public InputField AttackDescript;

    private string NewAttackString;

    public InputField Bonus;
    public InputField Damage;
    public InputField Range;
    public InputField Ammo;
    public InputField Type;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LastAttackSelected != Attackpicked.text)
        {
            LoadAttackDetails();
            LoadAttackQuickDetails();
        }
        LastAttackSelected = Attackpicked.text;
    }

    public void LoadAttacks()
    {
        //Delete all options
        Attackpicker.options.Clear();

        //Add defults
        Attackpicker.options.Add(new Dropdown.OptionData() { text = "Choose a Attack" });

        //Load data
        CurrentSavedAttacks = PlayerPrefs.GetString(CharacterName.text + "Attack");

        //Cut players
        string[] splitcontent = CurrentSavedAttacks.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempAttack = splitcontent[x];
            Attackpicker.options.Add(new Dropdown.OptionData() { text = TempAttack });
        }
    }

    public void SaveAttack()
    {
        //Load current
        CurrentSavedAttacks = PlayerPrefs.GetString(CharacterName.text + "Attack");

        //Add new to current
        CurrentSavedAttacks += AttackSaveName.text + ";";

        //Save name
        PlayerPrefs.SetString(CharacterName.text + "Attack", CurrentSavedAttacks);

        LoadAttacks();
    }

    public void SaveAttackDetails()
    {
        PlayerPrefs.SetString(CharacterName.text + "Attack" + Attackpicked.text, AttackDescript.text);
    }

    public void LoadAttackDetails()
    {
        AttackDescript.text = PlayerPrefs.GetString(CharacterName.text + "Attack" + Attackpicked.text);
    }

    public void SaveAttackQuickDetails()
    {
        PlayerPrefs.SetString(CharacterName + " " + Attackpicked.text + "Bonus", Bonus.text);
        PlayerPrefs.SetString(CharacterName + " " + Attackpicked.text + "Damage", Damage.text);
        PlayerPrefs.SetString(CharacterName + " " + Attackpicked.text + "Range", Range.text);
        PlayerPrefs.SetString(CharacterName + " " + Attackpicked.text + "Ammo", Ammo.text);
        PlayerPrefs.SetString(CharacterName + " " + Attackpicked.text + "Type", Type.text);
    }

    public void LoadAttackQuickDetails()
    {
        Bonus.text = PlayerPrefs.GetString(CharacterName + " " + Attackpicked.text + "Bonus");
        Damage.text = PlayerPrefs.GetString(CharacterName + " " + Attackpicked.text + "Damage");
        Range.text = PlayerPrefs.GetString(CharacterName + " " + Attackpicked.text + "Range");
        Ammo.text = PlayerPrefs.GetString(CharacterName + " " + Attackpicked.text + "Ammo");
        Type.text = PlayerPrefs.GetString(CharacterName + " " + Attackpicked.text + "Type");
    }

    public void DeleteAttack()
    {
        PlayerPrefs.DeleteKey(CharacterName + " " + Attackpicked.text + "Bonus");
        PlayerPrefs.DeleteKey(CharacterName + " " + Attackpicked.text + "Damage");
        PlayerPrefs.DeleteKey(CharacterName + " " + Attackpicked.text + "Range");
        PlayerPrefs.DeleteKey(CharacterName + " " + Attackpicked.text + "Ammo");
        PlayerPrefs.DeleteKey(CharacterName + " " + Attackpicked.text + "Type");

        PlayerPrefs.DeleteKey(CharacterName.text + "Attack" + Attackpicked.text);

        CurrentSavedAttacks = PlayerPrefs.GetString(CharacterName.text + "Attack");

        string[] splitcontent = CurrentSavedAttacks.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempAttack = splitcontent[x];

            if (TempAttack != Attackpicked.text)
            {
                NewAttackString += TempAttack + ";";
            }
        }

        PlayerPrefs.SetString(CharacterName.text + "Attack", NewAttackString);

        LoadAttacks();

        NewAttackString = null;
    }
}
