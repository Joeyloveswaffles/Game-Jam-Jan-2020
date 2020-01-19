using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public Renderer spriteRender;
    public GameObject originParent;
    public float damage;
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
            vectorDir = new Vector2(0, 0.25f);
        }
        player = GameObject.Find("Player").GetComponentInChildren<Player>();
        vectorDir = new Vector2(player.currentDirection.x, player.currentDirection.y);
        vectorDir = vectorDir.normalized;
        vectorDir = vectorDir / 8;
    }

    // Update is called once per frame
    void Update()
    {
        travel();
       
    }

    private void travel()
    {
        gameObject.transform.position = transform.position +  new Vector3(vectorDir.x * velocity, vectorDir.y * velocity, 0);

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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("recieveDamage", this.damage);
        }
        collisionInfoName = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionInfoName = "";
    }

    private void OnDestroy()
    {
        Debug.LogWarning(gameObject.name + "has been destroyed");
    }
}
