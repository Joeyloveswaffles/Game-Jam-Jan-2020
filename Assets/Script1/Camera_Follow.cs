using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
=======
        DontDestroyOnLoad(gameObject);
>>>>>>> 80dd0e1182034345f5760da51fe2db869d72acce
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float z = gameObject.transform.position.z;
        transform.position = new Vector3(player.position.x, player.position.y,  z);
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = gameObject.transform.position.z;
        transform.position = new Vector3(player.position.x, player.position.y, z);


    }
}
