using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [Header("Tags, DO NOT SET")]
    public const string PlayerTag = "Player";
    public const string GameControllerTag = "Game Controller";

    public int targetFrameRate;
    public Canvas screenOverlay;
    public GameObject player;

    [Header("Debug")]
    public float mouseX;
    public float mouseY;

    public float CenterX;
    public float CenterY;
    // Start is called before the first frame update
    void Start()
    {
        CenterX = 550.0f;
        CenterY = 250.0f;
        if (targetFrameRate == 0)
        {
            targetFrameRate = 120;
        }
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            mouseX = Input.mousePosition.x;
            mouseY = Input.mousePosition.y;

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject newPlayer = Instantiate(player, new Vector3(10, 10, 0), Quaternion.identity) as GameObject;
                newPlayer.name = "Player";
              
        }
        
        
    }
}
