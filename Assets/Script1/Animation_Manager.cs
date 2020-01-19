using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    [Header("Animation Settings")]
    public bool activateAnimation;
    public bool nextAnimation;
    public SpriteRenderer render;
    public AnimationObject animationDataObject;

    [Header("Debug")]
    public bool animatimating;
    public AnimationObject liveObject;
    public Sprite[] forwatrdAnimation;
    // Start is called before the first frame update
    void Start()
    {
        if (animationDataObject != null)
        {
            liveObject = animationDataObject;
            activateAnimation = true;
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
        

        

    }

    public IEnumerator startAnimation()
    {
        activateAnimation = false;
        animatimating = true;

        foreach (Sprite sprite in forwatrdAnimation)
        {
            render.sprite = sprite;
            yield return new WaitUntil(() => nextAnimation == true);
        }

        animatimating = false;
        activateAnimation = true;

    }

    public void changeAnimation()
    {
        if (animationDataObject.name != liveObject.name)
        {
            animationDataObject = liveObject;
        }
    }

    
}
