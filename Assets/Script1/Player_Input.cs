using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{

    public Game_Controller gameController;
    public LayerMask layerMask;
    //public Inventory playerInventory;

    public Rigidbody2D body;
    public float velocityHor;
    public float velocityVer;

    

    [Header("Debug: DO NOT SET")]
   
    public Vector2 dir;

    public bool isTriggered;
    public bool canMove;
    public bool quad1;
    public bool quad2;
    public bool quad3;
    public bool quad4;
    public float mouseX;
    public float mouseY;
    public float centerX;
    public float centerY;

    public Vector2 projectileLookDir;



    [SerializeField]
    private float maxjumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        //dataValidation();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<Game_Controller>();

        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        float dirHorizontal = Input.GetAxis("Horizontal");
        float dirVertical = Input.GetAxis("Vertical");
        this.dir = new Vector2(dirHorizontal * velocityHor, dirVertical * velocityVer);



        if (canMove)
        {
            body.MovePosition(position + dir);
        }

        if (body.velocity.y < 0.0f)
        {
            //body.velocity += Vector2.up * Physics2D.gravity * (fallRate - 1) * Time.deltaTime;
        }
        else;
        {
            //body.velocity += Vector2.up * Physics2D.gravity * (lowJumRate - 1) * Time.deltaTime;
        }

        findClickQuad();

    }

    public void dataValidation()
    {
        GameObject[] inventories = GameObject.FindGameObjectsWithTag("Inventory");
        canMove = true;

        foreach (GameObject inventory in inventories)
        {
            //if (inventory.GetComponentInChildren<Inventory>().open)
            // {
            // canMove = false;
            // }

        }



    }

    public void findClickQuad()
    {
        mouseX = gameController.mouseX;
        mouseY = gameController.mouseY;
        centerX = gameController.CenterX;
        centerY = gameController.CenterY;
        


        if (mouseX <= gameController.CenterX && mouseY <= gameController.CenterY)
        {
            quad1 = false;
            quad2 = false;
            quad3 = true;
            quad4 = false;

        }
       else if (mouseX <= gameController.CenterX && mouseY > gameController.CenterY)
        {
            quad1 = true;
            quad2 = false;
            quad3 = false;
            quad4 = false;

        }
       else if (mouseX > gameController.CenterX && mouseY <= gameController.CenterY)
        {
            quad1 = false;
            quad2 = false;
            quad3 = false;
            quad4 = true;

        }
        else if (mouseX > gameController.CenterX && mouseY > gameController.CenterY)
        {
            quad1 = false;
            quad2 = true;
            quad3 = false;
            quad4 = false;

        }
        else
        {
            Debug.LogError("Quad System is failing");
        }


    }




    private void keyListeners()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerMask.value)

            if (collision.gameObject.name != gameObject.name)
            {
                isTriggered = true;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
}
