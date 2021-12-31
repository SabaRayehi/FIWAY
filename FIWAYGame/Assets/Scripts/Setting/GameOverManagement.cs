using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup()
    {

        gameObject.SetActive(true);

    }
  

    public void RetryManagement()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    public void Quit()
    {
       
        Debug.Log("Quit");
       // UnityEditor.EditorApplication.isPlaying = false;
    }
}


