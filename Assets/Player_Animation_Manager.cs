using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Manager : MonoBehaviour
{
    public Animation_Manager animationManager;

    public AnimationObject faceAwayFromPlayer;
    public AnimationObject faceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findLookDirection();
        
    }

    private void findLookDirection()
    {
        Player_Input input = gameObject.transform.parent.GetComponentInChildren<Player_Input>();
        if (input.quad1)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 180, 0);
            if (animationManager.animationDataObject != faceAwayFromPlayer)
            {
                animationManager.changeAnimation(faceAwayFromPlayer);
            }
        }
        else if (input.quad2)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
            if (animationManager.animationDataObject != faceAwayFromPlayer)
            {
                animationManager.changeAnimation(faceAwayFromPlayer);
            }

        }
        else if (input.quad3)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 180, 0);
            if (animationManager.animationDataObject != faceToPlayer)
            {
                animationManager.changeAnimation(faceToPlayer);
            }
        }
        else if (input.quad4)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
            if (animationManager.animationDataObject != faceToPlayer)
            {
                animationManager.changeAnimation(faceToPlayer);
            }

        }
        else
        {

        }
    }
}
