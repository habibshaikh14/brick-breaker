using UnityEngine;

public class Block : MonoBehaviour {

    // Configuration parameters
    [SerializeField] AudioClip breakSoundClip;

    // Cached references
    LevelManager levelManager;
    GameStatus gameStatus;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        gameStatus = FindObjectOfType<GameStatus>();
        levelManager.IncrementBlockCount();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSoundClip, GameObject.Find("Game Camera").transform.position);
        Destroy(gameObject);
        levelManager.DecrementBlockCount();
        gameStatus.AddToScore();
    }
}
