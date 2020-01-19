using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation ddata object", menuName = "Animation Object")]
public class AnimationObject : ScriptableObject
{
    public Sprite[] animationSprites;
    public string animationName;
    public string instanceId;
    // Start is called before the first frame update
    void Start()
    {
        if (instanceId == null)
        {
            instanceId = this.GetInstanceID().ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
