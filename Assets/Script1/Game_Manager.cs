using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [Tooltip("This is the target frame rate for the application to run")]
    public int targetFrameRate;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        QualitySettings.vSyncCount = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (Application.targetFrameRate != targetFrameRate)
        {
            Application.targetFrameRate = targetFrameRate;
            
        }
        if (QualitySettings.vSyncCount != 0;)
        {
            QualitySettings.vSyncCount = 0;
        }
        
    }
}
