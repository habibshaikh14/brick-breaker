using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour {

    // Cached references
    GameStatus gameStatus;

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
    }
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene() {
        SceneManager.LoadScene(0);
        gameStatus.ResetScores();
        Debug.Log("Max score: " + gameStatus.GetMaxScore());
    }
    public void QuitTheGame() => Application.Quit();
}
