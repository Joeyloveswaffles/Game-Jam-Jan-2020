using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : Singleton<LevelChanger>
{
    private Player_Singleton instance;
    public Animator animator;
    public bool activate;
    private int levelToLoad;

    void Start()
    {
        animator.SetTrigger("FadeIn");
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Statement Failed");
            if (activate)
            {
                LevelChanger.Instance.assSaveData = LevelChanger.Instance.GetInstanceID().ToString();
                FadeToLevel(1);
            }
        }*/
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        StartCoroutine(waitforFade());
        animator.SetTrigger("FadeOut");
        Debug.Log("Fade");
        
    }
   

    public IEnumerator waitforFade()
    { 
    yield return new WaitForSeconds(0.85f);
    yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Fade_In") == true);
       
        OnFadeComplete();
    }
    public void OnFadeComplete()
    {
       SceneManager.LoadScene(levelToLoad);
        Debug.Log("level Loaded");
       
    }

    
}
