using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration parameters
    [Range(0f,5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] bool autoPlay;
    [SerializeField] TextMeshProUGUI scoreText;

    // State variables
    private int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int pointsPerBlock)
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScores()
    {
        Destroy(gameObject);
    }

    public bool GetAutoPlay() {
        return autoPlay;
    }
}
