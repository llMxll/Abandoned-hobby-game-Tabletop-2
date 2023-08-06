using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;


public class PlayerTerrainEditor : NetworkBehaviour
{
    //General vars
    public Vector3 position;
    public Vector3 TilePosition;

    public bool Placing;
    public Text PlacingSelection;

    //Terrain Placer vars
    public Text Terrain;

    public GameObject TileToPlace;
    public GameObject TileToReplace;

    public GameObject BlackTile;
    public GameObject BrownTile;
    public GameObject WhiteTile;
    public GameObject GreyTile;
    public GameObject GreenTile;
    public GameObject BlueTile;
    public GameObject RedTile;

    //Miniture Placer vars
    public Text Miniture;

    public GameObject MiniToPlace;
    public GameObject MiniToReplace;

    public GameObject GuardToken;

    //Saving vars
    public Text MapSaveName;
    public int ObjectsSaved;

    public string CurrentSavedMaps;

    //Load vars
    public Text DrpMapSelect;
    public GameObject EmptyMap;
    public GameObject PlaneClear;

    public string LoadMapData;
    public string Tempitemname;
    public GameObject Itemtoinstantiate;
    public float TempItemPositionX;
    public float TempItemPositionY;
    public float TempItemPositionZ;

    //Server Trigger

    // Use this for initialization
    void Start()
    {

        foreach (UnityEngine.UI.Text FindMyLabel in UnityEngine.UI.Text.FindObjectsOfType<UnityEngine.UI.Text>())
            {
            if (FindMyLabel.name == "DrpPlacingLabel")
            {
                PlacingSelection = FindMyLabel;
            }

            if (FindMyLabel.name == "DrpTerrainLabel")
            {
                Terrain = FindMyLabel;
            }

            if (FindMyLabel.name == "DrpCreatureLabel")
            {
                Miniture = FindMyLabel;
            }

            if (FindMyLabel.name == "DrpCreatureLabel")
            {
                Miniture = FindMyLabel;
            }

            if (FindMyLabel.name == "InputMapSaveNameText")
            {
                MapSaveName = FindMyLabel;
            }

            if (FindMyLabel.name == "DrpMapSelectLabel")
            {
                DrpMapSelect = FindMyLabel;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
        {
            // Checks
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
            {
                Placing = true;
                Debug.Log("1");
            }

            if (Input.GetMouseButtonUp(0))
            {
                Placing = false;
            }

            // Start Replacement
            if (Placing == true && PlacingSelection.text == "Terrain")
            {
                // Find position
                locateposition();
                TilePosition = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
                CmdPlaceTerrain();
            }

            if (Placing == true && PlacingSelection.text == "Creature")
            {
                // Find position
                Debug.Log("2");
                locateposition();
                TilePosition = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
                if (Miniture.text == "Guard Token")
                {
                    MiniToPlace = GuardToken;
                    Debug.Log("2.1");
                }
                CmdPlaceMiniture(MiniToPlace, TilePosition);
            }

        }
    }


    void locateposition()
    {
        Debug.Log("Locating position");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

        }
    }

    [Command]
    public void CmdPlaceMiniture(GameObject MiniToPlace, Vector3 Tileposition)
    {
        //Decide on new tiletype
        Debug.Log("3");
        
        ServerPlaceMiniture(MiniToPlace, TilePosition);
    }

    [Server]
    public void ServerPlaceMiniture(GameObject MiniToPlace, Vector3 Tileposition)
    {
        //Add new tile
        GameObject Spawn = (GameObject)Instantiate(MiniToPlace, TilePosition, Quaternion.Euler(new Vector3(270, 0, 0)));
        Debug.Log("3.2");
        NetworkServer.Spawn(Spawn);
        Debug.Log("3.3");

        //Place only one
        Placing = false;
    }

    [Command]
    public void CmdPlaceTerrain()
    {
        //Delete old tile
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Terrain" && FindMyTile.transform.position == TilePosition)
            {
                TileToReplace = FindMyTile;

                Destroy(TileToReplace);

                //Decide on new tiletype
                if (Terrain.text == "Grey Square")
                {
                    TileToPlace = GreyTile;
                }
                if (Terrain.text == "Blue Square")
                {
                    TileToPlace = BlueTile;
                }
                if (Terrain.text == "Green Square")
                {
                    TileToPlace = GreenTile;
                }
                if (Terrain.text == "White Square")
                {
                    TileToPlace = WhiteTile;
                }
                if (Terrain.text == "Red Square")
                {
                    TileToPlace = RedTile;
                }
                if (Terrain.text == "Black Square")
                {
                    TileToPlace = BlackTile;
                }
                if (Terrain.text == "Brown Square")
                {
                    TileToPlace = BrownTile;
                }

                //Add new tile
                GameObject Spawn = (GameObject)Instantiate(TileToPlace, TilePosition, Quaternion.Euler(new Vector3(270, 0, 0)));
                NetworkServer.Spawn(Spawn);
            }
        }
    }

