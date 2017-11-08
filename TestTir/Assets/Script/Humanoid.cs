using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Humanoid : MonoBehaviour {

    public GameObject Projectile;
    public int damages;
    NavMeshAgent agent;
    HealthManager healthManager;
    public GameObject target;

    // Use this for initialization
    public void Init ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        healthManager = gameObject.GetComponent<HealthManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    // Tir
    public void Fire()
    {
        Vector3 positionOutsideObject = transform.position;
        positionOutsideObject += 2 * (transform.forward);
        positionOutsideObject += 0.5f * (transform.up);

        GameObject _projectil = (GameObject)Instantiate(Projectile, positionOutsideObject, transform.rotation);
        _projectil.GetComponent<Projectile>().damages = damages;
    }


     // PARTIE MOUVEMENT

    // Move to the goal point
    public void MoveToThisPoint(Vector3 _goal)
    {
        agent.destination = _goal;
    }

    public void SetMovement(bool _isMoving)
    {
        agent.isStopped = _isMoving;
    }
    public bool GetMovement()
    {
        return agent.isStopped;
    }

    // Return true if the destination is reach
    public bool HasArrived()
    {
        if (agent.remainingDistance <= 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Regarde vers l'ennemi
    public void LookToTarget()
    {
        if (target)
        {
            transform.LookAt(target.transform);
        }
    }

    public bool IsAlive()
    {
        return healthManager.isAlive;
    }
}
