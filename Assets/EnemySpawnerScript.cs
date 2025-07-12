using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;

    public float spawncooldown = 2f;
    public int minSpawn;
    public int maxSpawn;
    float currentSpawnTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime<=0)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x += Random.Range(minSpawn, maxSpawn);
            spawnPosition.z += Random.Range(minSpawn, maxSpawn);
            
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            currentSpawnTime = spawncooldown;
        }
        
    }
}
