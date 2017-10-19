using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public int dammages;
    public int speed; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,0, transform.localPosition.z * speed * Time.deltaTime));
	}

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthManager>().TakeDammage(dammages);
    }
}
