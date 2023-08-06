using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CamMoveScript : NetworkBehaviour
{
    Vector2 input;
    public float speed;
    public float y;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    public bool Rightdwn;

    [SerializeField]
    Behaviour[] componentsToDisable;
    
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 8, 0);

        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }

        //Register palyer
        string _ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }

    // Update is called once per frame
    void Update()
    {
            // Moving
            if (!isLocalPlayer)
        {
            return;
        }

        else if (!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(1))
            {
                Rightdwn = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                Rightdwn = false;
            }

            //Move camera
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f * speed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * speed;

            if (Input.GetKeyDown(KeyCode.LeftShift) == true)
            {
                y = -1 * Time.deltaTime * 3.0f * speed;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) == true)
            {
                y = 1 * Time.deltaTime * 3.0f * speed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                y = 0;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) == true)
            {
                y = 0;
            }
            transform.Translate(x, y, z);



            //Rotate
            if (Rightdwn == true)
            {
                yaw += speed * Input.GetAxis("Mouse X");
                pitch -= speed * Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
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
    
