using UnityEngine;
using TMPro;

public class Score_Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource audioSource;
    public int score = 0;

    int highscore = 0;

    void Start()
    {
        scoreText.text = "SCORE : 0";
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    void Update()
    {
        
        scoreText.text = "SCORE : " + score;
    }

    public void AddToScore(int points)
    {
        score += points;
        
        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
    }

    private void FixedUpdate()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscore = score;
        }
    }
}
