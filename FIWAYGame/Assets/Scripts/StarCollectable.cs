using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour
{
    public int TimeToAdd =20;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddTime(TimeToAdd);
            gameObject.SetActive(false);
        }
    }
}
