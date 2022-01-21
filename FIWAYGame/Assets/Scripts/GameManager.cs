using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BlockRow
{

    public GameObject[] Blocks;
}

public class GameManager : MonoBehaviour
{
    public BlockRow[] BlockPlaces;
    public string[] LevelNames;
    public GameObject[] InstatiableBlocks;
    float horFact = 1.28f, vertFact = -1.28f;
    float horPos = 0f, verPos = 0f;
    public int CurrentLevel;
    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene(CurrentLevel));
    }
    IEnumerator LoadScene(int iCunrretLevel)
    {
        TextAsset mytxtData = (TextAsset)Resources.Load(LevelNames[iCunrretLevel]);
        string txt = mytxtData.text;
        string[] rows = txt.Split(';');
        foreach (string row in rows)
        {
            string[] columns = row.Split(',');
            foreach (var colum in columns)
            {
                if (colum != "0")
                    Instantiate(InstatiableBlocks[int.Parse(colum)], new Vector3(horPos, verPos, 0), Quaternion.identity);
                horPos += horFact;
            }

            verPos += vertFact;
            horPos = 0;
        }
        yield return 0;

    }
    // Update is called once per frame
    void Update()
    {

    }
}

