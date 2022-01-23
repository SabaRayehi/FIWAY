using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCollectable : MonoBehaviour
{
    public int LifeToAdd =1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeHealth(LifeToAdd);
            gameObject.SetActive(false);
        }
    }
}

