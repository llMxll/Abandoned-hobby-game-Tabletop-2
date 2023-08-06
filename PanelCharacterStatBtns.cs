using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCharacterStatBtns : MonoBehaviour {

    public GameObject PanelAttributes;
    public GameObject PanelSkills;
    public GameObject PanelFeats;
    public GameObject PanelSpells;
    public GameObject PanelInventory;
    public GameObject PanelNotes;

    public GameObject BtnAttributes;
    public GameObject BtnSkills;
    public GameObject BtnFeats;
    public GameObject BtnSpells;
    public GameObject BtnInventory;
    public GameObject BtnNotes;

    public GameObject BtnAttributesOpen;
    public GameObject BtnSkillsOpen;
    public GameObject BtnFeatsOpen;
    public GameObject BtnSpellsOpen;
    public GameObject BtnInventoryOpen;
    public GameObject BtnNotesOpen;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseAllPanels()
    {
        PanelAttributes.gameObject.SetActive(false);
        PanelSkills.gameObject.SetActive(false);
        PanelFeats.gameObject.SetActive(false);
        PanelSpells.gameObject.SetActive(false);
        PanelInventory.gameObject.SetActive(false);
        PanelNotes.gameObject.SetActive(false);

        BtnAttributes.gameObject.SetActive(true);
        BtnSkills.gameObject.SetActive(true);
        BtnFeats.gameObject.SetActive(true);
        BtnSpells.gameObject.SetActive(true);
        BtnInventory.gameObject.SetActive(true);
        BtnNotes.gameObject.SetActive(true);

        BtnAttributesOpen.gameObject.SetActive(false);
        BtnSkillsOpen.gameObject.SetActive(false);
        BtnFeatsOpen.gameObject.SetActive(false);
        BtnSpellsOpen.gameObject.SetActive(false);
        BtnInventoryOpen.gameObject.SetActive(false);
        BtnNotesOpen.gameObject.SetActive(false);
    }
}
