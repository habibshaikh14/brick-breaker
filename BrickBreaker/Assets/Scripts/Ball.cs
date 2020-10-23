using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuratuin parameters
    [SerializeField] float pushX = 2f;
    [SerializeField] float pushY = 20f;
    [SerializeField] float ballPositionOffsetY = 0.5f;
    [SerializeField] GameObject paddle;
    private bool ballInAir = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaunchOnMouseClick();
        ResetBallPosition();
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !ballInAir)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
            ballInAir = true;
        }
    }

    private void ResetBallPosition()
    {
        if(Input.GetMouseButtonDown(1) || !ballInAir)
        {
            Vector2 paddlePosition = paddle.transform.position;
            Vector2 ballPosition = new Vector2(paddlePosition.x, paddlePosition.y + ballPositionOffsetY);
            transform.position = ballPosition;
            ballInAir = false;
        }
    }
}
