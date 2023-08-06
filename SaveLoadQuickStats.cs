using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadQuickStats : MonoBehaviour
{

    public Text CharacterName;

    public InputField AC;
    public InputField LvL;
    public InputField HPCurrent;
    public InputField HPTotal;
    public InputField TempHp;

    public InputField XP;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveQuickStats()
    {
        PlayerPrefs.SetString(CharacterName.text + "AC", AC.text);
        PlayerPrefs.SetString(CharacterName.text + "LvL", LvL.text);
        PlayerPrefs.SetString(CharacterName.text + "HPCurrent", HPCurrent.text);
        PlayerPrefs.SetString(CharacterName.text + "TempHp", TempHp.text);
        PlayerPrefs.SetString(CharacterName.text + "HPTotal", HPTotal.text);

        PlayerPrefs.SetString(CharacterName.text + "XP", XP.text);
    }

    public void LoadQuickStats()
    {

        AC.text = PlayerPrefs.GetString(CharacterName.text + "AC");
        LvL.text = PlayerPrefs.GetString(CharacterName.text + "LvL");
        HPCurrent.text = PlayerPrefs.GetString(CharacterName.text + "HPCurrent");
        TempHp.text = PlayerPrefs.GetString(CharacterName.text + "TempHp");
        HPTotal.text = PlayerPrefs.GetString(CharacterName.text + "HPTotal");

        XP.text = PlayerPrefs.GetString(CharacterName.text + "XP");
    }
}