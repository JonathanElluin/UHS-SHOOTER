using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int MaxHealth;
    int LifePoints;
    public bool isAlive = true;
    public Scrollbar LifeBar;

    public GameObject prefabConfetis;

	// Use this for initialization
	void Start () {
        LifePoints = MaxHealth;
	}
	

    public void TakeDammage(int _dammage)
    {
        LifePoints -= _dammage;
        LifeBar.size = (float)LifePoints * 1 / MaxHealth;

        // Si le personnage n'a plus de points de vie
        if (LifePoints <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
            Instantiate(prefabConfetis, transform.position, Quaternion.identity);
        }
    }
}
