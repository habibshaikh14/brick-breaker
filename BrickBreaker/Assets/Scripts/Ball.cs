using UnityEngine;

public class Ball : MonoBehaviour {
    // Configuratuin parameters
    [SerializeField] float pushX = 5f;
    [SerializeField] float pushY = 20f;
    [SerializeField] float randomFactor = 0.5f;
    [SerializeField] float ballPositionOffsetY = 0.5f;
    [SerializeField] GameObject paddle;
    [SerializeField] AudioClip[] ballSounds;

    // State variables
    private bool gameStarted = false;

    // Chached component refrences
    Rigidbody2D myComponentRigidBody2D;
    AudioSource myComponentAudioSource;
    LevelManager levelManager;

    private void Start()
    {
        myComponentRigidBody2D = GetComponent<Rigidbody2D>();
        myComponentAudioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        LaunchOnMouseClick();
        ResetBallPosition();
        if (levelManager.GetTotalNumberOfBlocks().Equals(0))
        {
            gameStarted = false;
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            myComponentRigidBody2D.velocity = new Vector2(Random.Range(pushX * -1, pushX), pushY);
            gameStarted = true;
        }
    }

    private void ResetBallPosition()
    {
        if(Input.GetMouseButtonDown(1) || !gameStarted)
        {
            Vector2 paddlePosition = paddle.transform.position;
            Vector2 ballPosition = new Vector2(paddlePosition.x, paddlePosition.y + ballPositionOffsetY);
            transform.position = ballPosition;
            gameStarted = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TweakVelocity();
        PlayBallCollisionSound(collision);
    }

    private void TweakVelocity()
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        myComponentRigidBody2D.velocity += velocityTweak;
    }

    private void PlayBallCollisionSound(Collision2D collision)
    {
        if (gameStarted && (collision.collider.gameObject != paddle))
        {
            AudioClip audioClip = ballSounds[Random.Range(0, ballSounds.Length)];
            myComponentAudioSource.PlayOneShot(audioClip);
        }
    }
}
