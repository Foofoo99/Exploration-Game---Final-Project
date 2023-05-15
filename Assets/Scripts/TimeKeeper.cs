using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public static float startTime, currentSeconds = 0, tenSeconds = 0, currentMinutes = 0, tenMinutes = 0;

    // Start is called before the first frame update
    void Start()
    {
        //reset all the time related variables
        startTime = Time.time;
        currentSeconds = 0;
        tenSeconds = 0;
        currentMinutes = 0;
        tenMinutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //logic for formatting the timer text in the game
        currentSeconds = Time.time - startTime - tenSeconds * 10 - currentMinutes * 60 - tenMinutes * 600;
        if(currentSeconds >= 10)
        {
            currentSeconds -= 10;
            tenSeconds++;
        }
        if(tenSeconds >= 6)
        {
            tenSeconds -= 6;
            currentMinutes++;
        }
        if(currentMinutes >= 10)
        {
            currentMinutes -= 10;
            tenMinutes++;
        }
    }
}
