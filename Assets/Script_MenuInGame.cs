using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_MenuInGame : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.UnloadSceneAsync("SceneMenu_InGame");
    }
    public void OnClickQuit()
    {
        
        SceneManager.UnloadSceneAsync("SceneMenu_InGame");
        SceneManager.UnloadSceneAsync("Scene_UI");
        SceneManager.UnloadSceneAsync("Seb");
        //StartCoroutine(LoadScene_Coroutine("SceneMenu"));
        SceneManager.LoadSceneAsync("SceneMenu", LoadSceneMode.Additive);

    }

    IEnumerator LoadScene_Coroutine(string sceneName)
    {
        // Fade to black
        yield return new WaitForSeconds(1);


        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (operation.isDone == false)
        {
            
            yield return null;
        }                
    }
}
