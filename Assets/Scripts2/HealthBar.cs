﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private Player_Singleton instance;
    public Image greenHealthBar;
    public Image whiteHealthBar;
    public float maxHealth = 100;
    public float currentHealth;
    public bool coolingDown;
    public float waitTime = 420.0f;
    public float currentFillPercent;
    public bool inVoid;

    private void Start()
    {
        currentHealth = maxHealth;
        instance = Player_Singleton.getInstance(new Player_Singleton());


        if (instance.currentHealth == null)
        {
            instance.currentHealth = currentHealth;
            Debug.LogError("asss");
        }
        else
        {
            currentHealth = instance.currentHealth;
        }
        currentHealth = instance.currentHealth;
    }
    // Update is called once per frame
    void Update()
    {
        currentHealth = greenHealthBar.fillAmount * 100;
        currentFillPercent = greenHealthBar.fillAmount;
        /*
        if(whiteHealthBar.fillAmount <= greenHealthBar.fillAmount)
        {
            whiteHealthBar.fillAmount += .01f;
        }*/
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            inVoid = true;
        }
        else
        {
            inVoid = false;

        }
        if (inVoid == true)
        {
            StartCoroutine(depleteHealth());
        }
    }

    IEnumerator depleteHealth()
    {
        float time = Time.deltaTime;

        if (currentHealth <= 100)
        {
            greenHealthBar.fillAmount -= 0.75f / waitTime * time;
            yield return new WaitForSeconds(3);
            whiteHealthBar.fillAmount -= 0.75f / waitTime * time;
        }
        else if (currentHealth <= 80)
        {
            greenHealthBar.fillAmount -= 0.875f / waitTime * time;
            yield return new WaitForSeconds(3);
            whiteHealthBar.fillAmount -= 0.875f / waitTime * time;
        }
        else if (currentHealth <= 60)
        {
            greenHealthBar.fillAmount -= 0.9375f / waitTime * time;
            yield return new WaitForSeconds(3);
            whiteHealthBar.fillAmount -= 0.9375f / waitTime * time;
        }
        else if (currentHealth <= 40)
        {
            greenHealthBar.fillAmount -= 0.96875f / waitTime * time;
            yield return new WaitForSeconds(3);
            whiteHealthBar.fillAmount -= 0.98675f / waitTime * time;
        }
        else if (currentHealth <= 20)
        {
            greenHealthBar.fillAmount -= 1.002375f / waitTime * time;
            yield return new WaitForSeconds(3);
            whiteHealthBar.fillAmount -= 1.002375f / waitTime * time;
        }
    }
}
