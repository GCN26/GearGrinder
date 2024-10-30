using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject subPanel;
    public GameObject subButton;
    public GameObject ctrlText;
    public GameObject ctrlTitle;
    public GameObject credText;
    public GameObject credTitle;
    public AudioClip buttonPress;
    public AudioSource audiosrc;
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        audiosrc = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void textButton(string buttonType)
    {
        subPanel.SetActive(true);
        subButton.SetActive(true);
        if (buttonType == "Credits")
        {
            //display credits
            ctrlText.SetActive(false);
            ctrlTitle.SetActive(false);
            credText.SetActive(true);
            credTitle.SetActive(true);
        }
        else if (buttonType == "Controls")
        {
            ctrlText.SetActive(true);
            ctrlTitle.SetActive(true);
            credText.SetActive(false);
            credTitle.SetActive(false);
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void CloseSubMenu()
    {
        //set submenu panel and all text objects to inactive
        subButton.SetActive(false);
        ctrlText.SetActive(false);
        ctrlTitle.SetActive(false);
        credText.SetActive(false);
        credTitle.SetActive(false);
        subPanel.SetActive(false);
    }
    public void PauseButtonSound()
    {
        audiosrc.PlayOneShot(buttonPress, 0.75f);
    }
}
