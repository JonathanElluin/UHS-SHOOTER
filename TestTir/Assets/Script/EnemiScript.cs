using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiScript : MonoBehaviour {

    HealthManager HealthMngr;
    public GameObject Projectile;
    public int dammages;
    bool CanFire = true;
	// Use this for initialization
	void Start () {
        HealthMngr = GetComponent<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B) && CanFire)
        {
                Fire();
                CanFire = false;
                StartCoroutine("FireTime");
        }
	}

    IEnumerator FireTime()
    {
        yield return new WaitForSeconds(1.0f);
        CanFire = true;
    }
    void Fire()
    {
        GameObject _projectil = (GameObject)Instantiate(Projectile, transform.position, transform.rotation);
        _projectil.GetComponent<Projectile>().dammages = dammages;
    }
}
