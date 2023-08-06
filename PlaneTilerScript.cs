using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlaneTilerScript : NetworkBehaviour {
    public GameObject BaseTile;
    public GameObject Plane;
    private int width = 20;
    private int length = 20;
    public float height;
    public float topleftX;
    public float topleftZ;
    private Vector3 SpawnLocation;

    // Use this for initialization
    void Start () {
        if (isServer)
        {
            SpawnLocation = new Vector3(Plane.transform.position.x + topleftX, Plane.transform.position.y + height, Plane.transform.position.z + topleftZ);

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    GameObject Spawn = (GameObject)Instantiate(BaseTile, new Vector3(x + SpawnLocation.x, SpawnLocation.y, z + SpawnLocation.z), Quaternion.Euler(new Vector3(270, 0, 0)));
                    NetworkServer.Spawn(Spawn);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
