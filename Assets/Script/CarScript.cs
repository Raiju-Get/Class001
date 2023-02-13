using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float movement;
    [SerializeField] float direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Vertical");
        direction = Input.GetAxisRaw("Horizontal");
        if (movement != 0)
        {
            this.transform.Translate(0, moveSpeed*movement*Time.deltaTime, 0);
        }

        if (direction !=0)
        {
            this.transform.Rotate(0, 0, -rotationSpeed*direction*Time.deltaTime);
        }
    }
}
