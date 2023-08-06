using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditModePicker : MonoBehaviour {

    public Text EditModePickerLabel;
    public Text CharacterName;
    public Text BtnWarningModeSelect;

    public Dropdown TerrainPicker;
    public Dropdown CreaturePicker;
    public Dropdown TTObjectPicker;

    public GameObject BtnGiveGate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetNewModeComponents()
    {
        if (EditModePickerLabel.text == "Terrain" && CharacterName.text == "Dungeon Master")
        {
            TerrainPicker.gameObject.SetActive(true);
            CreaturePicker.gameObject.SetActive(false);
            TTObjectPicker.gameObject.SetActive(false);
            BtnGiveGate.gameObject.SetActive(false);
            BtnWarningModeSelect.gameObject.SetActive(false);
        }

        if (EditModePickerLabel.text == "Terrain" && CharacterName.text != "Dungeon Master")
        {
            TerrainPicker.gameObject.SetActive(false);
            CreaturePicker.gameObject.SetActive(false);
            TTObjectPicker.gameObject.SetActive(false);
            BtnGiveGate.gameObject.SetActive(false);

            BtnWarningModeSelect.gameObject.SetActive(true);
            BtnWarningModeSelect.text = "Must be DM";
        }

        if (EditModePickerLabel.text == "Creatures")
        {
            CreaturePicker.gameObject.SetActive(true);
            TerrainPicker.gameObject.SetActive(false);
            TTObjectPicker.gameObject.SetActive(false);
            BtnWarningModeSelect.gameObject.SetActive(false);

            if (CharacterName.text == "Dungeon Master")
            {
                BtnGiveGate.gameObject.SetActive(true);
            }
            else
            {
                BtnGiveGate.gameObject.SetActive(false);
            }
        }

        if (EditModePickerLabel.text == "Objects" && CharacterName.text == "Dungeon Master")
        {
            TerrainPicker.gameObject.SetActive(false);
            CreaturePicker.gameObject.SetActive(false);
            TTObjectPicker.gameObject.SetActive(true);
            BtnGiveGate.gameObject.SetActive(false);
            BtnWarningModeSelect.gameObject.SetActive(false);
        }

        if (EditModePickerLabel.text == "Objects" && CharacterName.text != "Dungeon Master")
        {
            TerrainPicker.gameObject.SetActive(false);
            CreaturePicker.gameObject.SetActive(false);
            TTObjectPicker.gameObject.SetActive(false);
            BtnGiveGate.gameObject.SetActive(false);

            BtnWarningModeSelect.gameObject.SetActive(true);
            BtnWarningModeSelect.text = "Must be DM";
        }

        if (EditModePickerLabel.text == "Arrange" && CharacterName.text != "Dungeon Master")
        {
            TerrainPicker.gameObject.SetActive(false);
            CreaturePicker.gameObject.SetActive(false);
            TTObjectPicker.gameObject.SetActive(false);
            BtnGiveGate.gameObject.SetActive(false);

            BtnWarningModeSelect.gameObject.SetActive(true);
            BtnWarningModeSelect.text = "Must be DM";
        }

        if (EditModePickerLabel.text == "Select Mode")
        {
            TerrainPicker.gameObject.SetActive(false);
            CreaturePicker.gameObject.SetActive(false);
            BtnGiveGate.gameObject.SetActive(false);

            BtnWarningModeSelect.gameObject.SetActive(true);
            BtnWarningModeSelect.text = "Select a mode";
        }

        if (EditModePickerLabel.text != "Terrain" && EditModePickerLabel.text != "Creatures" && EditModePickerLabel.text != "Select Mode" && EditModePickerLabel.text != "Objects" && EditModePickerLabel.text != "Arrange")
        {
            TerrainPicker.gameObject.SetActive(false);
            CreaturePicker.gameObject.SetActive(false);
            BtnGiveGate.gameObject.SetActive(false);

            BtnWarningModeSelect.gameObject.SetActive(false);
        }
    }
}
