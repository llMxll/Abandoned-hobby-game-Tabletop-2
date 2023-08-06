using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MiniMover : NetworkBehaviour {
    public GameObject LastChosenMini;
    public GameObject ChosenMini;

    private Vector3 position;
    private Vector3 TilePosition;

    public Text PlacingSelection;

    //rotation vars
    private bool rotating;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Select and move
        if (Input.GetMouseButtonDown(0) && PlacingSelection.text == "Moving" && rotating == false)
        {
            // Remember last chosen mini
            if (ChosenMini != null)
            {
                LastChosenMini = ChosenMini;
            }
            
            // Refresh chosen mini and locate click
            ChosenMini = null;
            locateposition();
            TilePosition = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));

            foreach (GameObject FindMyMini in Object.FindObjectsOfType<GameObject>())
            {
                //Select new mini
                if (FindMyMini.gameObject.tag == "Mini" && FindMyMini.transform.position == TilePosition)
                {
                    ChosenMini = FindMyMini;
                }
            }

            //Move
            if (LastChosenMini != null && ChosenMini == null)
            {
                LastChosenMini.transform.position = TilePosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && LastChosenMini!= null && PlacingSelection.text == "Moving")
        {
            rotating = true;
        }
        if (rotating == true && Input.GetMouseButtonDown(0))
        {
            rotating = false;
        }

        if (rotating == true && PlacingSelection.text == "Moving")
        {
            LastChosenMini.transform.Rotate(0, 0, (Input.GetAxis("Mouse X")) * 20);
        }
    }

    void locateposition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

        }
    }

    public void RemoveFromGame()
    {
        Destroy(LastChosenMini);
    }
}
