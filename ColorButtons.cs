using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtons : MonoBehaviour {
    public InputField Red;
    public InputField Green;
    public InputField Blue;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BtnRed()
    {
        Red.text = "255";
        Green.text = "0";
        Blue.text = "0";
    }

    public void BtnGreen()
    {
        Red.text = "0";
        Green.text = "255";
        Blue.text = "0";
    }

    public void BtnBlue()
    {
        Red.text = "0";
        Green.text = "0";
        Blue.text = "255";
    }

    public void BtnLightBlue()
    {
        Red.text = "0";
        Green.text = "255";
        Blue.text = "255";
    }

    public void BtnPink()
    {
        Red.text = "255";
        Green.text = "0";
        Blue.text = "255";
    }

    public void BtnYellow()
    {
        Red.text = "255";
        Green.text = "255";
        Blue.text = "0";
    }

    public void BtnOrange()
    {
        Red.text = "255";
        Green.text = "127";
        Blue.text = "0";
    }
}
