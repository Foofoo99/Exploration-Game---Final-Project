using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera playerCamera;
    public Rigidbody playerRB;
    // Update is called once per frame
    void Update()
    {
        //make the camera follow the player in first person
        playerCamera.transform.position = new Vector3(playerRB.transform.position.x, playerRB.transform.position.y + 0.48f, playerRB.transform.position.z);
    }
}
