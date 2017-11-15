using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject[] checkPoints;
    public GameObject prefabEnemy;

    // Use this for initialization
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {

                GameObject _enemy = Instantiate(prefabEnemy, spawnPoints[i].transform.position, Quaternion.identity);
                Enemy scriptEnemy =_enemy.GetComponent<Enemy>();



                scriptEnemy.checkPoint = checkPoints[i];
                scriptEnemy.target = other.gameObject;
            }
            
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
