using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutoManager : MonoBehaviour
{
    public TextAsset TutoText;
    string[] Lines;
    int IndexLine = 0;
    public Text txt;
    public bool TutoOn;

    void Start()
    {
        if (TutoOn)
        {
            txt.transform.parent.gameObject.SetActive(true);
            Lines = TutoText.text.Split("/"[0]);
            txt.text = Lines[IndexLine];
            Debug.Log(Lines.Length);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Next();
        }
    }
    public void Next()
    {
        
        IndexLine++;
        if (Lines[IndexLine] != "(Fire)")
        {
            txt.text = Lines[IndexLine];
            if (!txt.enabled) txt.transform.parent.gameObject.SetActive(true);
        }
            
        else txt.transform.parent.gameObject.SetActive(false);
       
    }
}