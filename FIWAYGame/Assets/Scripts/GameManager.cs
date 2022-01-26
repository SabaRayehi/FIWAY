using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct LevelData
{

    public string LevelName;
    public int LevelTime;
    public int LifeAdd;
    public Action[] StartActions;
}
public class GameManager : MonoBehaviour
{
   
    public GameObject[] InstatiableBlocks;
    float horFact = 1.28f, vertFact = -1.28f;
    float horPos = 0f, verPos = 0f;
    public int CurrentLevel;
    bool gameStarted = false;
    public LevelData[] Levels;
    private PlayerController player;
    private List<GameObject> allBlocks = new List<GameObject>();
    public GameObject LevelButtonTemplate;
    public Transform LevelButtonPlaceholder;
    public GameObject GameOverPanel, LevelsPanel, VictoryPanel;
    public UIController UI;
    int globalHealth = 0;
    int levelTime = 0;
    [Range(0, 10)]
    public float TimeScale = 1;

    
    void Start()
    {
        // StartCoroutine(LoadScene(CurrentLevel));
        Time.timeScale = TimeScale;
        int i = 0;

        foreach (var l in Levels)
        {
            GameObject go = Instantiate(LevelButtonTemplate, LevelButtonPlaceholder);
            go.GetComponent<LevelButtonLogic>().levelIndex = i;
            go.GetComponentInChildren<Text>().text = i.ToString();
            i++;
        }
    }

    public void AddAction(Action iAction)
    {
        print(iAction);
        GameObject.Find("PlayerActions").GetComponent<PlayerActions>().actions.Enqueue(iAction);

    }
    IEnumerator LoadScene(int iCunrretLevel)
    {
        TextAsset mytxtData = (TextAsset)Resources.Load(Levels[iCunrretLevel].LevelName);
        string txt = mytxtData.text;
        string[] rows = txt.Split(';');
        float horPos = 0f, verPos = 0f;
        foreach (string row in rows)
        {
            string[] columns = row.Trim().Split(',');
            foreach (var colum in columns)
            {

                if (colum.Length > 0)
                {
                    if (int.Parse(colum) != 0)
                    {
                        GameObject go = Instantiate(InstatiableBlocks[int.Parse(colum.Trim())], new Vector3(horPos, verPos, 0), Quaternion.identity);
                        allBlocks.Add(go);
                    }
                    horPos += horFact;
                }


            }

            verPos += vertFact;
            horPos = 0;
        }
        yield return 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        foreach (Action a in Levels[iCunrretLevel].StartActions)
        {
            GameObject.Find("PlayerActions").GetComponent<PlayerActions>().actions.Enqueue(a);
        }
        gameStarted = true;
        levelTime = Levels[iCunrretLevel].LevelTime;
        globalHealth += Levels[iCunrretLevel].LifeAdd;
        UI.UpdateHealth(globalHealth);
        StartCoroutine(StartTimer());

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && player)
            UI.UpdateUI();
    }

    public void LoadLevel(int iLevel)
    {
        CurrentLevel = iLevel;
        RestartGame();
        LevelsPanel.SetActive(false);

    }

    public void LevelFinished()
    {
        CurrentLevel++;
        if (CurrentLevel < Levels.Length)
        {
            StopAllCoroutines();
            gameStarted = false;
            DestroyLevel();
            StartCoroutine(LoadScene(CurrentLevel));

        }
        else
        {
            StopAllCoroutines();
            gameStarted = false;
            DestroyLevel();
            VictoryPanel.SetActive(true);
            UI.UpdateWonScreen(globalHealth, Levels.Length);

        }
    }


    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        StopAllCoroutines();
        gameStarted = false;
        DestroyLevel();
        StartCoroutine(LoadScene(CurrentLevel));
    }

    void DestroyLevel()
    {
        foreach (GameObject g in allBlocks)
        {
            Destroy(g);
        }
        allBlocks = new List<GameObject>();
        levelTime = 0;

    }
    public void GameOver()
    {
        globalHealth = 0;
        GameOverPanel.SetActive(true);
        DestroyLevel();
        gameStarted = false;
        GameObject.Find("PlayerActions").GetComponent<PlayerActions>().actions.Clear();
      
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LaserActed()
    {
        foreach (GameObject g in allBlocks)
        {
            if (g.CompareTag("Laser"))
            {
                g.SetActive(!g.activeInHierarchy);
            }
        }
    }
    public void ChangeHealth(int iAmount)
    {

        globalHealth += iAmount;
        if (globalHealth < 0)
        {
            GameOver();
        }
        UI.UpdateHealth(globalHealth);

    }
    public void AddTime(int iTime)
    {
        levelTime += iTime;
    }
    IEnumerator StartTimer()
    {

        while (true)
        {
            UI.UpdateTimer(levelTime);

            yield return new WaitForSeconds(TimeScale);
            levelTime--;
            if (levelTime < 0)
                break;

        }
        GameOver();
    }

}

