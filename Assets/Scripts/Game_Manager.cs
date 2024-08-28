using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Score_Manager scoreManager; // Reference to Score_Manager
    public TextMeshProUGUI scoreText;  // Reference to TextMeshProUGUI for displaying the score

    int highscore = 0;
    int lastScore = 0;

    void Start()
    {
        scoreManager=FindObjectOfType<Score_Manager>();
        

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        lastScore = PlayerPrefs.GetInt("LastScore", 0);
    }

    void Update()
    {
        Debug.Log(lastScore);
        // Only update the score text if scoreText is assigned
        if (scoreText != null)
        {
            UpdateScoreText();
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Restart_Game()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        // Check if scoreManager is assigned before accessing it
        if (scoreManager != null)
        {
            lastScore = scoreManager.score;
            PlayerPrefs.SetInt("LastScore", lastScore);

            if (lastScore > highscore)
            {
                highscore = lastScore;
                PlayerPrefs.SetInt("Highscore", highscore);
            }

            // Update the score text only if scoreText is assigned
            UpdateScoreText();
            Debug.Log("YOOOOO");
            SceneManager.LoadScene("Restart");
        }
        else
        {
            Debug.LogError("Score_Manager is not assigned.");
        }
    }

    private void UpdateScoreText()
    {
        // Check if scoreText is assigned before updating its text
        if (scoreText != null)
        {

            scoreText.text = "You scored: " + lastScore;
        }
    }
}
