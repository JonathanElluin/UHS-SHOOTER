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
        if (Destination)
        {
            agent.enabled = true;
            MoveToThisPoint(Destination);
            
        }else Debug.Log("Pas de CheckPoint " + gameObject.name);


    }
	
	// Update is called once per frame
	public override void Update ()
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
