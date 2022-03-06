using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDirections : MonoBehaviour
{
    public Vector3 currentRetation;
    public Vector3 currentRetation2;
    public bool isTurnUp;
    public bool isTurnDown;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        currentRetation = new Vector3(0, 0, -90f); // clock wise
        currentRetation2 = new Vector3(0, 0, 90f); // clock wise
        // if he get clicked turn
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.rotation.SetAxisAngle(Vector2.up, 90);
            //transform.Rotate(Vector3.forward * -90f); // clock wise
            transform.Rotate(currentRetation); // clock wise
            isTurnDown = false;
            isTurnUp = true;
            Debug.Log("Works up");         
         
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isTurnUp = false;
            isTurnDown = true;
            transform.Rotate(currentRetation2); // BASE ON DOWN
            Debug.Log("Works down");

        }

    }
}
