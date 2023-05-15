using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public AudioSource menuMusic;
    public static float volume;

    // Start is called before the first frame update
    private void Start()
    {
        menuMusic.volume = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        //set the volume for the game equal to the value of the slider component for other scripts to call
        volume = this.gameObject.GetComponent<Slider>().value;
    }
    public void ChangeVolume()
    {
        //set the volume of the music in the main menu to the value of the slider divided by 5
        menuMusic.volume = volume / 5;
        if(menuMusic.volume < 0.005f)
        {
            menuMusic.volume = 0;
        }
    }
}
