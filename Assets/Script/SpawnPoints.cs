using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject[] checkPoints;
    public GameObject prefabEnemy;
    private List<GameObject> enemyList = new List<GameObject>();
    private int EnemiesAlive = 0;
    private Player playerScript;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!playerScript)
            {
                playerScript = other.gameObject.GetComponent<Player>();
            }

            for (int i = 0; i < spawnPoints.Length; i++)
            {

                GameObject _enemy = Instantiate(prefabEnemy, spawnPoints[i].transform.position, Quaternion.identity);
                Enemy scriptEnemy =_enemy.GetComponent<Enemy>();


                scriptEnemy.spawnPointsScript = this;
                scriptEnemy.checkPoint = checkPoints[i];
                scriptEnemy.target = other.gameObject;
                EnemiesAlive++;
            }
            
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public void EnemyDied()
    {
        EnemiesAlive--;

        if ((EnemiesAlive == 0) && (playerScript))
        {
            playerScript.GoToNextPosition();
        }
    }
}
