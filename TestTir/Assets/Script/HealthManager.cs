using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int MaxHealth;
    int LifePoints;
    public bool isAlive = true;

    public GameObject prefabConfetis;

	// Use this for initialization
	void Start () {
        LifePoints = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDammage(1);
        }
	}

    public void TakeDammage(int _dammage)
    {
        LifePoints -= _dammage;
        Debug.Log(LifePoints);

        // Si le personnage n'a plus de points de vie
        if (LifePoints <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
            Debug.Log("YOU ARE DEAD");
            Instantiate(prefabConfetis, transform.position, Quaternion.identity);
        }
    }
}
