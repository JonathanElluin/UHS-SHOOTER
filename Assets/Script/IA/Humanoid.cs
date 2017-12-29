using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Humanoid : MonoBehaviour {


    public List<CheckPoint> destination;

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
    Transform Destination;

    //State
    public enum Etape { Moving, Arrived, GoCovered, Covered, GoUncovered , Uncovered }
    public Etape HumanState;

    // Use this for initialization
    public void Init ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        healthManager = gameObject.GetComponent<HealthManager>();
        col = gameObject.GetComponent<Collider>();
    }

    /// <summary>
    /// Change l'état dans lequel se trouve le personnage 
    /// </summary>
    /// <param name="_state"></param>
    public virtual void SwitchState(Etape _state)
    {
        HumanState = _state;
        switch (HumanState)
        {
            case Etape.Moving:
                break;

            case Etape.GoCovered:
                break;

            case Etape.Covered:
                col.enabled = false;
                break;

            case Etape.GoUncovered:
                break;

            case Etape.Uncovered:
                col.enabled = true;
                break;
        }
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

     //Set destination of IA
     public void SetDestination(Transform _destination)
    {
        Destination = _destination;
    }

    public Transform GetDestination()
    {
        return Destination;
    }

    // Move to the goal point
    public void MoveToThisPoint()
    {
        if (Destination)
        {
            agent.isStopped = false;
            agent.SetDestination(Destination.position);
            SwitchState(Etape.Moving);
        }
 
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

    //State
    void GoCovered()
    {

    }

    void GoUncovered()
    {

    }

    // Regarde vers l'ennemi
    public void LookToTarget()
    {
         transform.LookAt(target.transform);
    }

    public bool IsAlive()
    {
        return healthManager.isAlive;
    }
}