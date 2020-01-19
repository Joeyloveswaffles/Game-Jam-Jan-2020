using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public bool isTriggered;
    public HealthBar healthbar;

    public float damage;

    [Header("Debyug")]
    public string colliderCilissionName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != gameObject.name)
        {
            isTriggered = true;
        }
        else if (collision.gameObject.name == "Bullet")
        {
            healthbar.recieveDamage(collision.gameObject.GetComponentInChildren<Bullet>().damage);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
    }


}
