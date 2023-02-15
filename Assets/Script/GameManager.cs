using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;

    public int Lives
    {
        get => lives;
        set => lives = value;
    }



    private void Start()
    {
        GetLives();
    }
    public void GetLives()
    {
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
