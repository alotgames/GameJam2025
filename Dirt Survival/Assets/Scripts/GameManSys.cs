using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManSys : MonoBehaviour
{
    public GameObject gameOverUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disables your cursor at the start of the game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //re-enables your cursor during the gameOverUI screen
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    // Reloads the scene
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    // Directs player to the MainMenu Scene
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Closes the application
    // This doesn't work in the unity editor as it only works when the game is an exe file
    public void exit()
    {
        Debug.Log("Successfully Quit the game.");
        Application.Quit();
    }
}
