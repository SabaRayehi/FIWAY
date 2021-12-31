using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{

    public float factor = 0.09f;
    public float jumpAmount = 0.5f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    private bool Jump;
    private Vector3 moveVector;
    public int[] arr;
    public int maxNumber;
    public Stack<int> stackAction = new Stack<int>();
    public Stack<GameObject> stackGameobject = new Stack<GameObject>();
    public GameOverManagement gameOverManagement;
    public LevelManagment levelManagment;
   



    void Start()
    {
        GameObject  []other;

        Jump = true;

        moveVector = new Vector3(1 * factor, 0, 0);

        int[] arr = new int[] { 0, 0, 1 };


        other = GameObject.FindGameObjectsWithTag("Actions");

        maxNumber = GameObject.FindGameObjectsWithTag("Actions").Length;

        Debug.Log("max" + maxNumber);

        for (int i = maxNumber-1; i >=0 ; i--)
        {
          stackGameobject.Push(other[i]);
        }
        for (int i = 0; i < arr.Length; i++)
        {
            stackAction.Push(arr[i]);
           
        }
       

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
            pleyerActions(stackAction,stackGameobject) ;

        }

       if (Input.GetKeyDown(KeyCode.DownArrow))
       {
            pleyerActions(stackAction,stackGameobject);

        }

       if (Input.GetKeyDown(KeyCode.Space) && Jump)
       {
            pleyerActions(stackAction,stackGameobject);
        }
      
       



    }



    private void pleyerActions(Stack<int> stackPlayerActions , Stack<GameObject> stackActionsGameobject)
    {
      
         Debug.Log("stackActions");
     


        if (stackPlayerActions.Count > 0)
        {
            var p_actions = stackPlayerActions.Pop();

            Debug.Log("currentActions " + p_actions);
            
            if (p_actions == 0)
            {
               
                rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
      
                 Destroy(stackActionsGameobject.Pop());

            }
    
            else if (p_actions == 1)
            {
                rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
              
                Destroy(stackActionsGameobject.Pop());

            }


        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))

        {
            Debug.Log("DEATH ZONE");
            // this.gameObject.SetActive(false);
           SceneManager.LoadScene("GameOverScene");

        }
        if (collision.gameObject.CompareTag("Win")) ;
        {
            this.gameObject.SetActive(false);
           levelManagment.level();
        }

    }

   
    
}



    
