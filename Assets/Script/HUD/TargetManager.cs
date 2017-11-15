using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour {

    public int time;
    public Image Timer;
    public Image Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Targeting()
    {
        Target.enabled = true;
        Timer.enabled = true;
        StartCoroutine("TimerBeforeShoot");
    }

    public void TargetingTuto(int _phase)
    {
        switch (_phase)
        {
            case 1:
                Target.enabled = true;
                break;
            case 2:
                Timer.enabled = true;
                break;
            case 3:
                StartCoroutine("TimerBeforeShoot");
                break;
        }
    }

    public void Untargetting()
    {
        Target.enabled = false;
        Timer.enabled = false;
    }
    IEnumerator TimerBeforeShoot()
    {
        for (float i = time; i> 0; i-=0.1f)
        {
            Timer.fillAmount = (i * 1) / time;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
