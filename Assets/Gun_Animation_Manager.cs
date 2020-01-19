using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Animation_Manager : MonoBehaviour
{
    public Gun gun;
    public Sprite muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public IEnumerator shootFlash()
    {
        yield return new WaitForSeconds(1f);

    }
}
