using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration parameters
    [Range(0.5f,2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 15;
    [SerializeField] TextMeshProUGUI scoreText;

    // State variables
    private int maxScore = 0;
    private int currentScore = 0;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScores() {
        currentScore = 0;
        if (currentScore > maxScore) {
            maxScore = currentScore;
        }
    }

    public int GetMaxScore() {
        return maxScore;
    }
}
