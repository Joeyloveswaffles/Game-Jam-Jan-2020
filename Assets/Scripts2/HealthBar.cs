using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image greenHealthBar;
    public Image whiteHealthBar;
    public float maxHealth = 100;
    public float currentHealth;
    public bool coolingDown;
    public float waitTime = 1120.0f;
    public float currentFillPercent;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            greenHealthBar.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
        */
 
        currentHealth = greenHealthBar.fillAmount * 100;
        currentFillPercent = greenHealthBar.fillAmount;
        /*
        if(whiteHealthBar.fillAmount <= greenHealthBar.fillAmount)
        {
            whiteHealthBar.fillAmount += .01f;
        }*/
        StartCoroutine(depleteHealth());
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
