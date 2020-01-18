using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Renderer spriteRender;
    public GameObject originParent;
    [Header("Debug")]
    public Vector2 vectorDir;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (spriteRender.isVisible == false)
        {
            
            //Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
