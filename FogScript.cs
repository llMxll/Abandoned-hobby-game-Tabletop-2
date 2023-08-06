using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogScript : MonoBehaviour
{

    public Text DrpPlayerNameLabel;
    private float DimX;
    private float DimY;
    private float DimZ;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FogEffectLocal()
    {
        SetVars();

        if (DrpPlayerNameLabel.text != "Dungeon Master")
        {
            foreach (GameObject FogOut in GameObject.FindObjectsOfType<GameObject>())
            {
                if (FogOut.transform.position.x >= this.transform.position.x && FogOut.transform.position.y >= this.transform.position.y && FogOut.transform.position.z >= this.transform.position.z
                    && FogOut.transform.position.x < this.transform.position.x + DimX && FogOut.transform.position.y < this.transform.position.y + DimY && FogOut.transform.position.z < this.transform.position.z + DimZ)
                {
                    // Turn off mesh renderer
                    if (FogOut.transform.childCount > 0 && FogOut.tag != "Untagged")
                    {
                        FogOut.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                    }

                    else if (FogOut.tag != "Untagged")
                    {
                        FogOut.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }
    }

    public void RemoveFogEffectLocal()
    {
        SetVars();
        if (DrpPlayerNameLabel.text != "Dungeon Master")
        {
            foreach (GameObject FogOut in GameObject.FindObjectsOfType<GameObject>())
            {
                if (FogOut.transform.position.x >= this.transform.position.x && FogOut.transform.position.y >= this.transform.position.y && FogOut.transform.position.z >= this.transform.position.z
                    && FogOut.transform.position.x < this.transform.position.x + DimX && FogOut.transform.position.y < this.transform.position.y + DimY && FogOut.transform.position.z < this.transform.position.z + DimZ)
                {

                    // Turn on mesh renderer
                    if (FogOut.transform.childCount > 0 && FogOut.tag != "Untagged" && FogOut.tag != "Fog")
                    {
                        FogOut.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    }

                    else if (FogOut.tag != "Untagged" && FogOut.tag != "Fog")
                    {
                        FogOut.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
        }
    }

    private void SetVars()
    {
        foreach (UnityEngine.UI.Text FindMyLabel in UnityEngine.UI.Text.FindObjectsOfType<UnityEngine.UI.Text>())
        {
            if (FindMyLabel.name == "DrpCharacterSelectedLabel")
            {
                DrpPlayerNameLabel = FindMyLabel;
            }
        }

        DimX = this.transform.GetChild(0).transform.localScale.x;
        DimY = this.transform.GetChild(0).transform.localScale.y;
        DimZ = this.transform.GetChild(0).transform.localScale.z;
    }
}