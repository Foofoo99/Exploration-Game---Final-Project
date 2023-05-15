using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalTextUpdate : MonoBehaviour
{
    public TMP_Text time;
    public AudioSource music;
    public static bool bronze = false, silver = false, gold = false, author = false;

    // Start is called before the first frame update
    void Start()
    {
        //set the text for the game completion screen
        time.text = "Final time: " + TimeKeeper.tenMinutes + TimeKeeper.currentMinutes + ":" + TimeKeeper.tenSeconds + TimeKeeper.currentSeconds.ToString("n2");
        if(AdvancedSettings.speed == 3 && AdvancedSettings.grappleDistance == 10 && AdvancedSettings.bounciness == 2.05f && AdvancedSettings.grappleSpeed == 20)
        {
            bronze = true;
            if (TimeKeeper.currentMinutes < 1 && TimeKeeper.tenMinutes < 1)
            {
                silver = true;
                if (TimeKeeper.tenSeconds < 2)
                {
                    gold = true;
                    if (TimeKeeper.currentSeconds < 3.58 && TimeKeeper.tenSeconds < 1)
                    {
                        time.text += "\nYou beat the developer's personal record. Congralations!";
                        author = true;
                    }
                    else
                    {
                        time.text += "\nYou got the Gold Medal: Sub 20 seconds.\nNext is the Author Medal/Developer's Best Time: 3.58 seconds";
                    }
                }
                else
                {
                    time.text += "\nYou got the Silver Medal: Sub 1:00.\nNext is the Gold Medal: Sub 20 seconds.";
                }
            }
            else
            {
                time.text += "\nYou got the Bronze Medal: Game completed.\nNext is the Silver Medal: Sub 1:00.";
            }
        }
        else
        {
            time.text += "\nYou changed one of the advanced settings that makes you ineligible for a medal. Try again with the default settings.";
            AchievementsScript.invalid = true;
        }
        music.volume = VolumeScript.volume;
        AchievementsScript.bronze = bronze;
        AchievementsScript.silver = silver;
        AchievementsScript.gold = gold;
        AchievementsScript.author = author;
    }
}