using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LaunchBall : MonoBehaviour
{
    public AudioSource bonk;
    private Rigidbody rb;
    public static bool blinko = false, ten = false;
    private int blinkoCount = 0;
    public GameObject elevator;
    public GameObject elevator2;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bonk.volume = VolumeScript.volume;
    }

    // Update is called once per frame
    void Update()
    {
        //if b is pushed, start blinko
        if(Input.GetKeyDown(KeyCode.B) && transform.position.x == 23)
        {
            rb.AddForce(new Vector3(10, 10, Random.Range(-3f, 3f)), ForceMode.Impulse);
            if(!blinko)
            {
                blinko = true;
            }
            blinkoCount++;
        }
        //if the ball falls down, reset it
        if(transform.position.y < -10)
        {
            if(gameObject.name.StartsWith("BallOnPath"))
            {
                transform.position = new Vector3(-26, 36, -75);
            }
            else
            {
                transform.position = new Vector3(23, 31.5f, -25);
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            elevator.transform.position = new Vector3(29.5f, 20, -19);
            elevator.GetComponent<Rigidbody>().velocity = Vector3.zero;
            elevator2.transform.position = new Vector3(33.75f, 16.5f, -30.5f);
            elevator2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        AchievementsCheck();
    }

    public void OnCollisionEnter(Collision collision)
    {
        //when the ball touches something, sound plays and if it is the back wall, the ball cannot bounce away from blinko.
        bonk.Play();
        if(collision.gameObject.name.StartsWith("Back"))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if(gameObject.name.StartsWith("BallOnPath") && collision.gameObject.name.StartsWith("FlingBox"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(new Vector3(13, 20, 17), ForceMode.Impulse);
        }
    }
    private void AchievementsCheck()
    {
        if(blinkoCount == 10 && !ten)
        {
            AchievementsScript.ten = true;
            ten = true;
        }
        AchievementsScript.blinko = blinko;
    }

}