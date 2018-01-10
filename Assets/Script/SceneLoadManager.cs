using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {
    SceneLoadManager SceneLoadMngr;
    List<Scene> Scenes = new List<Scene>();
    
    // Use this for initialization

    void Start()
    {
        DontDestroyOnLoad(this);
        SceneLoadMngr = this;
        Debug.Log("manager");
        for (int i=0; i< SceneManager.sceneCountInBuildSettings; i++)
        {
            Scenes.Add(SceneManager.GetSceneByBuildIndex(i));
            if (Scenes[i] != SceneManager.GetActiveScene())
            {
                SceneManager.LoadScene(i, LoadSceneMode.Additive);
            }
        }
    }


    public void NextLvl(int _index)
    {
        SceneManager.SetActiveScene(Scenes[_index]);
    }

}

public class SceneMngr : MonoBehaviour
{
    
}
