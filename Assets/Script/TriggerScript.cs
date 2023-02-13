using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] Color32 currentColour; 
    [SerializeField] Color32 nextColourColour; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Print");
        SpriteRenderer thisImage = GetComponent<SpriteRenderer>();
        thisImage.color = nextColourColour;
    }
}
