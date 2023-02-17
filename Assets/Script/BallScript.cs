using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] PaddleScript paddle;
    [SerializeField] float offset;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] bool isShot;
    [SerializeField] float jumpForce;
    [SerializeField] GameManager gameManager;
    [SerializeField] Vector2 maxVelocity;
    [SerializeField] Vector2 sqrMaxVelocity;
    [SerializeField] float magnitude;
    Vector2 _tempVelocity;

    

    public Vector2 MaxVelocity
    {
        get => maxVelocity;
        set => maxVelocity = value;
    }
    private void Awake()
    {
        maxVelocity.x = maxVelocity.y = jumpForce;
        SetMaxVelocity(maxVelocity);
        if (rigidbody2D == null)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    private void Start()
    {
        _tempVelocity = maxVelocity;
    }

    void SetMaxVelocity(Vector2 maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    private void FixedUpdate()
    {
        var velocity = rigidbody2D.velocity;
        if (velocity.sqrMagnitude > sqrMaxVelocity.x || velocity.sqrMagnitude > sqrMaxVelocity.y)
        {
            rigidbody2D.velocity = velocity.normalized * maxVelocity;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!isShot)
        {
            this.transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + offset, 0);
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isShot = true;

                float randomX = Random.Range(-1, 2);
                rigidbody2D.AddForce(new Vector2(10, jumpForce), ForceMode2D.Impulse);
            }
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            BallScript[] ballScripts = FindObjectsOfType<BallScript>();

            if (ballScripts.Length>1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                isShot = false;
                this.transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + offset, 0);
                rigidbody2D.velocity = Vector2.zero;
                gameManager.Lives--;
                gameManager.GetLives();
            }
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            magnitude =paddle.Movemennt;

            if (Mathf.Sign(rigidbody2D.velocity.x) > 0 && magnitude > 0)
            {
               rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);
                
            }
            else if ((Mathf.Sign(rigidbody2D.velocity.x) > 0 && magnitude <0 ))
            {
                rigidbody2D.velocity = new Vector2(magnitude* rigidbody2D.velocity.x, rigidbody2D.velocity.y);
            }
            else if ((Mathf.Sign(rigidbody2D.velocity.x) < 0 && magnitude > 0))
            {
                rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.x, rigidbody2D.velocity.y);
            }

        }
       
    }
}
