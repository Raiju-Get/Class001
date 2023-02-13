using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float movement;
    [SerializeField] float cameraSize;
    [SerializeField] float currentSize;
    [SerializeField] Camera _cam;



    private void Start()
    {
         cameraSize = _cam.orthographicSize * 2f;
         currentSize = this.GetComponent<CapsuleCollider2D>().size.y;
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        
        float maxX = Mathf.Clamp( this.transform.position.x, -cameraSize + (currentSize * 5), cameraSize-(currentSize*5));
        if (movement!=0)
        {
            this.transform.position = new Vector3(maxX + movement*moveSpeed*Time.deltaTime, this.transform.position.y,0);
        }
    }
}
