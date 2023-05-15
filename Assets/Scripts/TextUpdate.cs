using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    public PlayerController playerController;
    public int deaths;
    public TMP_Text deathCount, deathText, timerText;
    private static bool amongus, boom, bonked, blinko, splat, supersonic, ten, anakin;

    // Update is called once per frame
    void Update()
    {
        //check which death message to show when the player dies if it wasn't turned off in advanced settings
        if(playerController.deaths > deaths)
        {
            deaths = playerController.deaths;
            if(AdvancedSettings.deathCount)
            {
                deathCount.text = "Deaths: " + deaths;
            }
            if(playerController.grappleDeathCheck && AdvancedSettings.showDeath)
            {
                deathText.text = "Grappling hook overheated (stop spam clicking!)";
            }
            else if(AdvancedSettings.showDeath)
            {
                deathText.text = "You fell out of the testing area.";
            }
        }
        if(playerController.stuckCheck && AdvancedSettings.showDeath)
        {
            deathText.text = "You are stuck in the inescapable room. Go to the main menu and try not to come back here.";
        }
        //show the timer text formatted properly if it wasn't turned off in advanced settings
        if(AdvancedSettings.showTimer)
        {
            timerText.SetText("Time: " + TimeKeeper.tenMinutes.ToString("n0") + TimeKeeper.currentMinutes.ToString("n0") + ":" + TimeKeeper.tenSeconds.ToString("n0") + TimeKeeper.currentSeconds.ToString("n2"));
        }
        if(AdvancedSettings.showAchievements)
        {
            if(AchievementsScript.amongusAchievement && !amongus)
            {
                deathText.text = "Achievement achieved: Amongus";
                amongus = true;
            }
            if(AchievementsScript.boom && !boom)
            {
                deathText.text = "Achievement achieved: Boom";
                boom = true;
            }
            if (AchievementsScript.bonked && !bonked)
            {
                deathText.text = "Achievement achieved: Bonked";
                bonked = true;
            }
            if(AchievementsScript.blinko && !blinko)
            {
                deathText.text = "Achievement achieved: Blinko";
                blinko = true;
            }
            if(AchievementsScript.splat && !splat)
            {
                deathText.text = "Achievement achieved: Splat";
                splat = true;
            }
            if(AchievementsScript.supersonic && !supersonic)
            {
                deathText.text = "Achievement achieved: Supersonic";
                supersonic = true;
            }
            if (AchievementsScript.ten && !ten)
            {
                deathText.text = "Achievement achieved: 10x Blinko";
                ten = true;
            }
            if(AchievementsScript.anakin && !anakin)
            {
                deathText.text = "Achievement achieved: It's over Anakin";
                anakin = true;
            }
        }
    }
}