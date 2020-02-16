using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters

    [SerializeField] float widthScreenUnits = 16;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    GameStatus gameStatus;
    Ball ball;

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
    }
    private float GetXPos()
    {
        if (gameStatus.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * widthScreenUnits;
        }
    }
}
