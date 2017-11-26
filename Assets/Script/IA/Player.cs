using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid {
    
    public List<Transform> destination;
    private const int coverPos = 5;
    private KeyCode btnTir = KeyCode.T;

    private Etape playerState;
    public Camera MainCam;
    public Camera TacticalCam;
    
    //Enemy
    bool EnemiesFind = false;
    GameObject[] Enemies;
    int indexEnemies = 0;

	// Use this for initialization
	void Start ()
    {
        Init();

        //Set Player Destination
        Destination = destination[0];
        if (Destination)
        {
            MoveToThisPoint(Destination);
            playerState = Etape.Moving;
        }
    }

    // Update is called once per frame
    void Update() {

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
                    destination.RemoveAt(0);
                    playerState = Etape.Arrived;
                }

                break;

            // Si le joueur est arrivé, on fait spawn les ennemis et on passe dans l'étape "Covered"
            case Etape.Arrived:

                //Debug.Log("Etape = Arrived");
                //Cam transition
                ChangeCam(false);

                col.enabled = false;
                playerState = Etape.Covered;


                break;

            // Si le joueur est à couvert, un appuie sur le bouton haut nous fait passer dans l'étape "Uncovered"
            case Etape.Covered:

                //Debug.Log("Etape = Covered");
                
                

                //Rotate player and animation
                transform.rotation = Destination.rotation;

                //transform.rotation = Quaternion.Slerp(transform.rotation, Destination.rotation, 10 * Time.deltaTime);

                //Find enemies aprés la cam transition 
                if (!EnemiesFind) FindEnemies();

                //Go to Undercovered State
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (!MainCam.isActiveAndEnabled) ChangeCam(true);
                    col.enabled = true;
                    playerState = Etape.Uncovered;
                }

                break;

            // Si le joueur est à découvert, un appuie sur le bouton bas nous fait passer dans l'étape "Covered". Il peut également tirer
            case Etape.Uncovered:

                //Debug.Log("Etape = Uncovered");

                //Look enemy and shoot
                if (target)
                {
                    LookToTarget();

                    if (Input.GetKeyDown(btnTir))
                    {
                        Fire();
                    }
                }

                //Choose Enemy
                else
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (indexEnemies == Enemies.Length / 2)
                        {
                            indexEnemies--;
                        }
                        target = Enemies[indexEnemies];
                        indexEnemies--;
                    }

                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (indexEnemies != Enemies.Length / 2) indexEnemies++;
                          target = Enemies[indexEnemies];
                        
                    }
                }

               
                //Go to Covered State
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    col.enabled = false;
                    playerState = Etape.Covered;
                }


                break;
        }
    }

    public void GoToNextPosition()
    {
        Debug.Log("Gotonextpos");
        EnemiesFind = false;

        if (destination[0])
        {
            MoveToThisPoint(destination[0]);
            playerState = Etape.Moving;
        }
    }

    void ChangeCam(bool _isActive)
    {
        MainCam.enabled = _isActive;
    }

    public void FindEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
       
        Enemies = OrganiseArrayEnemies();
        EnemiesFind = true;

        Debug.Log(Enemies.Length);

        //Player targeting enemies
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].GetComponent<TargetManager>().Targeting();
        }
    }

    GameObject[] OrganiseArrayEnemies()
    {
        
        List<GameObject> ArrayLeft = new List<GameObject>();
        List<GameObject> ArrayRight = new List<GameObject>();

        for (int i = 0; i < Enemies.Length; i++)
        {
            Vector3 relativePoint = transform.InverseTransformPoint(Enemies[i].transform.position);
            //si c'es gauche
            if (relativePoint.x < 0.0f) ArrayLeft.Add(Enemies[i]);

            //Si c'est droite
            if (relativePoint.x > 0.0f) ArrayRight.Add(Enemies[i]);

            Debug.Log("enemis a droite : " + ArrayRight.Count + " , " + "enemis a gauche : " + ArrayLeft.Count);
        }

        //trier la list de droite

        //Trier list gauche
        
        //Crée un tableau trier
        GameObject[] FinalArray = new GameObject[Enemies.Length];

        indexEnemies = (ArrayLeft.Count == ArrayRight.Count) ? Enemies.Length / 2 : (ArrayLeft.Count > ArrayRight.Count) ? ArrayLeft.Count-1 : ArrayLeft.Count;
        for (int i= 0; i < ArrayRight.Count;i++)
        {
            ArrayLeft.Add(ArrayRight[i]);
        }
        FinalArray = ArrayLeft.ToArray();
        
        return FinalArray;
    }
}

