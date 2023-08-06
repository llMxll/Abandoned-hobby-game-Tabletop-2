using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapStarter : NetworkBehaviour {

    public GameObject topmenu;

    public Text DrpCharPickerLabel;

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    Behaviour[] Topmenucomponents;

    [SerializeField]
    Behaviour[] PlayercomponentsToEnable;

    [SerializeField]
    Behaviour[] DMcomponentsToEnable;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartEnable()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].gameObject.SetActive(true);
        }
    }

    public void StartDisable()
    {
        topmenu.gameObject.SetActive(true);

        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].gameObject.SetActive(false);
        }
    }

    public void EnableTopMenu()
    {
        topmenu.gameObject.SetActive(true);

        for (int i = 0; i < Topmenucomponents.Length; i++)
        {
            Topmenucomponents[i].gameObject.SetActive(true);
        }
    }

    public void PlayerEnable()
    {
        if (DrpCharPickerLabel.text == "Dungeon Master")
        {
            for (int i = 0; i < DMcomponentsToEnable.Length; i++)
            {
                DMcomponentsToEnable[i].gameObject.SetActive(true);
            }
        }

        else
        {
            for (int i = 0; i < PlayercomponentsToEnable.Length; i++)
            {
                PlayercomponentsToEnable[i].gameObject.SetActive(true);
            }
        }
    }
}
