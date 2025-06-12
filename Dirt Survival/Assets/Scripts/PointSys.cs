using UnityEngine;
using TMPro;

public class PointSys : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public int points = 0;

    //Start
    private void Start()
    {
        pointsText.text = "Points: " + points;
    }

    //Method to add points
    public void AddPoints(int amount)
    {
        points += amount;
        pointsText.text = "Points: " + points;
        Debug.Log("Added: " + amount + " to player points.");
    }
}
