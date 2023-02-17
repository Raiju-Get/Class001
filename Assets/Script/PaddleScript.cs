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
    [SerializeField] CapsuleCollider2D colliderCap;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] AudioClip audioClip;

    public float Movemennt {
        get => movement;
}

    private void Start()
    {
       
         cameraSize = _cam.orthographicSize;
        screenSize = (cameraSize*_cam.aspect);
         currentSize = colliderCap.size.y;
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");//x= 1, -x=-1
        if (movement != 0)
        {
            float maxX = Mathf.Clamp(this.transform.position.x, -screenSize + (currentSize ) * 0.5f, screenSize - (currentSize) * 0.5f);
            this.transform.position = new Vector3(maxX+movement * moveSpeed*Time.deltaTime, this.transform.position.y, 0);
        }
      
       
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            audioPlayer.PlayAudio(audioClip);
        }
    }
}
