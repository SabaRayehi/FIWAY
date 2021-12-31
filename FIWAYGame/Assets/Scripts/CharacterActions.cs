using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowUpPrefabs;
    public GameObject leftRightArrowPrefabs;
    public int[] arr;
    public float factorLeftRightArrow = 0.5769285f;
    public float factorArrowUp = 1.0f ;

    void Start()
    {
        int[] arr = new int[] { 0, 0, 1};
        PrefabActions(arr);
    }

    // Update is called once per frame
    void Update()
    {}
    
    void PrefabActions(int[] arr)
    {
     
        float pos = 0;
        for (int i = 0; i < arr.Length; i++)
        {
         
            GameObject objectActoins;

            if (arr[i] == 0)
            {
                objectActoins = Instantiate(arrowUpPrefabs);

                objectActoins.transform.position = new Vector3((transform.position.x) + pos, transform.position.y, transform.position.z);

                if (i < arr.Length - 1)
                {
                    if (arr[i + 1] == 0)
                        pos = pos + factorArrowUp;
                    else
                        pos = pos + factorArrowUp + factorLeftRightArrow;
                }    

            }
            else
            {
                objectActoins = Instantiate(leftRightArrowPrefabs);

                objectActoins.transform.position = new Vector3((transform.position.x) + pos, transform.position.y, transform.position.z);

                if (i < arr.Length - 1)
                {
                    if (arr[i + 1] == 0 && i < arr.Length - 1)
                        pos = pos + factorArrowUp;
                    else
                        pos = pos + factorArrowUp + factorLeftRightArrow;

                }
              
            }


        }
    }
}
