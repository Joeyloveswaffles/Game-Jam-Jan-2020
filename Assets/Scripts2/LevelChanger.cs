using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : Singleton<LevelChanger>
{
    private Player_Singleton instance;
    public Animator animator;
    public bool activate;
    private int levelToLoad;
    public string ass;
    public string ass1;

    void Start()
    {
        
        
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
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
