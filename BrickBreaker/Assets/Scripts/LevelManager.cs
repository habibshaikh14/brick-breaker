using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // State variables
    private int totalNumberOfBlocks = 0;

    // Cached references
    SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public int GetTotalNumberOfBlocks() {
        return totalNumberOfBlocks;
    }
    public void IncrementBlockCount() {
        totalNumberOfBlocks++;
    }

    public void DecrementBlockCount() {
        totalNumberOfBlocks--;
        if (totalNumberOfBlocks == 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
