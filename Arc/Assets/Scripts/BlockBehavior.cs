using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public GameObject blockPrefab;
    public float minWidth = 0.5f;
    public float maxWidth = 3f;
    public float fixedHeight = 0.5f;

    void Update()
    {
        
    }
    
    public void SpawnRandomBlock()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 5f, 0);
        GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
        
        float randomWidth = Random.Range(minWidth, maxWidth);
        
        newBlock.transform.localScale = new Vector3(randomWidth, fixedHeight, 0); 
    }
}