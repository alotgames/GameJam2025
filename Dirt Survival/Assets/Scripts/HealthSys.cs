using UnityEngine;

public class HealthSys : MonoBehaviour
{
    public GameManSys gameManager;
    public static HealthSys instance;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    int health;
    private bool isDead = false;

    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3; 
    }

    // Update is called once per frame
    void Update()
    {
        // checks to make sure player isn't dead
        if (!isDead)
        {
            // updates the hearts according to the number of health the player has remaining
            switch (health)
            {
                case 0:

                    heart1.SetActive(false);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    gameManager.gameOver();
                    isDead = true;
                    // essientially freezes the background on death
                    Time.timeScale = 0f;
                    break;

                case 1:
                    heart1.SetActive(true);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    break;

                case 2:
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(false);
                    break;

                case 3:
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    break;
            }
        }
        
    }

    public void playerTakesDamage()
    {
        health -= 1;
    }
}
