using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public Renderer spriteRender;
    public GameObject originParent;
    [Header("Debug")]
    public Vector2 vectorDir;
    public float velocity;
    public bool listenForDeath;
    public string collisionInfoName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startDelay(2f));
        if (vectorDir.x == 0 && vectorDir.y == 0)
        {
            vectorDir = new Vector2(0, 1);
        }
        player = GameObject.Find("Player").GetComponentInChildren<Player>();
        vectorDir = new Vector2(player.currentDirection.x, player.currentDirection.y);
        vectorDir = vectorDir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        travel();
       
    }

    private void travel()
    {
        gameObject.transform.position = transform.position +  new Vector3(vectorDir.x * velocity, vectorDir.y * velocity, 0);
        Debug.LogWarning(spriteRender.isVisible);
        if (spriteRender.isVisible == false && listenForDeath == true)
        {
            
            Destroy(gameObject);
        }

    }

    private IEnumerator startDelay(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        listenForDeath = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collisionInfoName = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionInfoName = "";
    }
}
