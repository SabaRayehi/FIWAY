using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public float factor = 0.01f;
    public float jumpAmount = 0.5f;
    public Rigidbody2D rb;

    private bool Jump;
    private Vector3 moveVector;

    void Start()
    {

        Jump = true;
        moveVector = new Vector3(1 * factor, 0, 0);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= moveVector;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += moveVector;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
         
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
           
        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
          
        }
    }
}


   