using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public enum AnimationType
    {
        Walking, Attacking, Idle
    }

    public enum ParentType
    {
        Player, Enemy, Object, NPC
    }

    public Foot_Step_Manager playerFootsteps;
    public AI ai;

    [Header("Animation Settings")]
    public bool activateAnimation;
    public bool nextAnimation;
    public SpriteRenderer render;
    public AnimationObject animationDataObject;
    public ParentType parent;

    [Header("Debug")]
    public bool check;
    public string currentAnimation;
    public AnimationType animationType;
    public bool animatiting;
    public AnimationObject liveObject;
    public Sprite[] forwatrdAnimation;
    // Start is called before the first frame update
    void Start()
    {
        if (animationDataObject != null)
        {
            liveObject = animationDataObject;
            activateAnimation = true;
            forwatrdAnimation = animationDataObject.animationSprites;
        }
        else
        {
            activateAnimation = false;
            Debug.LogError("Animation data object is missing");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateAnimation)
        {
            if (animationDataObject.instanceId != liveObject.instanceId)
            {
                changeAnimation();
            }

            if (activateAnimation)
            {
                StartCoroutine(startAnimation());
            }
        }

        if (animatiting)
        {
            if (check)
            {
                StartCoroutine(determineNextAnimation());
                check = false;
                
            }
           
        }
        

        

    }

    public IEnumerator  determineNextAnimation()
    {

        check = false;
        if (animationType == AnimationType.Walking)
        {
            if (parent == ParentType.Player && playerFootsteps.gameObject.GetComponentInChildren<Player>().moving == true)
            {
                yield return new WaitForSeconds(playerFootsteps.footstepSoundDelay / 4);
                nextAnimation = true;
               
              
            }
            else if (parent == ParentType.Enemy || parent == ParentType.NPC)
            {
                yield return new WaitForSeconds(ai.velocity);
                nextAnimation = true;
               

            }

        }
        else
        {
            nextAnimation = true;
           
        }

        
        

        yield return new WaitForSeconds(0);

        check = true;

    }
   

    public IEnumerator startAnimation()
    {
        activateAnimation = false;
        animatiting = true;
    
        foreach (Sprite sprite in forwatrdAnimation)
        {
            nextAnimation = false;
            check = true;
            render.sprite = sprite;
            
            currentAnimation = render.sprite.name;
            Debug.Log("nextAnimation Animiation wiaitng");
            yield return new WaitUntil(() => nextAnimation == true);
            Debug.Log("nextAnimation Animiation transition");
        }
        check = false;
        animatiting = false;
        activateAnimation = true;

    }

    public void changeAnimation()
    {
        
        StopAllCoroutines();
        if (animationDataObject.name != liveObject.name)
        {
            animationDataObject = liveObject;
        }

        activateAnimation = true;
        animatiting = false;
        
    }
    public void changeAnimation(AnimationObject newAnnimation)
    {
        if (animationDataObject != newAnnimation)
        {
            StopAllCoroutines();
        }
        animationDataObject = newAnnimation;
        liveObject = newAnnimation;
        forwatrdAnimation = newAnnimation.animationSprites;

        StartCoroutine(startAnimation());
        render.sprite = newAnnimation.animationSprites[0];


        activateAnimation = true;
        animatiting = false;
        Debug.LogWarning("Animation changed");
    }


}
