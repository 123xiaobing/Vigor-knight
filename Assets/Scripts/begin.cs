using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class begin : MonoBehaviour
{
    public GameObject IntroductionBtn;
    public GameObject IntroductionPic;
    public GameObject IntroductoffBtn;

    public GameObject QuitBtn;

    public void IntroductionOn()
    {
        IntroductionPic.SetActive(true);
    }

    public void IntroductionOff()
    {
        IntroductionPic.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
