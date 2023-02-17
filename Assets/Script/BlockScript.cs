using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] Color32 blockColour;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioClip destoryClip;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] GameManager gameManager;
    [SerializeField] int hitNumber;
    [SerializeField]
    Sprite[] images = new Sprite[3];
    [SerializeField] TextMeshPro hitText;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        gameManager.numberOfBlock++;
    }
    void Start()
    {
        GetHItText();
        spriteRenderer.color = blockColour;

    }

    private void GetHItText()
    {
        hitText.text = hitNumber.ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
          
            audioPlayer.PlayAudio(destoryClip);
            
            if (gameManager.numberOfBlock <=0)
            {
                gameManager.NextLevel();
            }
            hitNumber--;
            GetHItText();
            if (hitNumber==2)
            {
                spriteRenderer.color = Color.yellow;
            }

            if (hitNumber==1)
            {
                spriteRenderer.color = Color.red;
            }
            if (hitNumber<=0)
            {
                gameManager.numberOfBlock--;
                GameObject partileSystem = Instantiate(particle.gameObject, this.transform.position, Quaternion.identity);
                Destroy(partileSystem, 1.5f);
                Destroy(this.gameObject);
                
            }
            else
            {
                spriteRenderer.sprite = images[hitNumber-1];
            }
            

        }
        
    }
}
