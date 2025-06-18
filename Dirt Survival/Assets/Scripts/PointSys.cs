using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSys : MonoBehaviour
{
    public static PointSys instance;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highscoreText;
    public int points = 0;
    public int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    //Start
    private void Start()
    {
        //Gets highscore
        highscore = PlayerPrefs.GetInt("highscore", 0);
        
        pointsText.text = "Points: " + points.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    //Method to add points
    public void AddPoints(int amount)
    {
        points += amount;
        pointsText.text = "Points: " + points.ToString();
        Debug.Log("Added: " + amount + " to player points.");

        //Keeping track of highscore
        if (highscore < points)
        {
            PlayerPrefs.SetInt("highscore", points);
        }
    }
}
