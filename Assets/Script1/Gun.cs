using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int maxAmmo;
    public int clipSize;
    public int currentAmmo;

    public KeyCode shootControl;
    
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public AudioSource source;
    public AudioClip firesound;
    public AudioClip reloadSound;


    [Header("Debug")]
   
    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        controlListener();
    }

    public void controlListener()
    {
        if (Input.GetKeyDown(shootControl))
        {
            shoot();
        }

    }

    public void shoot()
    {
        if (currentAmmo > 0 && currentAmmo <= clipSize)
        {
            source.clip = firesound;
            source.Play();
            GameObject bulletObj = bulletPrefab;
            GameObject newBullet = Instantiate(bulletObj, bulletSpawn.position, Quaternion.identity) as GameObject;
            newBullet.transform.position = bulletSpawn.position;
            currentAmmo -= 1;

            if (currentAmmo <= 0)
            {

            }
            //newBullet.transform.SetParent(null);
        }
    }

    public void reload()
    {
        source.clip = reloadSound;
        source.Play();
        if (maxAmmo < clipSize)
        {
            currentAmmo = maxAmmo;
        }
        else
        {
            maxAmmo -= currentAmmo;
            currentAmmo = clipSize;

        }
            
       



    }
}
