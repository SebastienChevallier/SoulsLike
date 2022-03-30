using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Script_Menu : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject = GameObject.Find("Play");
    }
    public void OnPlayGame()
    {
        SceneManager.UnloadSceneAsync("SceneMenu");
        SceneManager.LoadScene("SceneLoadAsync", LoadSceneMode.Additive);
        
        
    }
    public void OnOption()
    {

    }
    public void OnCredit()
    {

    }
    public void OnQuit()
    {
        Application.Quit();
    }

    IEnumerator Unloadscene(string oldSceneName)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(oldSceneName);

        while (!asyncUnload.isDone)
        {
            yield return null;
        }

        if (asyncUnload.isDone)
        {
            
        }
    }
}
