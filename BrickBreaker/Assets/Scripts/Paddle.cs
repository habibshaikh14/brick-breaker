using UnityEngine;

public class Paddle : MonoBehaviour {
    // Configuration Parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] AudioClip bounceSoundClip;

    // Cached references
    LevelManager levelManager;

    // Update is called once per frame
    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Update()
    {
        if (levelManager.GetTotalNumberOfBlocks() != 0) {
            MovePaddle();
        }
    }

    private void MovePaddle() {
        float mousePositonXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(mousePositonXInUnits, minX, maxX);
        transform.position = paddlePosition;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(bounceSoundClip, GameObject.Find("Game Camera").transform.position);
    }
}
