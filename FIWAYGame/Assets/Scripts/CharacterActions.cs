using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowUpPrefabs;
    public GameObject leftRightArrowPrefabs;
    public int[] arr;
  
    void Start()
    {
        PrefabInitial();
    }

    // Update is called once per frame
    void Update()
    {}
    
    void PrefabActions()
    {
        int[] arr = new int[] { 0, 0, 1, 0, 1 };
        float tr = 0;
        for (int i = 0; i < arr.Length; i++)
        {
         
            GameObject go;

            if (arr[i] == 0)
            {
                go = Instantiate(arrowUpPrefabs);
                go.transform.position = new Vector3((transform.position.x) + tr, transform.position.y, transform.position.z);
                if (i < arr.Length - 1)
                {
                    if (arr[i + 1] == 0)
                        tr = tr + 1.0f;
                    else
                        tr = tr + 0.5769285f + 1.0f;
                }    

            }
            else
            {
                go = Instantiate(leftRightArrowPrefabs);
                go.transform.position = new Vector3((transform.position.x) + tr, transform.position.y, transform.position.z);
                if (i < arr.Length - 1)
                {
                    if (arr[i + 1] == 0 && i < arr.Length - 1)
                        tr = tr + 1.0f;
                    else
                        tr = tr + 0.5769285f + 1.0f;

                }
              
            }


        }
    }
}
