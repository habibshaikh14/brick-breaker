using UnityEngine;

public class Ball : MonoBehaviour {
    // Configuratuin parameters
    [SerializeField] float pushX = 2f;
    [SerializeField] float pushY = 20f;
    [SerializeField] float ballPositionOffsetY = 0.5f;
    [SerializeField] GameObject paddle;
    [SerializeField] AudioClip[] ballSounds;

    // State variables
    private bool gameStarted = false;

    // Chached component refrences
    AudioSource myComponentAudioSource;

    // Use this for initialization
    void Start() {
        myComponentAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update() {
        LaunchOnMouseClick();
        ResetBallPosition();
    }

    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0) && !gameStarted) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
            gameStarted = true;
        }
    }

    private void ResetBallPosition() {
        if(Input.GetMouseButtonDown(1) || !gameStarted) {
            Vector2 paddlePosition = paddle.transform.position;
            Vector2 ballPosition = new Vector2(paddlePosition.x, paddlePosition.y + ballPositionOffsetY);
            transform.position = ballPosition;
            gameStarted = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (gameStarted) {
            AudioClip audioClip = ballSounds[Random.Range(0, ballSounds.Length)];
            myComponentAudioSource.PlayOneShot(audioClip);
        }
    }
}
