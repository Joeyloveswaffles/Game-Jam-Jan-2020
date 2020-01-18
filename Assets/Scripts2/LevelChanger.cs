using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : Singleton<LevelChanger>
{
    public Animator animator;
    public bool activate;
    private int levelToLoad;

    void Start()
    {
        activate = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Statement Failed");
            if (activate)
            {
                FadeToLevel(1);
            }
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
