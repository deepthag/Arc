using UnityEngine;
using System.Collections;

public class BlockSpawning : MonoBehaviour
{
    public GameObject blockPrefab;
    public float minWidth = 1.0f;
    public float maxWidth = 5f;
    public float fixedHeight = 0.5f;
    
    [SerializeField] private float spawnInterval = 100f; // Initial time between spawns
    private float minSpawnInterval = 10f; // Minimum time between spawns
    private float decreaseRate = 0.99f;
    
    [SerializeField] private float blockSpeed = .01f;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        
    }
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnRandomBlock();
            timeSinceLastSpawn = 0f; // Reset timer

            // Gradually reduce spawn interval (but never go below the minimum)
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - Time.deltaTime * decreaseRate);
        }
    }
    
    
    public void SpawnRandomBlock()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-4f, 4f), 5f, 0);
        GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        
        float randomWidth = Random.Range(minWidth, maxWidth);
        newBlock.transform.localScale = new Vector3(randomWidth, fixedHeight, 0); 
        
        BlockMovement movementScript = newBlock.AddComponent<BlockMovement>();
        movementScript.SetSpeed(blockSpeed);
    }
}