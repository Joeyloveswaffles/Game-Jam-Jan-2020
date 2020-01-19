using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Autoplay : MonoBehaviour
{

    [SerializeField]
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioData.pitch = 0.8f;
    }
}
