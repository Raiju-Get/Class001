using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] BallScript ballScript;
    [SerializeField] PaddleScript paddleScript;
    [SerializeField] int numberOfBalls;
    [SerializeField] List<GameObject> balls = new List<GameObject>();
    [SerializeField] bool ballDuplicate;
    [SerializeField] bool paddleLenght;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (ballDuplicate) 
            {
                for (int i = 0; i < numberOfBalls; i++)
                {
                    GameObject newBall = Instantiate(ballScript.gameObject, transform.position, Quaternion.identity);
                    balls.Add(newBall);
                    balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-ballScript.GetComponent<Rigidbody2D>().velocity.x, ballScript.GetComponent<Rigidbody2D>().velocity.x), ballScript.GetComponent<Rigidbody2D>().velocity.y);
                }
            }

            if (paddleLenght)
            {
                paddleScript.gameObject.transform.localScale = new Vector2(paddleScript.gameObject.transform.localScale.x*2f, paddleScript.gameObject.transform.localScale.y);
            }
            Destroy(this.gameObject);
        }
    }
}
