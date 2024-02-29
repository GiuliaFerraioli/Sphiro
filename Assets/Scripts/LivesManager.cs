using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public Image[] hearts;
    public GameObject gameOverPanel;
    public int points;
    public TextMeshProUGUI pointsText;


    private int lives = 3;
    private BallSpawner _ballSpawner;
    private GameObject _bag;

    private void Start()
    {
        _ballSpawner = FindObjectOfType<BallSpawner>();
        _bag = FindObjectOfType<BagController>().gameObject;
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
            _bag.SetActive(false);
        }
    }

    public void IncreasePoints()
    {
        points++;
        pointsText.text = points.ToString();
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
        points = 0;
        pointsText.text = points.ToString();
        RemoveHeart();
        _ballSpawner.gameOver = false;
        _bag.SetActive(true);

        gameOverPanel.SetActive(false);
    }
}