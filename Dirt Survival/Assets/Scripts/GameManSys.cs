using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManSys : MonoBehaviour
{
    public GameObject gameOverUI;
    private bool playClicked = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disables your cursor at the start of the game
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Disables the cursor if the game is running
        if (playClicked && !gameOverUI.activeInHierarchy) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //re-enables your cursor during the gameOverUI screen
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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

        //Makes sure mouse is re-locked
        gameOverUI.SetActive(false);
        playClicked = true;
    }

    // Directs player to the MainMenu Scene
    public void mainMenu()
    {
        Debug.Log("Loaded MainMenu");
        SceneManager.LoadScene("MainMenu");
        playClicked = false;
        gameOverUI.SetActive(false);
    }

    // Closes the application
    // This doesn't work in the unity editor as it only works when the game is an exe file
    public void exit()
    {
        Debug.Log("Successfully Quit the game.");
        Application.Quit();
    }

    //Loads the game scene
    public void play()
    {
        Debug.Log("Successfully Started the game.");
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        playClicked = true;
    }

    public void controls()
    {
        Debug.Log("Successfully entered the Control Scene");
        SceneManager.LoadScene("Controls");
    }

}
