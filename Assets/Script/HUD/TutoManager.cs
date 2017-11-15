using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutoManager : MonoBehaviour {
    public TextAsset TutoText;
    public Text txt;
    string[] sentence = new string[] { "Bienvenue dans ce tuto","Voici deux ennemis !Il faut les tuer", "Ce rond bleue est un timer" ," quand il aura disparue les ennemis vont vous tirez dessus", "Choissisez droite pour viser l'enemie de droite et gauche pour l'enemie de gauche","Tirer","enemi mort, choissez l'autre","tirer","vous avez fini le tuto" };
    int line = 0;
    public Player player;
    bool IsInit = false;
    public int TutoPart = 1;
    private void Start()
    {
        
    }
    // Use this for initialization
    public void InitTuto() {
        //if (TutoText) Debug.Log(TutoText.name);
        Debug.Log(TutoText.text);
        //sentence = TutoText.text.Split(separator:'/');
        DisplayTuto(line);
        IsInit = true;
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            NextAction(TutoPart);
        }
	}

    void DisplayTuto(int _index)
    {
        txt.text = sentence[_index];
    }

    public void NextAction(int _part)
    {
        line++;
        DisplayTuto(line);
        switch (_part)
        {
            case 1:
                //player.FindEnemies(line);
                break;
            case 2:
                Debug.Log("display touches");
                break;

        }
        
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
