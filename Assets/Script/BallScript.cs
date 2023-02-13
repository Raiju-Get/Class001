using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] PaddleScript paddle;
    [SerializeField] float offset;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] bool isShot;


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
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShot= true;
            rigidbody2D.AddForce(new Vector2(0,50),ForceMode2D.Impulse);
        }
    }
}
