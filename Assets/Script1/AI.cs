﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject testPath;
    public GameObject[] pathfindingStructures;
    public float velocity;
    public enum State
    {
        Idle, Patrolling, Persueing, Attacking

    }

    public GameObject target;

    [Header("Debug")]
    public GameObject pathFindingTarget;
    public string currentTargetName;
    public float magnitude;
    public Transform[] points;
    public Vector3 dir;
    public bool persueTarget;
    public bool attackingTarget;
    public bool patrol;
    public bool startNewPath;
    public string objectInRange;
    public State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        startNewPath = true;

    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        
    }
    public void updateState()
    {
        if (persueTarget)
        {
            moveTowardsTarget();
            state = State.Persueing;
        }
        else if (attackingTarget)
        {
            state = State.Attacking;
        }
        else if (patrol)
        {
            if (startNewPath)
            {
                startPatrol();
                startNewPath = false;
            }
            else
            {
                moveTowardsPathFindingTarget();
            }
        

            state = State.Patrolling;
            
        }
        else
        {
            state = State.Idle;
        }

    }

    public void moveTowardsTarget()
    {
        Vector3 dir = target.transform.position - gameObject.transform.position;
        dir = dir.normalized;
        dir = new Vector3(dir.x * velocity, dir.y * velocity, 0);
        this.dir = dir;
        gameObject.transform.position += dir;

    }
    public void moveTowardsPathFindingTarget()
    {
        this.points = points;
        Vector3 dir   = pathFindingTarget.transform.position - gameObject.transform.position;
        dir = dir.normalized;
        dir = new Vector3(dir.x * velocity, dir.y * velocity, 0);
        this.dir = dir;
        gameObject.transform.position += dir;
        Vector2 x1 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Vector2 x2 = new Vector2(pathFindingTarget.transform.position.x, pathFindingTarget.transform.position.y);
        magnitude = Vector2.Distance(x1, x2);


    }
    

    public void startPatrol()
    {
        Transform[] points = new Transform[testPath.transform.childCount];
        for (int i = 0; i < testPath.transform.childCount; i++)
        {
            points[i] = testPath.transform.GetChild(i);
        }
        this.points = points;
        StartCoroutine(startPath(points));



    }

    public IEnumerator startPath(Transform[] points)
    {
        
        int index = 0;
        Vector2 x1;
        Vector2 x2;
        for (int i = 0; i < points.Length; i++)
        {
            
            Transform point = points[i];
            pathFindingTarget = point.gameObject;
            currentTargetName = points[i].name;

            x1 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
             x2 = new Vector2(pathFindingTarget.transform.position.x, pathFindingTarget.transform.position.y);
            magnitude = Vector2.Distance(x1, x2);
            yield return new WaitUntil(() => magnitude <= 1f);

        }

        Transform point1 = points[0];
        pathFindingTarget = point1.gameObject;
        currentTargetName = points[0].name;

         x1 = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
         x2 = new Vector2(pathFindingTarget.transform.position.x, pathFindingTarget.transform.position.y);
        magnitude = Vector2.Distance(x1, x2);
        yield return new WaitUntil(() => magnitude <= 1f);
        startNewPath = true;





    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == target.name)
        {
            persueTarget = true;
        }
        else
        {
            Debug.Log(gameObject.name + " sees " + target.name);
        }

        objectInRange = collision.name;
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        objectInRange = "";
    }
}