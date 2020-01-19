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
                Debug.Log(playerFootsteps.footstepSoundDelay);
              
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

    private void findLookDirection()
    {
        Player_Input input = gameObject.transform.parent.GetComponentInChildren<Player_Input>();
        if (input.quad1)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (input.quad2)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (input.quad3)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (input.quad4)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            
        }
    }

    public IEnumerator startAnimation()
    {
        activateAnimation = false;
        animatiting = true;
        Debug.Log("Animation Started");
        foreach (Sprite sprite in forwatrdAnimation)
        {
            nextAnimation = false;
            check = true;
            render.sprite = sprite;
            
            currentAnimation = render.sprite.name;
            yield return new WaitUntil(() => nextAnimation == true);
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
        Debug.LogWarning("Animation changed");
    }

    
}
