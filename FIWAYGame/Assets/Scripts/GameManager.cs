using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string[] LevelNames;
    public GameObject[] InstatiableBlocks;
    float horFact = 1.28f, vertFact = -1.28f;
    float horPos = 0f, verPos = 0f;
    public int CurrentLevel;
    bool gameStarted = false;
    public LevelData[] Levels;
    private PlayerController player;
    private List<GameObject> allBlocks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene(CurrentLevel));
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}

