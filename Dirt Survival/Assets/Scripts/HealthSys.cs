using UnityEngine;

public class HealthSys : MonoBehaviour
{
    public static HealthSys instance;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    int health;

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
        switch (health)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
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

    public void playerTakesDamage()
    {
        health -= 1;
    }
}
