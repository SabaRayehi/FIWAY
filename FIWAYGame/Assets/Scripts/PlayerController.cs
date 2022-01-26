using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour

{
    [SerializeField]
    PlayerActions act;
    [Header("Player Parameters")]
    [SerializeField]
    private float fact;
    [SerializeField]
    private float factor;
    [SerializeField]
    private float jumpAmount;
    [SerializeField]
    private Vector2 moveVector;
    [SerializeField]
    private float invincible = 2.5f;
    [Header("Cool Downs")]
    [SerializeField]
    private float actionCooldown;
    [SerializeField]
    private float rushCooldown;
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private bool Jump;
    private Vector3 moves;
    private float horizontalInput;
    private bool action = false;
    private bool grounded = false;
    private bool canRush = false;
    private bool canAction = true;
    [SerializeField]
    private int direction = 1;
    private float changeDirection = .005f;
    private bool canBeHurt = true;



    private void OnEnable()
    {
        act = GameObject.Find("PlayerActions").GetComponent<PlayerActions>();
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator action_Cooldown()
    {
        yield return new WaitForSeconds(actionCooldown);
        canAction = true;
    }

    IEnumerator rush_Cooldown()
    {
        yield return new WaitForSeconds(rushCooldown);
        canRush = false;
        rb.velocity = Vector2.zero;
    }

    IEnumerator invinceble_Cooldown()
    {
        yield return new WaitForSeconds(invincible);
        canBeHurt = true;
    }
    void Update()

    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            action = true;
        }
     

    }
    private void detectDirection()
    {
        if (rb.velocity.x > changeDirection)
        {
            direction = 1;

        }
        else if (rb.velocity.x < -changeDirection)
        {
            direction = -1;
        }
        transform.localScale = new Vector3(direction, 1, 1);
       
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
        detectDirection();
        if (action && canAction)
        {
            bool actionDone = false;
            if (act.actions.Count > 0)
            {
                Action a = act.actions.Peek();

                switch (a)
                {
                    case Action.Jump:
                        if (grounded)
                            actionDone = act.JumpAction(rb, transform.up * jumpAmount);

                        break;
                    case Action.Rush:
                       
                        canRush = true;
                        actionDone = act.RushAction(rb, new Vector2(moveVector.x * direction, moveVector.y));
                        StartCoroutine(rush_Cooldown());

                        break;
                    case Action.Laser:

                        actionDone = act.LaserAction();
                        break;

                }
            }
            if (actionDone)
            {
                act.actions.Dequeue();
                action = canAction = false;
                StartCoroutine(action_Cooldown());
            }
        }

    }
    private void FixedUpdate()
    {
        movement();
    }


   
    public void Heart(Vector2 vect)
    {
        if (canBeHurt)
        {
            rb.AddForce(vect, ForceMode2D.Impulse);
            canBeHurt = false;
            StartCoroutine(invinceble_Cooldown());
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }


}
    



    
