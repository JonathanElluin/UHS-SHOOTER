using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Humanoid : MonoBehaviour {

    //Projectile
    public GameObject Projectile;
    public int damages;

    //Agent
    public NavMeshAgent agent;
    HealthManager healthManager;
    public Collider col;
    TutoManager Tuto;

    //Goal
    public GameObject target;
    public Transform Destination;

    //State
    public enum Etape { Moving, Arrived, Covered, Uncovered }
    

    // Use this for initialization
    public void Init ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        healthManager = gameObject.GetComponent<HealthManager>();
        col = gameObject.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    // Tir
    public void Fire()
    {
        Vector3 positionOutsideObject = transform.position;
        positionOutsideObject += 2.5f * (transform.forward);
        positionOutsideObject += 0.5f * (transform.up);

        GameObject _projectil = Instantiate(Projectile, positionOutsideObject, transform.rotation);
        _projectil.GetComponent<Projectile>().damages = damages;
    }


     // PARTIE MOUVEMENT

    // Move to the goal point
    public void MoveToThisPoint(Transform _goal)
    {
        agent.isStopped = false;
        agent.SetDestination(_goal.position); 

    }

    // Return true if the destination is reach
    public bool HasArrived()
    {
        if (agent.remainingDistance <= 0.5f)
        {
            agent.isStopped = true;

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
         Debug.Log(target + " " + gameObject.name);
         transform.LookAt(target.transform);
    }

    public bool IsAlive()
    {
        return healthManager.isAlive;
    }
}