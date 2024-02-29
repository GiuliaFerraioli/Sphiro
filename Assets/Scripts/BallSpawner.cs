using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    public GameObject yellowBall;
    public GameObject violetBall;
    [HideInInspector] public bool gameOver = false;

    private Camera _mainCamera;
    private float _leftBound, _rightBound, _topBound, _ballSize;
    private float _spawnTimer;

    private float _spawnInterval = 1.5f;

    //rate to decrease the spawn interval
    private float _difficultyIncreaseRate = 0.01f;


    private void Start()
    {
        _mainCamera = Camera.main;
        _leftBound = _mainCamera.ScreenToWorldPoint(Vector3.zero).x;
        _rightBound = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        _topBound = _mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        _ballSize = yellowBall.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        if (!gameOver)
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnInterval)
            {
                SpawnBall();
                _spawnTimer = 0f;

                // Increase difficulty by decreasing spawn interval
                _spawnInterval = Mathf.Max(0.3f, _spawnInterval - _difficultyIncreaseRate);
            }
        }
        else //when game resets
        {
            _spawnInterval = 1.5f;
            _spawnTimer = 0f;
        }
    }

    private void SpawnBall()
    {
        #region randomSpawn

        GameObject ballPrefab = Random.Range(0f, 1f) > 0.5f ? yellowBall : violetBall;
        //spawn ball preventing to go outside screen
        var spawnPos = new Vector2(Random.Range(_leftBound + _ballSize / 2, _rightBound - _ballSize / 2),
            _topBound + 0.6f);
        var spwnedBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        #endregion

        #region randomSpeed

        var ballRb = spwnedBall.GetComponent<Rigidbody2D>();
        ballRb.gravityScale = Random.Range(0.5f, 1.0f);

        #endregion
    }
}