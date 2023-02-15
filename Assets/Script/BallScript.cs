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

    private void Start()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
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
                rigidbody2D.AddForce(new Vector2(randomX * 10, jumpForce), ForceMode2D.Impulse);
            }
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            isShot = false;
            this.transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + offset, 0);
            rigidbody2D.velocity = Vector2.zero;
            gameManager.Lives--;
            gameManager.GetLives();
        }
    }
}
