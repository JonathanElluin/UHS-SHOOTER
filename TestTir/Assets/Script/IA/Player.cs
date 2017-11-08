using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid {
    
    public Transform destination1;
    private bool isCovered;
    private const int coverPos = 5;
    private KeyCode btnTir = KeyCode.T;

	// Use this for initialization
	void Start ()
    {
        Init();
        isCovered = true;
    }
    
    // Update is called once per frame
    void Update () {

        if (!IsAlive())
        {
            return;
        }

        MoveToThisPoint(destination1.position);

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

            // Si on appuie sur B & que l'on peut tirer
            if (Input.GetKeyDown(btnTir))
            {
                Fire();
            }
        }
	}
}
