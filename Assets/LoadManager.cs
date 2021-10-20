using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider slider;
    public Text text;

    public GameObject startPIC;

    public void LoadLevelOne()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        if(startPIC)
        startPIC.SetActive(false);

        LoadScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;//不自动跳转

        while(!operation.isDone)
        {
            slider.value = operation.progress;

            text.text = operation.progress * 100 + "%";

            if(operation.progress==0.9f)
            {

                slider.value = 1;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

}
