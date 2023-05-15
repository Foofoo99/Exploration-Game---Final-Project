using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityScript : MonoBehaviour
{
    public static float sensitivity;

    public void ChangeSensitivity()
    {
        //set the mouse sensitivity to the value of the slider on the main menu
        sensitivity = this.gameObject.GetComponent<Slider>().value;
    }
}
