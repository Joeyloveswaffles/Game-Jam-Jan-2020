using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    
    public enum ParentType
    {
        Player,Enemy,Object,None
    }
    public ParentType parentType;
    public Image greenHealthBar;
    public Image whiteHealthBar;
    public float maxHealth;
    public float currentHealth;
    public bool coolingDown;
    public float waitTime;
    public float currentFillPercent;
    public bool inVoid;

    private void Start()
    {
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
           
        }

        maxHealth = 100;
        waitTime = 420.0f;





    }
    // Update is called once per frame
    void Update()
    {

        currentFillPercent = currentHealth / maxHealth;
        greenHealthBar.fillAmount = currentFillPercent;
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            inVoid = true;
        }
        else
        {
            inVoid = false;

        }
        if (inVoid == true && parentType == ParentType.Player)
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

    public void recieveDamage(float damage)
    {
        currentHealth -= damage;
       if ( currentHealth<= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
            Debug.LogWarning("die");
            
        }

    }



    private void OnDestroy()
    {
        Debug.LogWarning(gameObject.transform.parent.name + "was Destroyed");
    }
}
