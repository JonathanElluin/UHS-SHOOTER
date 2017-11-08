using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform spawnPoint;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = spawnPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
