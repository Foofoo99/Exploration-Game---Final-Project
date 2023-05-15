using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdvancedSettings : MonoBehaviour
{
    public TMP_Text text1, text2, text3, text4;
    public Button button1, button2, button3, button4, button5;
    public Toggle box1, box2, box3, box4, box5, box6, box7, box8;
    public Slider slider1, slider2, slider3, slider4;
    public bool setting = false;

    public static bool showTimer, showDeath, deathCount, showCross, invertX, invertY, showAchievements, rightClickGrapple;
    public static float speed, grappleDistance, bounciness, grappleSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && !setting)
        {
            EnableAdvancedSettings();
        }
        else if(Input.GetMouseButtonDown(1) && setting)
        {
            DisableAdvancedSettings();
        }
        CheckSettings();
    }
    public void EnableAdvancedSettings()
    {
        text1.enabled = false;
        text2.enabled = false;
        text3.gameObject.SetActive(true);
        text4.gameObject.SetActive(true);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);
        button4.gameObject.SetActive(false);
        button5.gameObject.SetActive(false);
        box1.gameObject.SetActive(true);
        box2.gameObject.SetActive(true);
        box3.gameObject.SetActive(true);
        box4.gameObject.SetActive(true);
        box5.gameObject.SetActive(true);
        box6.gameObject.SetActive(true);
        box7.gameObject.SetActive(true);
        box8.gameObject.SetActive(true);
        slider1.gameObject.SetActive(true);
        slider2.gameObject.SetActive(true);
        slider3.gameObject.SetActive(true);
        slider4.gameObject.SetActive(true);
        setting = true;
    }
    public void DisableAdvancedSettings()
    {
        text1.enabled = true;
        text2.enabled = true;
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(false);
        button4.gameObject.SetActive(true);
        button5.gameObject.SetActive(true);
        box1.gameObject.SetActive(false);
        box2.gameObject.SetActive(false);
        box3.gameObject.SetActive(false);
        box4.gameObject.SetActive(false);
        box5.gameObject.SetActive(false);
        box6.gameObject.SetActive(false);
        box7.gameObject.SetActive(false);
        box8.gameObject.SetActive(false);
        slider1.gameObject.SetActive(false);
        slider2.gameObject.SetActive(false);
        slider3.gameObject.SetActive(false);
        slider4.gameObject.SetActive(false);
        setting = false;
    }
    public void CheckSettings()
    {
        showTimer = box1.isOn;
        showDeath = box2.isOn;
        deathCount = box3.isOn;
        showCross = box4.isOn;
        invertX = box5.isOn;
        invertY = box6.isOn;
        showAchievements = box7.isOn;
        rightClickGrapple = box8.isOn;
        speed = slider1.value;
        grappleDistance = slider2.value;
        bounciness = slider3.value;
        grappleSpeed = slider4.value;
    }
}