using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private int score;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"high : {highScore}";
    }
    
    private void FixedUpdate()
    {
        score++;
        scoreText.text = $"score : {score}";
    }
    
    public void SetHighScore(int value)
    {
        if (value > highScore)
        {
            highScore = value;
            highScoreText.text = $"high : {highScore}";
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
