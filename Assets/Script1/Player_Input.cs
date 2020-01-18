using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    

    //public Inventory playerInventory;

    public Rigidbody2D body;
    public float velocityHor;
    public float velocityVer;

    [Header("Debug: DO NOT SET")]
   
    public Vector2 dir;

    public bool isTriggered;
    public bool canMove;



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

        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        float dirHorizontal = Input.GetAxis("Horizontal");
        float dirVertical = Input.GetAxis("Vertical");
        this.dir = new Vector2(dirHorizontal * velocityHor, dirVertical * velocityVer);


        Debug.Log("Moved");
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




    private void keyListeners()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
    }
}
