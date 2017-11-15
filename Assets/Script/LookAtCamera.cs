using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    Vector3 PosCamera = Vector3.zero;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        PosCamera = Camera.main.transform.position;
        transform.LookAt(new Vector3(PosCamera.x, transform.position.y, PosCamera.z));
	}
}
