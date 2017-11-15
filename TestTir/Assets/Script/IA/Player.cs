using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid {
    
    public List<Transform> destination;
    private const int coverPos = 5;
    private KeyCode btnTir = KeyCode.T;
    private int checkPointNum = 0;
    private SpawnPoints[] respawns;

    private Etape playerState;

	// Use this for initialization
	void Start ()
    {
        Init();
        MoveToThisPoint(destination[0].position);
        playerState = Etape.Moving;
        respawns = FindObjectsOfType(typeof(SpawnPoints)) as SpawnPoints[];
    }
    
    // Update is called once per frame
    void Update () {

        if (!IsAlive())
        {
            return;
        }
        

        switch (playerState)
        {
            // Si le joueur arrive à destination, on passe dans l'étape "Arrived"
            case Etape.Moving:

                //Debug.Log("Etape = Moving");

                // Lorsque le joueur arrive, on enlève sa position dans la list et on passe dans l'étape arrivée
                if (HasArrived())
                {
                    checkPointNum++;
                    destination.RemoveAt(0);
                    playerState = Etape.Arrived;
                }

                break;

            // Si le joueur est arrivé, on fait spawn les ennemis et on passe dans l'étape "Covered"
            case Etape.Arrived:

                //Debug.Log("Etape = Arrived");
                
                col.enabled = false;
                playerState = Etape.Covered;
                break;

            // Si le joueur est à couvert, un appuie sur le bouton haut nous fait passer dans l'étape "Uncovered"
            case Etape.Covered:

                //Debug.Log("Etape = Covered");

                LookToTarget();

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    col.enabled = true;
                    playerState = Etape.Uncovered;
                }

                break;

            // Si le joueur est à découvert, un appuie sur le bouton bas nous fait passer dans l'étape "Covered". Il peut également tirer
            case Etape.Uncovered:

                //Debug.Log("Etape = Uncovered");

                LookToTarget();

                // Si on appuie sur T
                if (Input.GetKeyDown(btnTir))
                {
                    Fire();
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    col.enabled = false;
                    playerState = Etape.Covered;
                }

                //Si tous les enemis ont été tués, on passe au checkpoint suivant
                //if (enemiesAlive == 0)
                {
                    MoveToThisPoint(destination[0].position);
                }

                break;
        }









        /*
        if (HasArrived())
        {
            LookToTarget();

            // Sortir pour pouvoir tirer
            if (Input.GetKeyDown(KeyCode.UpArrow) && isCovered)
            {
                gameObject.transform.position += coverPos * Vector3.up;
                isCovered = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && !isCovered)
            {
                gameObject.transform.position -= coverPos * Vector3.up;
                isCovered = true;
            }

            // Si on appuie sur T
            if (Input.GetKeyDown(btnTir))
            {
                Fire();
            }
        }*/
	}
}
