using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{

    public static bool GameIsPaused = false; //add pause function to this script

    public static bool GameIsOver = false;
    public GameObject gameOverUI;

    public GameObject pauseMenuUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //keycode input for pause menu "Escape"
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() //resume gameplay
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() // pause gameplay
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);  //game Over screen
        Time.timeScale = 0f;  //stops game running in background
        GameIsOver = true;
    }

    public void Restart() //restarting the game
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Debug.Log("reset the scene");
    }

    public void QuitGame() //quit the game
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void Controls() //control mapping of buttons
    {
        Debug.Log("game controls");
    }
}
