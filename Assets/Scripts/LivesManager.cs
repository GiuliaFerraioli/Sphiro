using System;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Image[] hearts;
    public GameObject gameOverPanel;
    
    private int lives = 3;
    private BallSpawner _ballSpawner;
    private void Start()
    {
        _ballSpawner = FindObjectOfType<BallSpawner>();
    }

    public void UpdateLives()
    {
        if (lives > 0)
        {
            lives--;
        }
        
        RemoveHeart();

        if (lives == 0)
        {
            gameOverPanel.SetActive(true);
            _ballSpawner.gameOver = true;
        }
    }

    private void RemoveHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < lives);
        }
    }

    //called from the scene button on click
    public void StartNewGame()
    {
        lives = 3;
        RemoveHeart();
        _ballSpawner.gameOver = false;
        gameOverPanel.SetActive(false);
    }
}
