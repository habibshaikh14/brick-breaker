using UnityEngine;

public class Paddle : MonoBehaviour {
    // Configuration Parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] AudioClip bounceSoundClip;

    // Cached references
    LevelManager levelManager;
    GameStatus gameStatus;
    Ball ball;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
    private void Update()
    {
        if (!levelManager.GetTotalNumberOfBlocks().Equals(0))
        {
            MovePaddle();
        }
    }

    private void MovePaddle()
    {
        Vector2 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(GetPosX(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetPosX() {
        if (gameStatus.GetAutoPlay())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(bounceSoundClip, GameObject.Find("Game Camera").transform.position);
    }
}
