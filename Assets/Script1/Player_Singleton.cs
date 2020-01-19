using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Singleton
{
    private  static Player_Singleton instance;
    public HealthBar healthBar;
    public Gun gun;
    public string ass6;
    public float currentHealth;
    

    

    public static Player_Singleton getInstance(Player_Singleton myObject)
    {
        if (instance == null)
        {
            instance = myObject;
            return instance;
            
        }
        else
        {
            return instance;
        }

        return null;

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
