using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridToggle : MonoBehaviour {

    public GameObject Grid;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleGrid()
    {
        if (Grid.activeInHierarchy)
        {
            Grid.SetActive(false);
        }

        else
        {
            Grid.SetActive(true);
        }
    }
}
