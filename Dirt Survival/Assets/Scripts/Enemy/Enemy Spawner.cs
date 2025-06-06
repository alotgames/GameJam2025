using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyDown;
    public Transform spawnPoint;
    private float timer = 0f;
    private float spawnDelay = 2f;
    private float RNG;

    public void SpawnObject()
    {
        if(enemyDown != null)
        {
            // checks if spawnPoint is assigned if not it defaults to 0
            Vector3 position = spawnPoint != null ? spawnPoint.position : Vector3.zero;
            Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

            GameObject newObject = Instantiate(enemyDown, position, rotation);
            Debug.Log("Spawned: enemyDown");
        }
        else
        {
            Debug.LogWarning("enemyDown is not Assigneed");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RNG = Random.Range(-3f, 1f);
        timer = spawnDelay;

    }

    // Update is called once per frame
    void Update()
    {
        // spawns a new enemy every 4 seconds
        timer -= Time.deltaTime;
        if (timer <= RNG)
        {
            SpawnObject();
            timer = spawnDelay;
            RNG = Random.Range(-3f, 1f);
        }
    }
}
