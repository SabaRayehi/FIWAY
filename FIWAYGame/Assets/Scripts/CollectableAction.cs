using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAction : MonoBehaviour
{

    public Action myAction;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddAction(myAction);
            gameObject.SetActive(false);
        }
    }
}