    public void SaveMap()
    {
        ObjectsSaved = 0;

        //Load current maps
        CurrentSavedMaps = PlayerPrefs.GetString("Map");

        //Add new map to current
        CurrentSavedMaps += MapSaveName.text + ";";

        //Save mapname
        PlayerPrefs.SetString("Map", CurrentSavedMaps);

        //Save map details
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Terrain")
            {
                PlayerPrefs.SetString(MapSaveName.text + "Name" + ObjectsSaved.ToString(), FindMyTile.name);

                PlayerPrefs.SetFloat(MapSaveName.text + "Positionx" + ObjectsSaved.ToString(), FindMyTile.transform.position.x);
                PlayerPrefs.SetFloat(MapSaveName.text + "Positiony" + ObjectsSaved.ToString(), FindMyTile.transform.position.y);
                PlayerPrefs.SetFloat(MapSaveName.text + "Positionz" + ObjectsSaved.ToString(), FindMyTile.transform.position.z);
                ObjectsSaved += 1;
            }

            if (FindMyTile.gameObject.tag == "Plane")
            {
                Debug.Log("SavingPlane");
                PlayerPrefs.SetString(MapSaveName.text + "Name" + ObjectsSaved.ToString(), FindMyTile.name);

                PlayerPrefs.SetFloat(MapSaveName.text + "Positionx" + ObjectsSaved.ToString(), FindMyTile.transform.position.x);
                PlayerPrefs.SetFloat(MapSaveName.text + "Positiony" + ObjectsSaved.ToString(), FindMyTile.transform.position.y);
                PlayerPrefs.SetFloat(MapSaveName.text + "Positionz" + ObjectsSaved.ToString(), FindMyTile.transform.position.z);
                ObjectsSaved += 1;
            }
        }
        PlayerPrefs.SetInt(MapSaveName.text + "ObjectsSaved", ObjectsSaved);
    }

    public void InstantiateMap()
    {
        //Destroy old map
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Terrain")
            {
                Destroy(FindMyTile);
            }

            if (FindMyTile.gameObject.tag == "Plane")
            {
                Destroy(FindMyTile);
            }
        }

        if (DrpMapSelect.text == "Empty Map")
        {
            Debug.Log("Loadingnew");
            GameObject Spawn = (GameObject)Instantiate(EmptyMap, new Vector3(0.5f, -0.001f, 0.5f), Quaternion.identity);
            NetworkServer.Spawn(Spawn);
        }

        if (DrpMapSelect.text != "Empty Map")
        {
            //Get number objects saved
            ObjectsSaved = PlayerPrefs.GetInt(DrpMapSelect.text + "ObjectsSaved");

            //Get details
            for (int x = 0; x < ObjectsSaved; x++)
            {
                // Get item type
                Tempitemname = PlayerPrefs.GetString(DrpMapSelect.text + "Name" + x);

                if (Tempitemname == "Plane")
                {
                    Itemtoinstantiate = PlaneClear;
                }
                if (Tempitemname == "PlaneClear(Clone)")
                {
                    Itemtoinstantiate = PlaneClear;
                }
                if (Tempitemname == "GridSquareWhite(Clone)")
                {
                    Itemtoinstantiate = WhiteTile;
                }
                if (Tempitemname == "GridSquareBlue(Clone)")
                {
                    Itemtoinstantiate = BlueTile;
                }
                if (Tempitemname == "GridSquareGreen(Clone)")
                {
                    Itemtoinstantiate = GreenTile;
                }
                if (Tempitemname == "GridSquareGrey(Clone)")
                {
                    Itemtoinstantiate = GreyTile;
                }
                if (Tempitemname == "GridSquareRed(Clone)")
                {
                    Itemtoinstantiate = RedTile;
                }
                if (Tempitemname == "GridSquareBlack(Clone)")
                {
                    Itemtoinstantiate = BlackTile;
                }
                if (Tempitemname == "GridSquareBrown(Clone)")
                {
                    Itemtoinstantiate = BrownTile;
                }



                TempItemPositionX = PlayerPrefs.GetFloat(DrpMapSelect.text + "Positionx" + x);
                TempItemPositionY = PlayerPrefs.GetFloat(DrpMapSelect.text + "Positiony" + x);
                TempItemPositionZ = PlayerPrefs.GetFloat(DrpMapSelect.text + "Positionz" + x);

                // Instantiate
                if (Itemtoinstantiate != PlaneClear)
                {
                    GameObject Spawn = (GameObject)Instantiate(Itemtoinstantiate, new Vector3(TempItemPositionX, TempItemPositionY, TempItemPositionZ), Quaternion.Euler(270, 0, 0));
                    NetworkServer.Spawn(Spawn);
                }
                else
                {
                    GameObject Spawn = (GameObject)Instantiate(Itemtoinstantiate, new Vector3(TempItemPositionX, TempItemPositionY, TempItemPositionZ), Quaternion.identity);
                    NetworkServer.Spawn(Spawn);
                }
            }
        }

    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
