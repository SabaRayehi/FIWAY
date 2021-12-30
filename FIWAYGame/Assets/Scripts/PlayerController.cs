using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public float factor = 0.09f;
    public float jumpAmount = 0.5f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    private bool Jump;
    private Vector3 moveVector;
    public int[] arr;
     public Stack<int> myStack = new Stack<int>();

    void Start()
    {

        Jump = true;
        moveVector = new Vector3(1 * factor, 0, 0);
        int[] arr = new int[] { 0, 0, 1 };
       
        myStack.Push(0);
        myStack.Push(1);
        myStack.Push(0);
        myStack.Push(1);

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
       {
            pleyerActions(myStack);

        }

       if (Input.GetKeyDown(KeyCode.DownArrow))
       {
            pleyerActions(myStack);

        }

       if (Input.GetKeyDown(KeyCode.Space) && Jump)
       {
            pleyerActions(myStack);
        }
      
       



    }



    private void pleyerActions(Stack<int> stackActions)
    {
      
         Debug.Log("stackActions");
      
        if (stackActions.Count > 0)
        {
            var p_actions = stackActions.Pop();

            Debug.Log("currentActions " + p_actions);
            
            if (p_actions == 0)
            {
               
                rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);

            }
    
            else if (p_actions == 1)
            {
                rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);


            }


        }

    }

    }



    
