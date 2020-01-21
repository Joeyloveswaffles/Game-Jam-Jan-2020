using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Animation_Manager : MonoBehaviour
{
    public Gun gun;
    public SpriteRenderer render;
    public SpriteRenderer effectsRender;
    public Sprite muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

   public void shootAnimation()
    {
        StartCoroutine(shootFlash());
    }

    public IEnumerator shootFlash()
    {
        yield return new WaitForSeconds(1f);
        
        Debug.LogWarning("Animation flashed");

    }

    public void changeObject(GameObject gun)
    {
        this.gun = gun.GetComponentInChildren<Gun>();
        gun = this.gun.gameObject;
        render = gun.GetComponent<SpriteRenderer>();
        effectsRender = gun.GetComponentInChildren<SpriteRenderer>();
        muzzleFlash = this.gun.muzzleFlash;
    }
}
