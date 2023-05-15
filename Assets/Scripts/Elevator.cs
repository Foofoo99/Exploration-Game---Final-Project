using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name.StartsWith("Ball"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 60), ForceMode.Acceleration);
        }
        if(gameObject.name.StartsWith("Platform") && collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(5, 20), ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collided)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
        if(gameObject.name.StartsWith("Anakin") && !collided)
        {
            collided = true;
        }
        
    }
}
