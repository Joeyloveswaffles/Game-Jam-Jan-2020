using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIDisplay : MonoBehaviour
{
    public Gun gun;
    public Sprite sprite;
    public Transform ammoCounter;
    public int maxAmmo;
    public int currentAmmo;
    public int clipSize;
    private const string Pistol = "Pistol";
    private const string FingerGun = "Finger Gun";
    private const string BackwardsGun = "Backwards gun";
    private const string PlasmaLaser = "Plasma_Laser";

    public Image pistolGuiSprite;
    public Image fingerGunGuiSprite;
    public Image backwardsGunGuiSprite;
    public Image plasmaLaserGuiSprite;

    public Image gunDisplaySprite;

    // Start is called before the first frame update
    void Start()
    {
        clipSize = gun.clipSize;
        currentAmmo = gun.currentAmmo;
        maxAmmo = gun.maxAmmo;
        sprite = gun.transform.GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        gunDisplaySprite.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite != gun.transform.GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite )
        {
            sprite = gun.transform.GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
            gunDisplaySprite.sprite = sprite;
            if (gun.transform.GetChild(0).gameObject.name == Pistol)
            {
                gunDisplaySprite = pistolGuiSprite;
            }
            else if (gun.transform.GetChild(0).gameObject.name == FingerGun)
            {
                gunDisplaySprite = fingerGunGuiSprite;
            }
            else if (gun.transform.GetChild(0).gameObject.name == BackwardsGun)
            {
                gunDisplaySprite = backwardsGunGuiSprite;
            }
            else if (gun.transform.GetChild(0).gameObject.name == PlasmaLaser)
            {
                gunDisplaySprite = plasmaLaserGuiSprite;
            }


        }
        if (gun.shootMethodIsCalled() == true)
        {
            ammoCounter.GetComponent<Text>().text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
        }
        if(gun.reloadMethodIsCalled() == true)
        {
            currentAmmo = maxAmmo;
            ammoCounter.GetComponent<Text>().text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
        }
    }
    
}
