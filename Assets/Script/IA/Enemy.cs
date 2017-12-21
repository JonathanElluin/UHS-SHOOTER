using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid {

    public SpawnPoints spawnPointsScript;
    private KeyCode btnTir = KeyCode.B;

	// Use this for initialization
	void Start ()
    {
        Init();

        agent.enabled = true;
        MoveToThisPoint();

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
        if (spawnPointsScript) spawnPointsScript.EnemyDied();
    }
}
