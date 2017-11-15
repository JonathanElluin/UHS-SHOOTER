using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid {

    public GameObject checkPoint;
    public SpawnPoints spawnPointsScript;
    private KeyCode btnTir = KeyCode.B;

	// Use this for initialization
	void Start ()
    {
        Init();
        if (checkPoint == null)
        {
            Debug.Log("Pas de CheckPoint " + gameObject.name);
        }
        
        agent.enabled = true;
        MoveToThisPoint(checkPoint.transform.position);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsAlive())
        {
            return;
        }

        if (Input.GetKeyDown(btnTir))
        {
            Fire();
        }

        if (HasArrived())
        {
            LookToTarget();
        }
    }

    void OnDestroy()
    {
        Debug.Log("diediedidied");
        spawnPointsScript.EnemyDied();
    }
}
