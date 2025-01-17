using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

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
    
    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = $"high : {highScore}";
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
