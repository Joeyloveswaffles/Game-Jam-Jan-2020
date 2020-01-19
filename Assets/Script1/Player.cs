using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player_Input inputs;
    private Player_Singleton savedInstance;
    public HealthBar healthBar;

    

    // public Player_Progression playerProgression; // if we decide to do




    [Header("Debug")]
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
        if (savedInstance.ass6 == null)
        {
            savedInstance.ass6 = instanceDebug;
            Debug.LogError("asss");
        }
        else
        {
            instanceDebug = savedInstance.ass6;
        }
       

    }

    // Update is called once per frame
    void Update()
    {
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
    /*
    public void findSpriteDirection()
    {
        debugDir = inputs.dir;
        if (inputs.dir.x > 0 && inputs.dir.y > 0) // right and up
        {
            render.sprite = directionAnimations[0];
        }
        else if (inputs.dir.x < 0 && inputs.dir.y > 0) // left and up
        {
            render.sprite = directionAnimations[1];

        }
        else if (inputs.dir.x > 0 && inputs.dir.y < 0) // right and down
        {
            render.sprite = directionAnimations[2];

        }
        else if (inputs.dir.x < 0 && inputs.dir.y < 0) // left and down
        {
            render.sprite = directionAnimations[3];

        }
        else if (inputs.dir.x < 0 && inputs.dir.y == 0) // left
        {
            render.sprite = directionAnimations[4];

        }
        else if (inputs.dir.x > 0 && inputs.dir.y == 0) // right
        {
            render.sprite = directionAnimations[5];

        }
        else if (inputs.dir.x == 0 && inputs.dir.y < 0) //down
        {
            render.sprite = directionAnimations[6];

        }
        else if (inputs.dir.x == 0 && inputs.dir.y > 0)  //up
        {
            render.sprite = directionAnimations[7];

        }
        else
        {

        }

    }
    */

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
