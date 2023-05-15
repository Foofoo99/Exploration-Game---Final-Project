using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public Image crosshair1, crosshair2;
    public int deaths = 0;
    public Rigidbody rb;
    public bool canGrapple = true, stuckCheck, grappleDeathCheck;
    public AudioSource deathSound, hammerSound, bounceSound, music;
    private bool sqrted, grappling;
    public static bool amongusAchievement = false, bonked = false, splat = false, stuck = false, boom = false, infinity = false, anakin = false;

    //these must be fields for SpamCheck to work even though they are only used in that method 
    private int consecClicks = 0, maxClicks = 9;
    private float timeLastClicked = -1, maxTimeInterval = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        //hide and lock cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //get the player's rigidbody component
        rb = GetComponent<Rigidbody>();
        //set volume for sounds in game scene
        deathSound.volume = VolumeScript.volume;
        hammerSound.volume = VolumeScript.volume;
        bounceSound.volume = VolumeScript.volume;
        music.volume = VolumeScript.volume/2;
        //disable crosshair if player changed that setting
        if(!AdvancedSettings.showCross)
        {
            crosshair1.gameObject.SetActive(false);
            crosshair2.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //sequence of actions during the game
        Grapple(crosshair1, crosshair2);
        if(!grappling)
        {
            MovePlayer();
            RotatePlayer();
        }
        if(Input.GetMouseButtonUp(0))
        {
            canGrapple = true;
        }
        DeathCheck();
        SpamCheck();
        StuckCheck();
        AchievementsCheck();
    }
    public void RotatePlayer()
    {
        //get the value from the mouse sensitivity script and calculate it to enable the camera to rotate properly
        float mouseSensitivity = MouseSensitivityScript.sensitivity * 133;

        if(mouseSensitivity <= 0)
        {
            mouseSensitivity = 100;
        }
        //rotate player based on horizontal mouse
        float mouseRotationX = Input.GetAxis("Mouse X");
        if (AdvancedSettings.invertX)
        {
            mouseRotationX *= -1;
        }
        transform.Rotate(0, mouseRotationX * mouseSensitivity * Time.deltaTime, 0);

        //vertical camera rotation
        float mouseRotationY = Input.GetAxis("Mouse Y");
        if (AdvancedSettings.invertY)
        {
            mouseRotationY *= -1;
        }
        playerCamera.transform.Rotate(-mouseRotationY * mouseSensitivity * Time.deltaTime, 0, 0);
    }
    public void MovePlayer()
    {
        //base movement speed
        float speed = AdvancedSettings.speed;

        //make sure the player faces the correct direction from the perspective of the camera
        Vector3 verticalMovement = transform.rotation * Vector3.forward;
        Vector3 horizontalMovement = transform.rotation * Vector3.right;

        //w, a, s, d or arrow keys move the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += horizontalInput * speed * Time.deltaTime * horizontalMovement;
        transform.position += verticalInput * speed * Time.deltaTime * verticalMovement;

        //prevent strafing (diagonal movement that is quicker than straight movement)
        if (horizontalInput != 0 && verticalInput != 0 && !sqrted)
        {
            speed = Mathf.Sqrt(speed);
            sqrted = true;
        }
        else
        {
            speed = AdvancedSettings.speed;
            sqrted = false;
        }
    }
    public void Grapple(Image crosshair1, Image crosshair2)
    {
        //variables for the grapple action
        float grappleDistance = AdvancedSettings.grappleDistance;
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //detect the thing to grapple with, then the position of that thing, then move toward that position
        if(Physics.Raycast(cameraRay, out RaycastHit hitObject, grappleDistance) && hitObject.collider.name.StartsWith("Grapple") && canGrapple)
        {
            //set crosshair color
            crosshair1.color = Color.green;
            crosshair2.color = Color.green;
            //if the mouse is down, move towards the grapple point, turn off gravity, and tell the other parts of the script that the player is grappling
            if (Input.GetMouseButton(SetGrappleMouseClick()))
            {
                Vector3 worldPosition = hitObject.point;
                float grappleSpeed = AdvancedSettings.grappleSpeed;
                transform.position = Vector3.MoveTowards(transform.position, worldPosition, grappleSpeed * Time.deltaTime);
                rb.useGravity = false;
                grappling = true;
                float yVelocity;
                if (rb.velocity.y < 0)
                {
                    yVelocity = 0;
                }
                else
                {
                    yVelocity = rb.velocity.y * 0.3f;
                }
                rb.velocity = playerCamera.transform.forward * 5 + new Vector3(0, yVelocity, 0);
            }
            else
            {
                grappling = false;
                rb.useGravity = true;
            }
        }
        else
        {
            //change the crosshair color and turn on gravity
            crosshair1.color = Color.white;
            crosshair2.color = Color.white;
            grappling = false;
            rb.useGravity = true;
        }
    }
    private void DeathCheck()
    {
        //runs if the player has died from falling beneath the map
        if(transform.position.y <= -10)
        {
            if(!splat)
            {
                AchievementsScript.splat = true;
                splat = true;
            }
            Respawn();
        }
    }
    private void Respawn()
    {
        //play the death sound, turn on gravity, reset the player position, increase deaths, and turn off the stuck detection
        deathSound.Play();
        rb.useGravity = true;
        transform.position = Vector3.up;
        deaths++;
        stuckCheck = false;
        grappleDeathCheck = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //when the player collides with a grappleable object, gravity is turned on and the player can't grapple until they release the mouse button
        if(Input.GetMouseButton(0) && collision.gameObject.name.StartsWith("Grapple"))
        {
            rb.useGravity = true;
            canGrapple = false;
        }
        //play a sound when the player hits a hammer
        if(collision.gameObject.name.StartsWith("Hammer"))
        {
            hammerSound.Play();
            bonked = true;
        }
        if(collision.gameObject.name.StartsWith("mogus") && !amongusAchievement)
        {
            amongusAchievement = true;
        }
        if(transform.position.y > collision.transform.position.y && !anakin && collision.gameObject.name.StartsWith("Anakin"))
        {
            anakin = true;
        }
    }
    private void SpamCheck()
    {
        //detect if the player is spamming the grappling hook, and make the player respawn if they are
        if(Input.GetMouseButtonDown(0))
        {
            consecClicks++;
            timeLastClicked = Time.time;
        }
        if(Time.time > timeLastClicked + maxTimeInterval)
        {
            consecClicks = 0;
        }
        if(consecClicks > maxClicks)
        {
            if(!boom)
            {
                AchievementsScript.boom = true;
                boom = true;
            }
            Respawn();
            grappleDeathCheck = true;
            consecClicks = 0;
        }
    }
    private void StuckCheck()
    {
        //if the player is in the inescapable room, tell the player that they are stuck
        double XBound = 9.5;
        double ZBound1 = 10.5;
        double ZBound2 = 29.5;

        if(transform.position.x > -XBound && transform.position.x < XBound && transform.position.z > ZBound1 && transform.position.z < ZBound2 && transform.position.y == 1)
        {
            if(!stuck)
            {
                AchievementsScript.stuck = true;
                stuck = true;
            }
            stuckCheck = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the player lands on a bounce pad, bounce them up and play a sound
        if (other.gameObject.name.StartsWith("Bouncy"))
        {
            rb.AddForce(0, -AdvancedSettings.bounciness * rb.velocity.y, 0, ForceMode.Impulse);
            bounceSound.Play();
        }
    }

    private void AchievementsCheck()
    {
        AchievementsScript.amongusAchievement = amongusAchievement;
        AchievementsScript.bonked = bonked;
        AchievementsScript.anakin = anakin;
        if(rb.velocity.magnitude >= 110)
        {
            AchievementsScript.supersonic = true;
        }
    }

    public int SetGrappleMouseClick()
    {
        if(AdvancedSettings.rightClickGrapple)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}