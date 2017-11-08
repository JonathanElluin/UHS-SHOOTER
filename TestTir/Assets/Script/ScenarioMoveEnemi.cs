using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMoveEnemi : Humanoid {

    public GameObject checkPoint;
    private KeyCode btnTir = KeyCode.B;

	// Use this for initialization
	void Start ()
    {
        base.Init();
	}
	
	// Update is called once per frame
	void Update () {

        if (!IsAlive())
        {
            return;
        }

        if (Input.GetKeyDown(btnTir))
        {
            Fire();
        }

        // Si appuie sur "Espace", déplacement jusqu'aux confetis
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToThisPoint(checkPoint.transform.position);
        }

        if (HasArrived())
        {
            LookToTarget();
        }

        /*// pour le déboguage, appuie sur S arrête ou met en mouvement l'objet
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveTo.SetMovement(!moveTo.GetMovement());
        }*/
	}
}
