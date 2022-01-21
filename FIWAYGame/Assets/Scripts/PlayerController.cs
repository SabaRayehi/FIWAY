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
    private float horizontalInput;
    private bool action = false;
    private bool grounded = false;
    private bool canRush = false;




    void Start()
    {
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
    



    
