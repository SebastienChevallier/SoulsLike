using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private bool menuOn = false;
    public SO_Player _PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("SceneMenu", LoadSceneMode.Additive);
        _PlayerStats.ResetValue();
    }
    private void Update()
    {
        MenuIG();
    }
    void MenuIG()
    {
        if (Input.GetButtonDown("Start")  && SceneManager.GetSceneByName("Seb").isLoaded)
        {
            if (!menuOn)
            {
                SceneManager.LoadScene("SceneMenu_InGame", LoadSceneMode.Additive);
                menuOn = true;
            }
            else
            {
                menuOn = false;
                SceneManager.UnloadSceneAsync("SceneMenu_InGame");
                
            }            
        } 
    }
}
