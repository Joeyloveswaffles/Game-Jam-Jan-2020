using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_Step_Manager : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioSource source;
    public AudioClip leftFootClipSound;
    public AudioClip RightFootClipSound;
    [Tooltip("Amount of time between foot steps")]
    public float footstepSoundDelay;

    [Header("Debug")]
    public bool leftFootActivated;
    public bool rightFootAactivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftFootActivated)
        {
            StartCoroutine(delay(footstepSoundDelay,leftFootClipSound));
            leftFootActivated = false;
            rightFootAactivated = true;
        }
        else if (rightFootAactivated)
        {
            StartCoroutine(delay(footstepSoundDelay,RightFootClipSound));
            rightFootAactivated = false;
            leftFootActivated = true;

        }

        
    }

    public IEnumerator delay(float seconds, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        yield return new  WaitForSeconds(seconds);
    }
}
