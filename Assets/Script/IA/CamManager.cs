using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {
    //cam
    public Camera MainCam;
    Vector3 PosFPS;
    Vector3 PosTPS;

    // Use this for initialization
    void Start () {
        PosFPS = MainCam.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetTacticalPos(Transform _campos)
    {
        PosTPS = _campos.position;
        //CamAnimator = TacticalCam.gameObject.GetComponent<Animator>();
    }
    void SwitchPosCam(Vector3 _PosDestination)
    {
        //MainCam.transform.rotation = Quaternion.Slerp(transform.rotation, GetDestination().rotation, 10 * Time.deltaTime);
        MainCam.transform.position = Vector3.MoveTowards(transform.position, _PosDestination, 10 * Time.deltaTime);
        //CamAnimator.SetBool("IsMain", _IsMain);
    }
}
