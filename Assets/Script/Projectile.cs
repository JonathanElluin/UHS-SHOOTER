using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public int damages;
    private const int speed = 50; 


	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);


        if (other.tag =="CheckPoint")
        {

        }

        // If the projectile hits an enemy or the player, it deals damages and disappear
        else if (other.tag == "Enemi" || other.tag == "Player")
        {
            Debug.Log("character");
            other.gameObject.GetComponent<HealthManager>().TakeDammage(damages);
            Destroy(this.gameObject);
        }

        // If it hits a wall, it disappear. 
        else if (other.tag == "Mur")
        {
            Debug.Log("wall");
            Destroy(this.gameObject);
        }

        else
        {
            //Debug.Log(other7/);
        }
    }
}
