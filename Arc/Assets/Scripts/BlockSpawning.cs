using UnityEngine;
using System.Collections;

public class BlockSpawning : MonoBehaviour
{
    public GameObject blockPrefab;
    public float minWidth = 1.0f;
    public float maxWidth = 3f;
    public float fixedHeight = 0.5f;
    
    [SerializeField] private float currentSpawnInterval = 5f; 
    private float minSpawnInterval = 1f; // 
    private float decreaseRate = .95f;
    
    [SerializeField] private float blockSpeed = 5f;
    private float timeSinceLastSpawn;

    private bool _inCoroutine = false;
    private bool _isSpawning = false;
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play && !_isSpawning)
        {
            StartCoroutine(SpawnBlocksCoroutine());
            Debug.Log("Coroutine started");
            _isSpawning = true;
        }
        else if (GameBehavior.Instance.State == Utilities.GameplayState.Pause && _isSpawning)
        {
            StopAllCoroutines();
            Debug.Log("Coroutine stopped");
            _isSpawning = false;
        }
    }

    IEnumerator SpawnBlocksCoroutine()
    {
        _inCoroutine = true; 
        
        yield return new WaitForSeconds(currentSpawnInterval);

        SpawnRandomBlock();

        // Reduce spawn interval over time but keep it above minSpawnInterval
        currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval * decreaseRate);
            
        _inCoroutine = false;
    }
    
    public void SpawnRandomBlock()
    {
        Debug.Log("Spawning random block");
        
        Vector3 spawnPosition = new Vector3(Random.Range(-4f, 4f), 5f, 0);
        GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        
        float randomWidth = Random.Range(minWidth, maxWidth);
        newBlock.transform.localScale = new Vector3(randomWidth, fixedHeight, 1); 
        
        BlockBehavior movementScript = newBlock.AddComponent<BlockBehavior>();
        movementScript.SetSpeed(blockSpeed);
    }
}