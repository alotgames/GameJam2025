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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name + " Tag: " + other.gameObject.tag);
        //Debug.Log("Player's Weapon Hit (Outside if statement) " + this.name);

        Transform parent = other.transform.root;
        //Checks if weaponHB was hit and if an attack is active
        if (parent.gameObject.CompareTag("Player") && PlayerAttack.instance.getAttkActive())
        {
            //Gets the point script
            PointSys.instance.AddPoints(pointVal);
            //other.GetComponent<PointSys>().AddPoints(pointVal);
            Debug.Log("Player's Weapon Hit" + this.name);
            Destroy(gameObject);
        }
        // if enemy collides with the player, they take damage
        else if(parent.gameObject.CompareTag("Player") && !PlayerAttack.instance.getAttkActive())
        {
            //Makes player take damage
            HealthSys.instance.playerTakesDamage();
            Debug.Log("Player took 1 Heart of Dmg");
            Destroy(gameObject);
        }
    }
}
