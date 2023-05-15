using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AdvancedSettings advancedSettings;

    public void LoadScene(string sceneName)
    {
        //load the specified scene and unpause time if needed, and if the loaded scene is the main menu, reset all the timer related variables
        if(sceneName == "IntroductionScene")
        {
            TimeKeeper.currentSeconds = 0;
            TimeKeeper.tenSeconds = 0;
            TimeKeeper.currentMinutes = 0;
            TimeKeeper.tenMinutes = 0;
        }
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        //if this comes into contact with the player, show the cursor and check which scene should be loaded
        if(other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if(this.name.StartsWith("Secret"))
            {
                AchievementsScript.backrooms = true;
                LoadScene("SecretFinish");
            }
            else
            {
                LoadScene("FinishGame");
            }
        }
    }
}