using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 80;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] public int currentScore = 0;

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

    public void DestroyScore()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    //call every frame
    void Update()
    {
        Time.timeScale = gameSpeed; 
    }

    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public bool IsAutoplayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
