using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour

{
    [Header("Player Parameters")]
    [SerializeField]
    private float fact;
    [SerializeField]
    private float factor;
    [SerializeField]
    private float jumpAmount;
    [SerializeField]
    private Vector3 moveVector;
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private bool Jump;
    private Vector3 moves;
    public int[] arr;
    public int maxNumber;
    public Stack<int> stackAction = new Stack<int>();
    public Stack<GameObject> stackGameobject = new Stack<GameObject>();
    public GameOverManagement gameOverManagement;
    public LevelManagment levelManagment;
    private float horizontalInput;
    private bool  action = false;
    private bool grounded = false;
    private bool canRush = false;




    void Start()
    {
        GameObject  []other;

        Jump = true;

        moveVector = new Vector3(1 * factor, 0, 0);
        moves= new Vector3( 1 * fact,0, 0);

        int[] arr = new int[] { 0, 0, 1 };


        other = GameObject.FindGameObjectsWithTag("Actions");

        maxNumber = GameObject.FindGameObjectsWithTag("Actions").Length;

        Debug.Log("max" + maxNumber);

        for (int i = maxNumber-1; i >=0 ; i--)
        {
          stackGameobject.Push(other[i]);
        }
        for (int i = (arr.Length) - 1 ; i >=0; i--)
        {
            stackAction.Push(arr[i]);
           
        }
       

    }

    void Update()

    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            action = true;
        }
        movement();

    }
    private void movement()
    {
        if (canRush)
        {
            if (grounded)
            {

                rb.velocity = new Vector2((transform.right * fact * horizontalInput).x, rb.velocity.y);
                transform.Translate(transform.right * fact * horizontalInput * Time.deltaTime);
            }
           
            else
            {
                rb.velocity = new Vector2((transform.right * factor * horizontalInput).x, rb.velocity.y);
                transform.Translate(transform.right * factor * horizontalInput * Time.deltaTime);
            }

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
                transform.position += moves;

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
       

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win")) ;

        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                 Debug.Log("Win");
                 SceneManager.LoadScene("LevelScene");
            }

        }
    }




    }



    
