using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int MaxHealth;
    int LifePoints;
	// Use this for initialization
	void Start () {
        LifePoints = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDammage(int _dammage)
    {
        LifePoints -= _dammage;
        Debug.Log(LifePoints);
        if (LifePoints <= 0)
        {
            Destroy(gameObject);
            Debug.Log("YOU ARE DEAD");
        }
    }
}
