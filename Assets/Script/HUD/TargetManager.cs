using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour {

    public int timer;
    public Image ImageTimer;
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
    }

    public void DisplayTimer()
    {
        ImageTimer.enabled = true;
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
                ImageTimer.enabled = true;
                break;
            case 3:
                StartCoroutine("TimerBeforeShoot");
                break;
        }
    }

    public void Untargetting()
    {
        Target.enabled = false;
        ImageTimer.enabled = false;
    }
    IEnumerator TimerBeforeShoot()
    {
        for (float i = timer; i> 0; i-=0.1f)
        {
            ImageTimer.fillAmount = (i * 1) / timer;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
