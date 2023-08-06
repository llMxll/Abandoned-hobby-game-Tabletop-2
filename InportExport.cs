using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InportExport : MonoBehaviour {

    public Text DrpInputExportType;
    public InputField InputData;
    private string MapStringDumps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExportSaves()
    {
        InputData.text = null;
        MapStringDumps = null;

        if (DrpInputExportType.text == "Maps")
        {
            string AllMaps = PlayerPrefs.GetString("Map");
            Debug.Log("exporting maps;" + AllMaps);

            string[] splitcontent = AllMaps.Split(';');

            for (int y = 0; y < splitcontent.Length - 1; y++)
            {
                Debug.Log("map found");
                string tempname = PlayerPrefs.GetString(splitcontent[y] + "Name" + y);

                float ExtMapUp = PlayerPrefs.GetInt(splitcontent[y] + "ExtUp");
                float ExtMapLeft = PlayerPrefs.GetInt(splitcontent[y] + "ExtLeft");
                float ExtMapDown = PlayerPrefs.GetInt(splitcontent[y] + "ExtDown");
                float ExtMapRight = PlayerPrefs.GetInt(splitcontent[y] + "ExtRight");

                float ObjectsSaved = PlayerPrefs.GetInt(splitcontent[y] + "ObjectsSaved");

                MapStringDumps += tempname + " " + ExtMapUp + " " + ExtMapLeft + " " + ExtMapDown + " " + ExtMapRight + " " +
                   ObjectsSaved + " ";

                for (int x = 0; x < ObjectsSaved; x++)
                {
                    float TempItemPositionX = PlayerPrefs.GetFloat(splitcontent[y] + "Positionx" + x);
                    float TempItemPositionY = PlayerPrefs.GetFloat(splitcontent[y] + "Positiony" + x);
                    float TempItemPositionZ = PlayerPrefs.GetFloat(splitcontent[y] + "Positionz" + x);
                    float TempItemRotationX = PlayerPrefs.GetFloat(splitcontent[y] + "Rotationx" + x);
                    float TempItemRotationY = PlayerPrefs.GetFloat(splitcontent[y] + "Rotationy" + x);
                    float TempItemRotationZ = PlayerPrefs.GetFloat(splitcontent[y] + "Rotationz" + x);

                    float DimX = PlayerPrefs.GetFloat(splitcontent[y] + "DimX" + x);
                    float DimY = PlayerPrefs.GetFloat(splitcontent[y] + "DimY" + x);
                    float DimZ = PlayerPrefs.GetFloat(splitcontent[y] + "DimZ" + x);
                    float Height = PlayerPrefs.GetFloat(splitcontent[y] + "Height" + x);

                    MapStringDumps += " " + TempItemPositionX + " " + TempItemPositionY + " " + TempItemPositionZ + " " + TempItemRotationX + " " +
                    TempItemRotationY + " " + TempItemRotationZ + " " + DimX + " " + DimY + " " + DimZ + " " +
                    Height;
                }
            }
                InputData.text = MapStringDumps;
            //PlayerPrefs.GetString("Maps") + "**" + MapStringDumps;
        }
    }

    public void InportSaves()
    {

    }
}
