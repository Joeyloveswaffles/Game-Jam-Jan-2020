using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueInteraction : MonoBehaviour
{
    public Conversation conversation;
    public int currentBuildIndex;
    public bool openingDialogue;
    public bool sceneCanStart;

   



    // Start is called before the first frame update
    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        sceneCanStart = false;
        StartCoroutine(waitForSceneStart());

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator waitForSceneStart()
    {
        yield return new WaitForSeconds(5f);
        sceneCanStart = true;
    }

    public bool sceneReady()
    {
        if(sceneCanStart == true)
        {
            return true;
        }
        return false;
    }


}
