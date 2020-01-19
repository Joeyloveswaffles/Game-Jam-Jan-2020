using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rift_Animate : MonoBehaviour
{
    
	public Sprite frame1, frame2, frame3, frame4
	public double framerate
	
	// Start is called before the first frame update
    void Start()
    {
        GetComponent(SpriteRenderer).sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
}
