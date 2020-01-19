using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button aboutButton;
    public LevelChanger levelChanger;

    public int startBuildIndex;
    public int exitBuildIndex;
    public int aboutBuildIndex;

    public string start;
    public string exit;
    public string about;


    // Start is called before the first frame update
    void Start()
    {
        Button strt = startButton.GetComponent<Button>();
        Button ext = startButton.GetComponent<Button>();
        Button abt = startButton.GetComponent<Button>();
        strt.onClick.AddListener(handleStart);
        ext.onClick.AddListener(handleExit);
        abt.onClick.AddListener(handleAbout);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleStart()
    {
        levelChanger.FadeToLevel(startBuildIndex);
    }
    public void handleExit()
    {
        levelChanger.FadeToLevel(exitBuildIndex);
    }
    public void handleAbout()
    {
        levelChanger.FadeToLevel(aboutBuildIndex);
    }
}
