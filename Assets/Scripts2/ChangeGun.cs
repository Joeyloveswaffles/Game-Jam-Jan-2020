using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public GameObject pistol;
    public GameObject fingerGun;
    public GameObject backwardsGun;
    public GameObject plasmaLaser;
    public GameObject currentGun;
    public Gun gun;
    public GameObject[] guns;
    public KeyCode manualBinding;
    public AudioSource source;
    public AudioClip swapSound;

    public int currentAmmo;
    public int clipSize;
    public int maxAmmo;
    public int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = gun.currentAmmo;
        clipSize = gun.clipSize;
        maxAmmo = gun.maxAmmo;
        currentGun = pistol;
        currentIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo = gun.currentAmmo;
        clipSize = gun.clipSize;
        maxAmmo = gun.maxAmmo;
    }

    public void changeCurrentGun()
    {
        if(currentGun == pistol)
        {
            currentGun = fingerGun;
        }
        else if (currentGun == fingerGun)
        {
            currentGun = backwardsGun;
        }
        else if (currentGun == backwardsGun)
        {
            currentGun = plasmaLaser;
        }
        else if (currentGun == plasmaLaser)
        {
            currentGun = pistol;
        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void mannualChangeGun()
    {
        currentGun = guns[checkIndex(currentIndex)];
        currentGun.GetComponentInChildren<Gun>();
        source.clip = swapSound;
        source.Play();
    }

    public void automaticChangeGun()
    {
        if(gun.currentAmmo < maxAmmo)
        {
            currentGun = guns[checkIndex(currentIndex)];
            currentGun.GetComponentInChildren<Gun>();
            source.clip = swapSound;
            source.Play();
        }
    }

    public int checkIndex(int index)
    {
        if((index + 1) > guns.Length)
        {
            currentIndex = 0;
            return 0;
        }
        else
        {
            index += 1;
            currentIndex = index;
            return index;
        }
    }
}
