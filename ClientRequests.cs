using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientRequests : NetworkBehaviour
{

    private GameObject ClientsMini;
    private GameObject ClientsTTObj;
    private GameObject ClientsObject;
    private GameObject ClientsTerrain;
    public GameObject TileToReplace;
    private GameObject ClientsMiniToMove;
    private GameObject ClientsTTObjToMove;
    public Text DrpCharacterSelected;

    // SaveMap
    public int ObjectsSaved;
    public string CurrentSavedMaps;

    // Loadmap
    public GameObject EmptyMap;
    public GameObject PlaneClear;

    public string LoadMapData;
    public string Tempitemname;
    public GameObject Itemtoinstantiate;
    public float TempItemPositionX;
    public float TempItemPositionY;
    public float TempItemPositionZ;
    public float TempItemRotationX;
    public float TempItemRotationY;
    public float TempItemRotationZ;

    //Deletemap
    private string TempMap;
    private string NewMapString;

    //ExteandMap
    public int ExtMapLeft;
    public int ExtMapUp;
    public int ExtMapRight;
    public int ExtMapDown;

    //FOG
    public GameObject FogCube;

    // MINIS
    public GameObject GuardToken;

    //OBJECTS
    public GameObject Bed;

    // TERRAINS
    public GameObject BlackTile;
    public GameObject BrownTile;
    public GameObject WhiteTile;
    public GameObject GreyTile;
    public GameObject GreenTile;
    public GameObject BlueTile;
    public GameObject RedTile;
    public GameObject WoodTile;
    public GameObject WaterTile;
    public GameObject DirtTile;
    public GameObject GrassTile;

    public GameObject WoodBlock;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [Server]
    public void ClientRequestLoadMap(string SelectedMap)
    {
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Terrain" || FindMyTile.gameObject.tag == "Mini" || FindMyTile.gameObject.tag == "Object" || FindMyTile.gameObject.tag =="Fog")
            {
                NetworkServer.Destroy(FindMyTile);
            }

            if (FindMyTile.gameObject.tag == "Plane")
            {
                NetworkServer.Destroy(FindMyTile);
            }
        }

        if (SelectedMap == "Empty Map")
        {
            ExtMapUp = 0;
            ExtMapLeft = 0;
            ExtMapDown = 0;
            ExtMapRight = 0;

            GameObject Spawn = (GameObject)Instantiate(EmptyMap, new Vector3(0.5f, -0.001f, 0.5f), Quaternion.identity);
            NetworkServer.Spawn(Spawn);
        }

        if (SelectedMap != "Empty Map")
        {
            //Get number objects saved
            ExtMapUp = PlayerPrefs.GetInt(SelectedMap + "ExtUp");
            ExtMapLeft = PlayerPrefs.GetInt(SelectedMap + "ExtLeft");
            ExtMapDown = PlayerPrefs.GetInt(SelectedMap + "ExtDown");
            ExtMapRight = PlayerPrefs.GetInt(SelectedMap + "ExtRight");

            ObjectsSaved = PlayerPrefs.GetInt(SelectedMap + "ObjectsSaved");

            //Get details
            for (int x = 0; x < ObjectsSaved; x++)
            {
                // Get item type
                if (PlayerPrefs.HasKey(SelectedMap + "Name" + x))
                {
                    Tempitemname = PlayerPrefs.GetString(SelectedMap + "Name" + x);

                    //TERRAINS
                    if (Tempitemname == "Plane")
                    {
                        Itemtoinstantiate = PlaneClear;
                    }
                    if (Tempitemname == "Plane(Clone)")
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
                    if (Tempitemname == "GridSquareWater(Clone)")
                    {
                        Itemtoinstantiate = WaterTile;
                    }
                    if (Tempitemname == "GridSquareDirt(Clone)")
                    {
                        Itemtoinstantiate = DirtTile;
                    }
                    if (Tempitemname == "GridSquareWood(Clone)")
                    {
                        Itemtoinstantiate = WoodTile;
                    }
                    if (Tempitemname == "GridSquareGrass(Clone)")
                    {
                        Itemtoinstantiate = GrassTile;
                    }


                    if (Tempitemname == "WoodBlock(Clone)")
                    {
                        Itemtoinstantiate = WoodBlock;
                    }


                    // MINITURES
                    if (Tempitemname == "GuardToken(Clone)")
                    {
                        Itemtoinstantiate = GuardToken;
                    }

                    //OBJECTS
                    if (Tempitemname == "Bed(Clone)")
                    {
                        Itemtoinstantiate = Bed;
                    }

                    //FOG
                    if (Tempitemname == "Fog(Clone)")
                    {
                        Itemtoinstantiate = FogCube;
                    }

                    TempItemPositionX = PlayerPrefs.GetFloat(SelectedMap + "Positionx" + x);
                    TempItemPositionY = PlayerPrefs.GetFloat(SelectedMap + "Positiony" + x);
                    TempItemPositionZ = PlayerPrefs.GetFloat(SelectedMap + "Positionz" + x);
                    TempItemRotationX = PlayerPrefs.GetFloat(SelectedMap + "Rotationx" + x);
                    TempItemRotationY = PlayerPrefs.GetFloat(SelectedMap + "Rotationy" + x);
                    TempItemRotationZ = PlayerPrefs.GetFloat(SelectedMap + "Rotationz" + x);

                    // Instantiate
                    if (Itemtoinstantiate != PlaneClear)
                    {
                        GameObject Spawn = (GameObject)Instantiate(Itemtoinstantiate, new Vector3(TempItemPositionX, TempItemPositionY, TempItemPositionZ), Quaternion.Euler(TempItemRotationX, TempItemRotationY, TempItemRotationZ));

                        if (Spawn.transform.childCount > 0)
                        {
                            float DimX = PlayerPrefs.GetFloat(SelectedMap + "DimX" + x);
                            float DimY = PlayerPrefs.GetFloat(SelectedMap + "DimY" + x);
                            float DimZ = PlayerPrefs.GetFloat(SelectedMap + "DimZ" + x);
                            float Height = PlayerPrefs.GetFloat(SelectedMap + "Height" + x);

                            NetworkServer.Spawn(Spawn);
                            RpcFixChildDimensions(Spawn, DimX, DimY, DimZ, Height);
                        }

                        else
                        {
                            NetworkServer.Spawn(Spawn);
                        }

                    }

                    else
                    {
                        GameObject Spawn = (GameObject)Instantiate(Itemtoinstantiate, new Vector3(TempItemPositionX, TempItemPositionY, TempItemPositionZ), Quaternion.identity);
                        NetworkServer.Spawn(Spawn);
                    }
                }
            }
        }

    }

    [Server]
    public void ClientRequestGiveMini(string InputGive, string Miniture)
    {
        RpcGiveMiniOnClients(InputGive, Miniture);
    }

    [ClientRpc]
    public void RpcGiveMiniOnClients(string InputGive, string Miniture)
    {
        // Save to all clients playerprefs the character name and mini name
        // Call all clients to refresh creatures tab
        string MyMinis = PlayerPrefs.GetString(InputGive + "MyMinis");

        MyMinis += Miniture + ";";

        PlayerPrefs.SetString(InputGive + "MyMinis", MyMinis);

        foreach (GameObject FindPlayerSaves in GameObject.FindObjectsOfType<GameObject>())
        {
            if (FindPlayerSaves.name == "Player saves")
            {
                FindPlayerSaves.GetComponent<PlayerSaves>().PlayerMinis();
            }
        }
    }

    [Server]
    public void ClientRequestColorChange(GameObject Player, string NewRed, string NewGreen, string NewBlue)
    {
        RpcColorChangeOnClients(Player, NewRed, NewGreen, NewBlue);
    }

    [ClientRpc]
    public void RpcColorChangeOnClients(GameObject Player, string NewRed, string NewGreen, string NewBlue)
    {
        Player.GetComponent<Renderer>().material.color = new Color(float.Parse(NewRed), float.Parse(NewGreen), float.Parse(NewBlue), 0);
    }

    [Server]
    public void ClientRequestMapDelete(string DrpMapSelectLabel)
    {
        RpcDeleteMapsOnClients(DrpMapSelectLabel);
    }

    [ClientRpc]
    public void RpcDeleteMapsOnClients(string DrpMapSelectLabel)
    {
        ObjectsSaved = PlayerPrefs.GetInt(DrpMapSelectLabel + "ObjectsSaved");

        //Delete details
        for (int x = 0; x < ObjectsSaved; x++)
        {
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "Name" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "Positionx" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "Positiony" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "Positionz" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "DimX" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "DimY" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "DimZ" + x);
            PlayerPrefs.DeleteKey(DrpMapSelectLabel + "Height" + x);
        }

        //Delete extra little bits
        PlayerPrefs.DeleteKey(DrpMapSelectLabel + "ObjectsSaved");
        PlayerPrefs.DeleteKey(DrpMapSelectLabel + "ExtUp");
        PlayerPrefs.DeleteKey(DrpMapSelectLabel + "ExtLeft");
        PlayerPrefs.DeleteKey(DrpMapSelectLabel + "ExtDown");
        PlayerPrefs.DeleteKey(DrpMapSelectLabel + "ExtRight");

        //Delete name from list
        CurrentSavedMaps = PlayerPrefs.GetString("Map");

        string[] splitcontent = CurrentSavedMaps.Split(';');

        for (int x = 0; x < splitcontent.Length - 1; x++)
        {
            TempMap = splitcontent[x];
            if (TempMap != DrpMapSelectLabel)
            {
                NewMapString += TempMap + ";";
            }
        }

        PlayerPrefs.SetString("Map", NewMapString);

        foreach (GameObject LinkToClientMappicker in Object.FindObjectsOfType<GameObject>())
        {
            if (LinkToClientMappicker.name == "DrpMapPicker")
            {
                LinkToClientMappicker.GetComponent<MapSelectScript>().LoadMaps();
            }
        }

        NewMapString = null;
    }

    [Server]
    public void ClientRequestMapExtendRemove(string ExtendDir)
    {
        if (ExtendDir == "Up" && ExtMapUp != 0)
        {
            foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
            {
                if (FindMyTile.gameObject.tag == "Terrain" && FindMyTile.transform.position.z > 10.5f + ((ExtMapUp - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }

                if (FindMyTile.gameObject.tag == "Plane" && FindMyTile.transform.position.z > 10.5f + ((ExtMapUp - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }
            }

            ExtMapUp -= 1;
        }

        if (ExtendDir == "Left" && ExtMapLeft != 0)
        {
            foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
            {
                if (FindMyTile.gameObject.tag == "Terrain" && FindMyTile.transform.position.x < -9.5f - ((ExtMapLeft - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }

                if (FindMyTile.gameObject.tag == "Plane" && FindMyTile.transform.position.x < -9.5f - ((ExtMapLeft - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }
            }

            ExtMapLeft -= 1;
        }

        if (ExtendDir == "Down" && ExtMapDown != 0)
        {
            foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
            {
                if (FindMyTile.gameObject.tag == "Terrain" && FindMyTile.transform.position.z < -9.5f - ((ExtMapDown - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }

                if (FindMyTile.gameObject.tag == "Plane" && FindMyTile.transform.position.z < -9.5f - ((ExtMapDown - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }
            }

            ExtMapDown -= 1;
        }

        if (ExtendDir == "Right" && ExtMapRight != 0)
        {
            foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
            {
                if (FindMyTile.gameObject.tag == "Terrain" && FindMyTile.transform.position.x > 10.5f + ((ExtMapRight - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }

                if (FindMyTile.gameObject.tag == "Plane" && FindMyTile.transform.position.x > 10.5f + ((ExtMapRight - 1) * 20))
                {
                    NetworkServer.Destroy(FindMyTile);
                }
            }

            ExtMapRight -= 1;
        }
    }

    [Server]
    public void ClientRequestMapExtend(string ExtendDir)
    {
        if (ExtendDir == "Up")
        {
            for (int x = 0; x < (ExtMapLeft + ExtMapRight + 1); x++)
            {
                float XOffset = 0.5f - (ExtMapLeft * 20f) + (x * 20f);
                float ZOffset = 0.5f + ((ExtMapUp + 1) * 20f);
                GameObject Spawn = (GameObject)Instantiate(EmptyMap, new Vector3(XOffset, -0.001f, ZOffset), Quaternion.identity);
                NetworkServer.Spawn(Spawn);
            }
            ExtMapUp += 1;
        }

        if (ExtendDir == "Left")
        {
            for (int x = 0; x < (ExtMapDown + ExtMapUp + 1); x++)
            {
                float XOffset = 0.5f - ((ExtMapLeft + 1) * 20f);
                float ZOffset = 0.5f - (ExtMapDown * 20f) + (x * 20f);

                GameObject Spawn = (GameObject)Instantiate(EmptyMap, new Vector3(XOffset, -0.001f, ZOffset), Quaternion.identity);
                NetworkServer.Spawn(Spawn);
            }
            ExtMapLeft += 1;
        }

        if (ExtendDir == "Down")
        {
            for (int x = 0; x < (ExtMapLeft + ExtMapRight + 1); x++)
            {
                float XOffset = 0.5f - (ExtMapLeft * 20f) + (x * 20f);
                float ZOffset = 0.5f - ((ExtMapDown + 1) * 20f);
                GameObject Spawn = (GameObject)Instantiate(EmptyMap, new Vector3(XOffset, -0.001f, ZOffset), Quaternion.identity);
                NetworkServer.Spawn(Spawn);
            }
            ExtMapDown += 1;
        }

        if (ExtendDir == "Right")
        {
            for (int x = 0; x < (ExtMapDown + ExtMapUp + 1); x++)
            {
                float XOffset = 0.5f + ((ExtMapRight + 1) * 20f);
                float ZOffset = 0.5f - (ExtMapDown * 20f) + (x * 20f);

                GameObject Spawn = (GameObject)Instantiate(EmptyMap, new Vector3(XOffset, -0.001f, ZOffset), Quaternion.identity);
                NetworkServer.Spawn(Spawn);
            }
            ExtMapRight += 1;
        }
    }

    [Server]
    public void ClientRequestSaveMap(string MapName)
    {
        RpcSaveMapsOnClients(MapName, ObjectsSaved);
    }

    [ClientRpc]
    public void RpcSaveMapsOnClients(string MapName, int ObjectsSaved)
    {
        ObjectsSaved = 0;

        //Load current maps
        CurrentSavedMaps = PlayerPrefs.GetString("Map");

        //Add new map to current
        CurrentSavedMaps += MapName + ";";

        //Save mapname
        PlayerPrefs.SetString("Map", CurrentSavedMaps);

        //Save map details
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Terrain" || FindMyTile.gameObject.tag == "Mini" || FindMyTile.gameObject.tag == "Object" || FindMyTile.gameObject.tag == "Fog")
            {
                PlayerPrefs.SetString(MapName + "Name" + ObjectsSaved.ToString(), FindMyTile.name);

                PlayerPrefs.SetFloat(MapName + "Positionx" + ObjectsSaved.ToString(), FindMyTile.transform.position.x);
                PlayerPrefs.SetFloat(MapName + "Positiony" + ObjectsSaved.ToString(), FindMyTile.transform.position.y);
                PlayerPrefs.SetFloat(MapName + "Positionz" + ObjectsSaved.ToString(), FindMyTile.transform.position.z);
                PlayerPrefs.SetFloat(MapName + "Rotationx" + ObjectsSaved.ToString(), FindMyTile.transform.rotation.eulerAngles.x);
                PlayerPrefs.SetFloat(MapName + "Rotationy" + ObjectsSaved.ToString(), FindMyTile.transform.rotation.eulerAngles.y);
                PlayerPrefs.SetFloat(MapName + "Rotationz" + ObjectsSaved.ToString(), FindMyTile.transform.rotation.eulerAngles.z);

                if (FindMyTile.transform.childCount > 0)
                {
                    float DimX = FindMyTile.transform.GetChild(0).transform.localScale.x * 2;
                    float DimY = FindMyTile.transform.GetChild(0).transform.localScale.y * 2;
                    float DimZ = FindMyTile.transform.GetChild(0).transform.localScale.z * 2;
                    float Height = FindMyTile.transform.GetChild(0).transform.localPosition.z;

                    PlayerPrefs.SetFloat(MapName + "DimX" + ObjectsSaved, DimX);
                    PlayerPrefs.SetFloat(MapName + "DimY" + ObjectsSaved, DimY);
                    PlayerPrefs.SetFloat(MapName + "DimZ" + ObjectsSaved, DimZ);
                    PlayerPrefs.SetFloat(MapName + "Height" + ObjectsSaved, Height);
                }


                ObjectsSaved += 1;
            }

            if (FindMyTile.gameObject.tag == "Plane")
            {
                PlayerPrefs.SetString(MapName + "Name" + ObjectsSaved.ToString(), FindMyTile.name);

                PlayerPrefs.SetFloat(MapName + "Positionx" + ObjectsSaved.ToString(), FindMyTile.transform.position.x);
                PlayerPrefs.SetFloat(MapName + "Positiony" + ObjectsSaved.ToString(), FindMyTile.transform.position.y);
                PlayerPrefs.SetFloat(MapName + "Positionz" + ObjectsSaved.ToString(), FindMyTile.transform.position.z);
                ObjectsSaved += 1;
            }
        }

        PlayerPrefs.SetInt(MapName + "ObjectsSaved", ObjectsSaved);
        PlayerPrefs.SetInt(MapName + "ExtUp", ExtMapUp);
        PlayerPrefs.SetInt(MapName + "ExtLeft", ExtMapLeft);
        PlayerPrefs.SetInt(MapName + "ExtDown", ExtMapDown);
        PlayerPrefs.SetInt(MapName + "ExtRight", ExtMapRight);

        foreach (GameObject LinkToMapMan in Object.FindObjectsOfType<GameObject>())
        {
            if (LinkToMapMan.name == "DrpMapPicker")
            {
                LinkToMapMan.GetComponent<MapSelectScript>().LoadMaps();
            }
        }
    }


    [Server]
    public void ClientRequestRemoveFromGame(string LastChosenMini, Vector3 LastChosenMiniPos)
    {
        foreach (GameObject FindMyMiniToDelete in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyMiniToDelete.transform.position == LastChosenMiniPos && FindMyMiniToDelete.name == LastChosenMini)
            {
                Destroy(FindMyMiniToDelete);
            }
        }
    }

    [Server]
    public void ClientRequestMiniProne(string LastChosenMini, Vector3 LastChosenMiniPos, Quaternion LastChosenMiniRotate)
    {
        foreach (GameObject FindMyMiniToRotate in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyMiniToRotate.name == LastChosenMini && FindMyMiniToRotate.transform.position == LastChosenMiniPos)
            {
                ClientsMiniToMove = FindMyMiniToRotate;
            }
        }

        Debug.Log(ClientsMiniToMove.transform.eulerAngles);

        if (ClientsMiniToMove.transform.eulerAngles.y == 0)
        {
            ClientsMiniToMove.transform.Rotate(0, 90, 0);
        }

        else if (ClientsMiniToMove.transform.eulerAngles.y != 0)
        {
            ClientsMiniToMove.transform.Rotate(0, -90, 0);
        }


    }

    [Server]
    public void ClientRequestMiniRotate(string LastChosenMini, Vector3 LastChosenMiniPos, Quaternion LastChosenMiniRotate)
    {
        foreach (GameObject FindMyMiniToRotate in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyMiniToRotate.name == LastChosenMini && FindMyMiniToRotate.transform.position == LastChosenMiniPos)
            {
                ClientsMiniToMove = FindMyMiniToRotate;
            }
        }

        ClientsMiniToMove.transform.rotation = LastChosenMiniRotate;
    }

    [Server]
    public void ClientRequestMiniMove(Vector3 TilePosition, string LastChosenMini, Vector3 LastChosenMiniPos, float Height)
    {
        foreach (GameObject FindMyMiniToMove in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyMiniToMove.name == LastChosenMini && FindMyMiniToMove.transform.position == LastChosenMiniPos)
            {
                ClientsMiniToMove = FindMyMiniToMove;
            }
        }
        ClientsMiniToMove.transform.position = TilePosition;

        if (ClientsMiniToMove.transform.childCount > 0)
        {
            Vector3 CurrentPos = ClientsMiniToMove.transform.GetChild(0).transform.localPosition;

            RpcFixChildPosition(ClientsMiniToMove, CurrentPos.x, CurrentPos.y, CurrentPos.z, Height);
        }

        RpcCheckVisable(ClientsMiniToMove, TilePosition);
    }

    [Server]
    public void ClientRequestMini(Vector3 TilePosition, string MinitureText, float DimX, float DimY, float DimZ, float Height)
    {
        if (MinitureText == "Guard Token")
        {
            ClientsMini = GuardToken;
        }

        GameObject Spawn = (GameObject)Instantiate(ClientsMini, TilePosition, Quaternion.Euler(new Vector3(270, 0, 0)));

        NetworkServer.Spawn(Spawn);
        RpcFixChildDimensions(Spawn, DimX, DimY, DimZ, Height);
        RpcCheckVisable(Spawn, TilePosition);
    }

    [Server]
    public void ClientRequestFog(Vector3 TilePosition, float DimX, float DimY, float DimZ, float Height)
    {
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Fog" && FindMyTile.transform.position == TilePosition)
            {
                TileToReplace = FindMyTile;
            }

            else TileToReplace = null;

            Destroy(TileToReplace);
        }

        GameObject Spawn = (GameObject)Instantiate(FogCube, TilePosition, Quaternion.Euler(new Vector3(0, 0, 0)));

        NetworkServer.Spawn(Spawn);
        RpcFixChildDimensions(Spawn, DimX, DimY, DimZ, Height);
        RpcFogeffect(Spawn);
    }

    [Server]
    public void ClientRequestRemoveFog(Vector3 TilePosition)
    {
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Fog" && FindMyTile.transform.position == TilePosition)
            {
                TileToReplace = FindMyTile;
                RpcRemoveFogeffect(TileToReplace);
            }

            else TileToReplace = null;

            Destroy(TileToReplace);
        }
    }

    [Server]
    public void ClientRequestRemoveObjFromGame(string LastChosenTTObj, Vector3 LastChosenTTObjPos)
    {
        foreach (GameObject FindMyTTObjToDelete in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTTObjToDelete.transform.position == LastChosenTTObjPos && FindMyTTObjToDelete.name == LastChosenTTObj)
            {
                Destroy(FindMyTTObjToDelete);
            }
        }
    }

    [Server]
    public void ClientRequestTTObjRotate(string LastChosenTTObj, Vector3 LastChosenTTObjPos, Quaternion LastChosenTTObjRotate)
    {
        foreach (GameObject FindMyTTObjToRotate in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTTObjToRotate.name == LastChosenTTObj && FindMyTTObjToRotate.transform.position == LastChosenTTObjPos)
            {
                ClientsTTObjToMove = FindMyTTObjToRotate;
            }
        }

        ClientsTTObjToMove.transform.rotation = LastChosenTTObjRotate;
    }

    [Server]
    public void ClientRequestTTObjMove(Vector3 TilePosition, string LastChosenTTObj, Vector3 LastChosenTTObjPos, float Height)
    {
        foreach (GameObject FindMyTTObjToMove in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTTObjToMove.name == LastChosenTTObj && FindMyTTObjToMove.transform.position == LastChosenTTObjPos)
            {
                ClientsTTObjToMove = FindMyTTObjToMove;
            }
        }
        ClientsTTObjToMove.transform.position = TilePosition;

        if (ClientsTTObjToMove.transform.childCount > 0)
        {
            Vector3 CurrentPos = ClientsTTObjToMove.transform.GetChild(0).transform.localPosition;

            RpcFixChildPosition(ClientsTTObjToMove, CurrentPos.x, CurrentPos.y, CurrentPos.z, Height);
        }

        RpcCheckVisable(ClientsTTObjToMove, TilePosition);
    }

    [Server]
    public void ClientRequestTTObj(Vector3 TilePosition, string TTObjText, float DimX, float DimY, float DimZ, float Height)
    {
        if (TTObjText == "Bed")
        {
            ClientsTTObj = Bed;
        }

        GameObject Spawn = (GameObject)Instantiate(ClientsTTObj, TilePosition, Quaternion.Euler(new Vector3(270, 0, 0)));

        NetworkServer.Spawn(Spawn);
        RpcFixChildDimensions(Spawn, DimX, DimY, DimZ, Height);
        RpcCheckVisable(Spawn, TilePosition);
    }

    [Server]
    public void ClientRequestTTObject(Vector3 TilePosition, string TTObjectText, float DimX, float DimY, float DimZ, float Height)
    {
        if (TTObjectText == "Bed")
        {
            ClientsObject = Bed;
        }

        GameObject Spawn = (GameObject)Instantiate(ClientsObject, TilePosition, Quaternion.Euler(new Vector3(270, 0, 0)));

        NetworkServer.Spawn(Spawn);
        RpcFixChildDimensions(Spawn, DimX, DimY, DimZ, Height);
    }

    [Server]
    public void ClientRequestTerrain(Vector3 TilePosition, string TerrainText, float DimX, float DimY, float DimZ)
    {
        foreach (GameObject FindMyTile in Object.FindObjectsOfType<GameObject>())
        {
            if (FindMyTile.gameObject.tag == "Terrain" && FindMyTile.transform.position == TilePosition)
            {
                TileToReplace = FindMyTile;

                Destroy(TileToReplace);

                //Decide on new tiletype
                if (TerrainText == "Grey Square")
                {
                    ClientsTerrain = GreyTile;
                }
                if (TerrainText == "Blue Square")
                {
                    ClientsTerrain = BlueTile;
                }
                if (TerrainText == "Green Square")
                {
                    ClientsTerrain = GreenTile;
                }
                if (TerrainText == "White Square")
                {
                    ClientsTerrain = WhiteTile;
                }
                if (TerrainText == "Red Square")
                {
                    ClientsTerrain = RedTile;
                }
                if (TerrainText == "Black Square")
                {
                    ClientsTerrain = BlackTile;
                }
                if (TerrainText == "Brown Square")
                {
                    ClientsTerrain = BrownTile;
                }
                if (TerrainText == "Water Square")
                {
                    ClientsTerrain = WaterTile;
                }
                if (TerrainText == "Dirt Square")
                {
                    ClientsTerrain = DirtTile;
                }
                if (TerrainText == "Grass Square")
                {
                    ClientsTerrain = GrassTile;
                }
                if (TerrainText == "Wood Square")
                {
                    ClientsTerrain = WoodTile;
                }


                if (TerrainText == "Wood Block")
                {
                    ClientsTerrain = WoodBlock;
                }

                GameObject Spawn = (GameObject)Instantiate(ClientsTerrain, TilePosition, Quaternion.Euler(new Vector3(270, 0, 0)));
                NetworkServer.Spawn(Spawn);

                RpcFixChildDimensions(Spawn, DimX, DimY, DimZ, 0);
            }
        }
    }

    [ClientRpc]
    public void RpcFixChildDimensions(GameObject Spawn, float DimX, float DimY, float DimZ, float Height)
    {
        if (Spawn.transform.childCount > 0)
        {
            if (Spawn.tag == "Terrain")
            {
                Spawn.transform.GetChild(0).transform.localPosition = new Vector3((DimX - 1) * 0.5f, (DimY - 1) * 0.5f, 0.5f + (DimZ - 1) * 0.5f);
                Spawn.transform.GetChild(0).transform.localScale = new Vector3(DimX / 2, DimY / 2, DimZ / 2);
            }

            if (Spawn.tag == "Fog")
            {
                Spawn.transform.GetChild(0).transform.localPosition = new Vector3((DimX - 1) * 0.5f, 0.5f + (DimY - 1) * 0.5f, (DimZ - 1) * 0.5f);
                Spawn.transform.GetChild(0).transform.localScale = new Vector3(DimX, DimY, DimZ);
            }

            if (Spawn.tag == "Mini")
            {
                Spawn.transform.GetChild(0).transform.localPosition = new Vector3((DimX - 1) * 0.5f, (DimY - 1) * 0.5f, Height);
                Spawn.transform.GetChild(0).transform.localScale = new Vector3(DimX / 2, DimY / 2, DimZ / 2);
            }

            if (Spawn.tag == "Object")
            {
                Spawn.transform.GetChild(0).transform.localPosition = new Vector3((DimX - 1) * 0.5f, (DimY - 1) * 0.5f, Height);
                Spawn.transform.GetChild(0).transform.localScale = new Vector3(DimX / 2, DimY / 2, DimZ / 2);
            }
        }
    }

    [ClientRpc]
    public void RpcFixChildPosition(GameObject Spawn, float PosX, float PosY, float PosZ, float Height)
    {
        if (Spawn.transform.childCount > 0)
        {
            Spawn.transform.GetChild(0).transform.localPosition = new Vector3(PosX, PosY, Height);
        }
    }

    [ClientRpc]
    public void RpcFogeffect(GameObject Spawn)
    {
        Spawn.GetComponent<FogScript>().FogEffectLocal();
    }

    [ClientRpc]
    public void RpcRemoveFogeffect(GameObject FogBeingRemoved)
    {
        FogBeingRemoved.GetComponent<FogScript>().RemoveFogEffectLocal();
    }

    [ClientRpc]
    public void RpcCheckVisable(GameObject ObjToCheck, Vector3 TilePosition)
    {
        if (DrpCharacterSelected.text != "Dungeon Master")
        {
            bool Visable = true;
            foreach (GameObject Fogs in Object.FindObjectsOfType<GameObject>())
            {
                if (Fogs.tag == "Fog")
                {

                    float DimX = Fogs.transform.GetChild(0).transform.localScale.x;
                    float DimY = Fogs.transform.GetChild(0).transform.localScale.y;
                    float DimZ = Fogs.transform.GetChild(0).transform.localScale.z;


                    if (TilePosition.x >= Fogs.transform.position.x && TilePosition.y >= Fogs.transform.position.y && TilePosition.z >= Fogs.transform.position.z
                       && TilePosition.x < Fogs.transform.position.x + DimX && TilePosition.y < Fogs.transform.position.y + DimY && TilePosition.z < Fogs.transform.position.z + DimZ)
                    {
                        Visable = false;
                    }
                }
            }

            if (Visable == true)
            {
                ObjToCheck.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            }

            if (Visable == false)
            {
                ObjToCheck.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
