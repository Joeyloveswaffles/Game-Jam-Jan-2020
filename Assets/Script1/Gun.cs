﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun settings")]
    public float fireRate;
    public int maxAmmo;
    public int clipSize;
    public int currentAmmo;
    public bool shootIsCalled;
    public bool reloadIsCalled;
    public Sprite muzzleFlash;
   
   

    [Header("Binding controls")]
    public KeyCode shootControl;
    public KeyCode reloadControl;
    
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    [Header("Sound settings")]
    public AudioSource source;
    public AudioClip firesound;
    public AudioClip reloadSound;


    [Header("Debug")]
   
    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        canShoot = true;
        shootIsCalled = false;
        reloadIsCalled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        controlListener();
    }

    public void controlListener()
    {
        if (Input.GetKeyDown(shootControl) && checkFireRate())
        {
            if (currentAmmo <= 0)
            {
                reload();
            }
            else
            {
                shoot();
            }
        }
        else if (Input.GetKeyDown(reloadControl))
        {
            reload();
        }
        

    }

    public bool checkFireRate()
    {
        return canShoot;
    }

    public void shoot()
    {
        if (currentAmmo > 0 && currentAmmo <= clipSize)
        {
          
            canShoot = false;
            source.clip = firesound;
            source.Play();
            GameObject bulletObj = bulletPrefab;
            GameObject newBullet = Instantiate(bulletObj, bulletSpawn.position, Quaternion.identity) as GameObject;
            newBullet.transform.position = bulletSpawn.position;
            currentAmmo -= 1;

            StartCoroutine(fireRateDelay());

            shootIsCalled = true;
            //newBullet.transform.SetParent(null);
        }
        else
        {
            shootIsCalled = false;
        }
    }

    public bool shootMethodIsCalled()
    {
        if(shootIsCalled == true)
        {
            return true;
        }
        return false;
    }

    public IEnumerator fireRateDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void reload()
    {
        source.clip = reloadSound;
        source.Play();
        if (maxAmmo < clipSize)
        {
            currentAmmo = maxAmmo;
            reloadIsCalled = true;
        }
        else
        {
            maxAmmo -= currentAmmo;
            currentAmmo = clipSize;
            reloadIsCalled = false;
        }
            
       



    }
    public bool reloadMethodIsCalled()
    {
        if (reloadIsCalled == true)
        {
            return true;
        }
        return false;
    }

    
}
