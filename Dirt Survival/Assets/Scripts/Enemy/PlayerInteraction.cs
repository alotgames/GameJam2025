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
        Debug.Log("Collided with: " + other.gameObject.name + " Tag: " + other.gameObject.tag);
        //Debug.Log("Player's Weapon Hit (Outside if statement) " + this.name);

        //Transform parent = other.transform.root;
        //Checks if weaponHB was hit and if an attack is active
        if (other.gameObject.CompareTag("WeaponHB") && (PlayerAttack.instance.getUpAttkActive() || PlayerAttack.instance.getMidAttkActive() || PlayerAttack.instance.getDownAttkActive()))
        {
            //Gets the point script
            PointSys.instance.AddPoints(pointVal);
            //other.GetComponent<PointSys>().AddPoints(pointVal);
            Debug.Log("Player's Weapon Hit" + this.name);
            //GetComponent<enemy_animation>().OnEnemyDeath();
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name + " Tag: " + collision.gameObject.tag);

        // if enemy collides with the player, they take damage
        if (collision.gameObject.CompareTag("Player"))
        {
            //Makes player take damage
            HealthSys.instance.playerTakesDamage();
            Debug.Log("Player took 1 Heart of Dmg");
            Destroy(gameObject);
        }
    }
}
