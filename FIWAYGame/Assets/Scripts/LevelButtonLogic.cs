using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonLogic : MonoBehaviour
{
    public int levelIndex;
    public void LoadLevel()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevel(levelIndex);
    }
}
