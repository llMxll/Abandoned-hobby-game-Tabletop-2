using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandNumber : MonoBehaviour {

    public Text Me;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Resting
    public void IsZero()
    {
        Me.text = "0";
    }

    //Savemap
    public void IsOne()
    {
        Me.text = "1";
    }

    //Loadmap
    public void IsTwo()
    {
        Me.text = "2";
    }

    //Extendmap
    public void IsThree()
    {
        Me.text = "3";
    }

    //Removemapextentions
    public void IsFour()
    {
        Me.text = "4";
    }

    //Deletemap
    public void IsFive()
    {
        Me.text = "5";
    }

    //Change Players Colors
    public void IsSix()
    {
        Me.text = "6";
    }

    //Send a mini to player
    public void IsSeven()
    {
        Me.text = "7";
    }
    
    //ClearVars
    public void IsEight()
    {
        Me.text = "8";
    }
}
