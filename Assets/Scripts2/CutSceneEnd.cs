using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneEnd : MonoBehaviour
{
    public int firstLevelBuildIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(jumpToScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator jumpToScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(firstLevelBuildIndex);
    }
}
