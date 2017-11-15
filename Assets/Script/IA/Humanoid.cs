using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Humanoid : MonoBehaviour {

    public GameObject Projectile;
    public int damages;
    public NavMeshAgent agent;
    HealthManager healthManager;
    TutoManager Tuto;
    public GameObject target;
    public enum Etape { Moving, Arrived, Covered, Uncovered }
    public Collider col;

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
        positionOutsideObject += 2 * (transform.forward);
        positionOutsideObject += 0.5f * (transform.up);

        GameObject _projectil = (GameObject)Instantiate(Projectile, positionOutsideObject, transform.rotation);
        _projectil.GetComponent<Projectile>().damages = damages;
    }


     // PARTIE MOUVEMENT

    // Move to the goal point
    public void MoveToThisPoint(Vector3 _goal)
    {
        //agent.destination = _goal;
        agent.SetDestination(_goal); 

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
            Debug.Log(target + " " + gameObject.name);
            transform.LookAt(target.transform);
        }
    }

    public bool IsAlive()
    {
        return healthManager.isAlive;
    }
}