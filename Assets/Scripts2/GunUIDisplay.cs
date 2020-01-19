using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIDisplay : MonoBehaviour
{
    public GameObject gunInstance;
    public int currentAmmo;
    public int clipSize;

    // Start is called before the first frame update
    void Start()
    {
        Gun Gun = gunInstance.GetComponent<Gun>();
        currentAmmo = Gun.currentAmmo;
        clipSize = Gun.clipSize; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
