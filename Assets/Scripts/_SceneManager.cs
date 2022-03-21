using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _SceneManager : MonoBehaviour
{
    //public GameObject fadeScreen;
    public GameObject loadingScreen;
    public Slider slider;

    void Start()
    {
        //fadeScreen.SetActive(true);
        StartCoroutine(LoadScene_Coroutine("Seb"));
        StartCoroutine(LoadScene_Coroutine("Scene_UI"));
    }

    IEnumerator LoadScene_Coroutine(string sceneName)
    {
        // Fade to black
        yield return new WaitForSeconds(1);
        

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (operation.isDone == false)
        {
            float pct = Mathf.Clamp01(operation.progress / .9f);
            slider.value = pct;
            print(pct);
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
