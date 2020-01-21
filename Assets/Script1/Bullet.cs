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
        
       
        
        
        vectorDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        vectorDir = vectorDir.normalized;
        Debug.LogWarning(vectorDir);
        
        
        float angle = (Vector2.Angle(transform.position, vectorDir));
        if (vectorDir.x <= 0)
        {
             angle = (Vector2.Angle(transform.position, vectorDir));
            angle += 90;
        }
        else
        {
            angle = (Vector2.Angle(vectorDir, transform.position));
            angle = 0;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

        vectorDir /= 8;
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

        Debug.LogError(collision.gameObject.name
            );

        if (collision.gameObject.tag == "Enemy" &&  collision.gameObject != originParent)
        {
            collision.gameObject.GetComponentInChildren<HealthBar>().recieveDamage(this.damage);
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "Player" && collision.gameObject != originParent )
        {
            collision.gameObject.GetComponentInChildren<HealthBar>().recieveDamage(this.damage);
            Destroy(gameObject);

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
