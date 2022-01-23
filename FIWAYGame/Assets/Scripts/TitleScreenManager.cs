using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void _Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
