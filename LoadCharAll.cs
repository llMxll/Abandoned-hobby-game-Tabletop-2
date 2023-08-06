using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharAll : MonoBehaviour {
    public GameObject Playersaves;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadAllPartsOfChar()
    {
        Playersaves.GetComponent<SaveLoadAttacks>().LoadAttacks();
        Playersaves.GetComponent<SaveLoadAttributes>().LoadAttributes();
        Playersaves.GetComponent<SaveLoadFeat>().LoadFeats();
        Playersaves.GetComponent<SaveLoadInv>().LoadItems();
        Playersaves.GetComponent<SaveLoadNotes>().LoadNotes();
        Playersaves.GetComponent<SaveLoadQuickStats>().LoadQuickStats();
        Playersaves.GetComponent<SaveLoadSkills>().LoadSkills();
        Playersaves.GetComponent<SaveLoadSpell>().LoadSpells();
    }
}
