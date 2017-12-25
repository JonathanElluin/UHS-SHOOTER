using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {
    //cam
    public Camera MainCam;

    //destinations
    public Transform CamFPS;
    Transform CamTPS;

    public int time = 10;

    //current destination
    Transform DestinationCam;

    bool MoveCam = false;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //Move and rotate PlayerCam to its destination
        if (MoveCam)
        {
            MainCam.transform.rotation = Quaternion.Slerp(MainCam.transform.rotation, DestinationCam.rotation, time * Time.deltaTime);
            MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, DestinationCam.position, time * Time.deltaTime);
        }

        if (!MoveCam) return;

        //Stop move and rotate
        if (MainCam.transform.rotation == DestinationCam.rotation & MainCam.transform.position == DestinationCam.position)
        {
            MoveCam = false;
        }

    }

    public void SetTPSCam(Transform _cam)
    {
        CamTPS = _cam;
    }

    public void SwitchPosCam(string _choice)
    {
        MoveCam = true;
        DestinationCam = (_choice == "TPS") ? CamTPS : CamFPS;
    }

    public bool IsMoving()
    {
        return MoveCam;
    }
}
