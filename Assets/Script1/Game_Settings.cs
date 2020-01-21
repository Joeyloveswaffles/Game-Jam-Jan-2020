using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Settings : MonoBehaviour
{
    public Sound_Settings soundSettings;
    public Graphic_Settings graphicSettings;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (soundSettings == null)
        {
            Debug.LogError("Sound settings was destroyed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
