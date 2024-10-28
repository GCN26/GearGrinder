using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void textButton(string buttonType)
    {
        if (buttonType == "Credits")
        {
            //display credits
        }
        else if (buttonType == "Controls")
        {
            //display controls
            //use images
        }
    }
    public void QuitButton()
    {
        //close the game
    }
}
