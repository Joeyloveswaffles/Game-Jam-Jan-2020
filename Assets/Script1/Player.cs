using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_Input inputs;
    private Player_Singleton savedInstance;
    public HealthBar healthBar;
    public Gun gun;
    

    

    // public Player_Progression playerProgression; // if we decide to do




    [Header("Debug")]
    public float currentHealth;
    public Vector2 currentDirection;
    public Vector2 debugDir;
    public bool alive;
    public bool moving;
    public int currency;
    public string instanceDebug;
    // Start is called before the first frame update
    void Start()
    {
       
        currency = 0;
        savedInstance = Player_Singleton.getInstance(new Player_Singleton());
        loadData();
        DontDestroyOnLoad(gameObject);
       

    }

    // Update is called once per frame
    void Update()
    {
        saveData();
        if (inputs.canMove)
        {
            /*
            if (activateAnimations)
            {
                findSpriteDirection(); //when we have the art sprites to do so
            }
            */
        }

        if (inputs.dir.x != 0 || inputs.dir.y != 0)
        {
            currentDirection = inputs.dir;
            moving = true;
        }
        else
        {
            moving = false;
        }

    }
    
    public void saveData()
    {
        savedInstance.healthBar = healthBar;
        savedInstance.currentHealth = healthBar.currentHealth;
        currentHealth = savedInstance.currentHealth;
    }

    public void loadData()
    {
        if (savedInstance.healthBar != null)
        {
            healthBar = savedInstance.healthBar;
            if (savedInstance.currentHealth != 0)
            {
                healthBar.currentHealth = savedInstance.currentHealth;
                currentHealth = savedInstance.currentHealth;

            }
        }

        if (savedInstance.gun != null)
        {
            gun = savedInstance.gun;
        }
        if (savedInstance.currentHealth > 0)
        {
            currentHealth = savedInstance.currentHealth;
          }

    }

    // Uses if we have currency system;
    public void gainCurrency()
    {
        currency += 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            healthBar.recieveDamage(collision.gameObject.GetComponentInChildren<Enemy>().damage);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void OnDestroy()
    {
        Debug.LogWarning("Player Died");
    }
}
