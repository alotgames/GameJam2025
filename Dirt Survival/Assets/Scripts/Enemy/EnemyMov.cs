using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public float movSpeed = 2.5f;
    public float move = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(move, 0f, 0f) * movSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Despawn"))
        {
            Debug.Log("Despawned " + this.gameObject);
            Destroy(gameObject);
        }
    }

}
