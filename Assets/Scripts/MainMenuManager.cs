
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public TextMeshProUGUI highscore;

    public Texture2D cursorTexture; 
    public Vector2 hotSpot = Vector2.zero; 
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        if (GameObject.Find("Highscore") != null)
        {
            Debug.Log("Found");
            highscore = GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>();
            highscore.text = $"Highscore\n{PlayerPrefs.GetInt("Highscore", 0)}";

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


    public void Start_Game()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void highscoreScreen()
    {
        SceneManager.LoadScene("HighscoreScene");
    }
}
