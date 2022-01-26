using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic2 : MonoBehaviour
{
    [SerializeField]
    int HealthReduction = -1;
    [SerializeField]
    Vector2 HeartDirection = new Vector2(0, 10);
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Heart(HeartDirection);
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeHealth(HealthReduction);

        }
  

    }

}

