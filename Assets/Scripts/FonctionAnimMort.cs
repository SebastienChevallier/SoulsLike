using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FonctionAnimMort : MonoBehaviour
{
    public void TpPlayer()
    {
        GameObject.Find("Player").transform.position = GameObject.Find("PlayerStartPos").transform.position;
    }
    public void FinAnim()
    {
        
        SceneManager.UnloadSceneAsync("SceneMort");
    }
}
