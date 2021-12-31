using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScreen : MonoBehaviour
{
  
    void Start()
    {
    }

    public void Select(string levelName)
    {
        SceneManager.LoadScene (levelName);
    }

}
