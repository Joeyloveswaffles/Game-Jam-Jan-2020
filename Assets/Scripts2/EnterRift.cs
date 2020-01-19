using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRift : MonoBehaviour
{
    public LevelChanger levelChanger;
    public int debug;
    public bool riftPresent;
    public int riftLevelIndex;
    public bool playerWithinRange;

    private void Start()
    {
        playerWithinRange = false;
    }

    private void Update()
    {
        debug = getCurrentLevelIndex();
        findRift();
        if (Input.GetButtonDown("Interact") && playerWithinRange)
        {
            if (getCurrentLevelIndex() == 0)
            {
                Debug.Log("changing scenes");
                levelChanger.FadeToLevel(riftLevelIndex);

            }
            else
            {
                Debug.Log("changing scenes");
                levelChanger.FadeToLevel(0);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerWithinRange = true;
        }
        /*
        if (playerWithinRange)
        {
            if (getCurrentLevelIndex() == 0)
            {
                Debug.Log("changing scenes");
                LevelChanger.Instance.FadeToLevel(riftLevelIndex);
                
            }
            else
            {
                Debug.Log("changing scenes");
                LevelChanger.Instance.FadeToLevel(0);
            }
            
        }*/
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            playerWithinRange = false;
        }
    }

    public int getCurrentLevelIndex()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        return currentLevelIndex;
    }
    

    public bool findRift()
    {
        if (GameObject.Find("Rift") == false)
        {
            return true;
        }
        return false;
    }
    /*
    void LoadBattleScreen()
    {
        GameController.control.inBattle = true;
        Destroy(GameObject.Find("Enemy"));
        GameController.control.playerDead = true;
        Application.LoadLevel(sceneToLoad);
    }*/
}
