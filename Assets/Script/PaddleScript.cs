using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float movement;
    [SerializeField] float cameraSize;
    [SerializeField] float currentSize;
    [SerializeField] float screenSize;
    [SerializeField] Camera _cam;



    private void Start()
    {
         cameraSize = _cam.orthographicSize;
        screenSize = (cameraSize*_cam.aspect);
         currentSize = this.GetComponent<CapsuleCollider2D>().size.y;
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");//x= 1, -x=-1
        
        float maxX = Mathf.Clamp( this.transform.position.x, -screenSize +(currentSize*5)*0.5f , screenSize - (currentSize * 5) * 0.5f);
        if (movement!=0)
        {
            this.transform.position = new Vector3(maxX + movement*moveSpeed*Time.deltaTime, this.transform.position.y,0);
        }
    }
}
