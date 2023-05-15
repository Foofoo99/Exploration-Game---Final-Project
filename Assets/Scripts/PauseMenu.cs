using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public GameObject resumeButton, menuButton;

    // Start is called before the first frame update
    void Start()
    {
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CheckPause();
        }
    }
    public void CheckPause()
    {
        //if the game is paused, unpause the game and if the game is unpaused, pause the game
        if(paused)
        {
            Time.timeScale = 1;
            paused = false;
            resumeButton.SetActive(false);
            menuButton.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            resumeButton.SetActive(true);
            menuButton.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}