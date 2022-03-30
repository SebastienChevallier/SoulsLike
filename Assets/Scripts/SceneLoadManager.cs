using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private bool menuOn = false;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("SceneMenu", LoadSceneMode.Additive);
    }
    private void Update()
    {
        MenuIG();
    }
    void MenuIG()
    {
        if (Input.GetButtonDown("Start") && !menuOn && SceneManager.GetSceneByName("Seb").isLoaded)
        {
            SceneManager.LoadScene("SceneMenu_InGame", LoadSceneMode.Additive);
            menuOn = true;
        }
        else if(Input.GetButtonDown("Start") && menuOn && SceneManager.GetSceneByName("Seb").isLoaded)
        {
            SceneManager.UnloadSceneAsync("SceneMenu_InGame");
            menuOn = false;
        }
    }
}
