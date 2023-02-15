using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] Color32 blockColour;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.color= blockColour;
    }

 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(this.gameObject);
        }
    }
}
