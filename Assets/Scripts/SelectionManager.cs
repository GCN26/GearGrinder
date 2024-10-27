using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower, selectedTowerGhost;
    public int selectedCost;
    public GameObject baseGrid;

    public GameObject pawn, shield, leech, tank;

    public AmNode[] nodes = { };
    public AmNode[] nodes2 = { };
    public GameObject[] hpDisplay = { };
    public TextMeshProUGUI moneyCounter;

    public int hp;
    
    public int money;

    public float spawnTimer;
    public float spawnTarget;
    public float increaseTimer;
    public float increaseTarget;
    private GameObject toSpawn;
    public bool spawnBool = false;
    public int i = 0;

    public bool spawnOE;

    public bool paused = false;
    public GameObject pausePanel;
    public GameObject resumeButton;
    public GameObject pauseButtons;
    public TextMeshProUGUI GOVText;
    public GameObject pauseStopper;
    public bool gameOver = false;

    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Update()
    {
        if (gameOver != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!paused)
                {
                    PauseGame();
                }
                else
                {
                    UnpauseGame();
                }
            }
        }

        if(hp <= 0)
        {
            PauseGOV();
        }

        moneyCounter.text = "$" + money;
        if(spawnBool == true)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnTarget)
            {
                i++;
                if (i != 45)
                {
                    if (i % 5 == 0 && i != 0 && i < 35) spawnTarget -= .25f;
                    Debug.Log(i);
                    var randE = Random.Range(1, 8);
                    if (randE >= 1 && randE <= 4) toSpawn = pawn;
                    else if (randE >= 5 && randE <= 6) toSpawn = shield;
                    else if (randE == 7) toSpawn = leech;
                }
                else
                {
                    toSpawn = tank;
                    spawnBool = false;
                    spawnTarget = 2.5f;
                }
                spawnEnemy(toSpawn);
                spawnTimer = 0;


            }
        }
    }

    public void switchTower(GameObject tower)
    {
        selectedTower = tower;
    }
    public void switchGhost(GameObject ghost)
    {
        selectedTowerGhost = ghost;
    }
    public void switchCost(int cost)
    {
        selectedCost = cost;
    }
    public bool spend()
    {
        if (money - selectedCost >= 0)
        {
            money -= selectedCost;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void spawnEnemy(GameObject enemy)
    {
        GameObject spawn;
        Vector3 spawnPos = new Vector3 (-4.75f, 5.68f, 0);
        if (spawnOE == false)
        {
            spawnPos = new Vector3(-4.75f, 5.68f, 0);
        }
        else
        {
            spawnPos = new Vector3(-11.98f, -1.72f, 0);
        }

        spawn = Instantiate(enemy, spawnPos, transform.rotation);
        if(enemy == pawn) spawn.name = "Pawn";
        else if (enemy == shield) spawn.name = "Shield";
        else if (enemy == leech) spawn.name = "Leech";
        else if (enemy == tank) spawn.name = "Tank";

        if (spawnOE == false) spawn.GetComponent<BaseEnemyScript>().nodes = nodes;
        else spawn.GetComponent<BaseEnemyScript>().nodes = nodes2;

        spawnOE = !spawnOE;
    }

    public void startSpawn()
    {
        spawnBool = true;
    }
    public void PauseGOV()
    {
        Time.timeScale = 0f;
        pausePanel.gameObject.SetActive(true);
        pauseButtons.gameObject.SetActive(true);
        GOVText.gameObject.SetActive(true);
        pauseStopper.SetActive(true);
        paused = true;
        gameOver = true;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.gameObject.SetActive(true);
        pauseButtons.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        pauseStopper.SetActive(true);
        paused = true;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.gameObject.SetActive(false);
        pauseButtons.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        pauseStopper.SetActive(false);
        paused = false;
    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene("Game");
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ButtonExit()
    {
        //quit game
    }
}
