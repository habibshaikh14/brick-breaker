using System;
using UnityEngine;

public class Block : MonoBehaviour {
    private readonly string BREAKABLE = "Breakable";

    // Configuration parameters
    [SerializeField] AudioClip breakSoundClip;
    [SerializeField] GameObject blockDestroyredVFX;
    [SerializeField] Sprite[] damageSprites;
    [SerializeField] int pointsPerBlock = 15;


    // State Variables
    private int timesHit = 0;

    // Cached references
    LevelManager levelManager;
    GameStatus gameStatus;

    private void Start()
    {
        InitaializeVariables();
        CountBreakableBlocks();
    }

    private void InitaializeVariables()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        if (tag.Equals(BREAKABLE))
        {
            levelManager.IncrementBlockCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag.Equals(BREAKABLE))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit.Equals(damageSprites.Length + 1))
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        if (damageSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = damageSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite not attached to block: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroyedSound();
        Destroy(gameObject);
        TriggerBlockDestroyedVFX();
        ChangeGameVariables();
    }

    private void PlayBlockDestroyedSound()
    {
        AudioSource.PlayClipAtPoint(breakSoundClip, GameObject.Find("Game Camera").transform.position);
    }

    private void ChangeGameVariables()
    {
        levelManager.DecrementBlockCount();
        gameStatus.AddToScore(pointsPerBlock);
    }

    private void TriggerBlockDestroyedVFX()
    {
        GameObject sparkles = Instantiate(blockDestroyredVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
