using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_Step_Manager : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioSource source;
    public AudioClip leftFootClipSound;
    public AudioClip RightFootClipSound;
    public AudioClip leftFootInVoidClipSound;
    public AudioClip RightFootInVoidClipSound;
    [Tooltip("Amount of time between foot steps")]
    public float footstepSoundDelay;

    [Header("Debug")]
    public bool activateSound;
    public bool leftFootActivated;
    public bool rightFootActivated;
    public bool leftFootActivatedInVoid;
    public bool rightFootActivatedinVoid;
    public bool inVoid;
    // Start is called before the first frame update
    void Start()
    {
        activateSound = true;
        if (inVoid)
        {
            leftFootActivatedInVoid = true;
        }
        else
        {


            leftFootActivated = true;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateSound && gameObject.GetComponentInChildren<Player>().moving == true)
        {
            StartCoroutine(delay());
        }

        
    }

    public IEnumerator delay()
    {
        activateSound = false;


        if (leftFootActivated)
        {
            if (inVoid)
            {
                
                leftFootActivatedInVoid= false;
                rightFootActivatedinVoid = true;

                leftFootActivated = false;
                rightFootActivated = false;
                source.clip = leftFootInVoidClipSound;

            }
            else
            {
                leftFootActivated = false;
                rightFootActivated = true;

                //these are false
                leftFootActivatedInVoid = false;
                rightFootActivatedinVoid = false;

                source.clip = leftFootClipSound;
            }

            source.panStereo = -0.5f;
            

        }
        else if (rightFootActivated)
        {
            if (inVoid)
            {
                source.clip = RightFootInVoidClipSound;
                rightFootActivatedinVoid = false;
                leftFootActivatedInVoid = true;

                leftFootActivated = false;
                rightFootActivated = false;

            }
            else
            {
                leftFootActivatedInVoid = false;
                rightFootActivatedinVoid = false;

                rightFootActivated = false;
                leftFootActivated = true;
                source.clip = RightFootClipSound;
            }

            source.panStereo = 0.5f;
            

        }
        
        source.Play();
        yield return new  WaitForSeconds(footstepSoundDelay);
        activateSound = true;
    }
}
