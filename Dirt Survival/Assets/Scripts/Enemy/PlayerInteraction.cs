using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int pointVal = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WeaponHB"))
        {
            //Gets the point script
            other.GetComponent<PointSys>().AddPoints(pointVal);
            Debug.Log("Player's Weapon Hit" + this.name);
            Destroy(gameObject);
        }
    }
}
