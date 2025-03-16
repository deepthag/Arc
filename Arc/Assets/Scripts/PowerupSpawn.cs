using UnityEngine;
using System.Collections;

public class PowerupSpawning : MonoBehaviour
{
    public GameObject powerupPrefab;
    
    [SerializeField] private float PowerupInterval = 5f; 
    
    [SerializeField] private float powerupSpeed = 5f;
    private float timeSinceLastSpawn;

    private bool _PowerupCoroutine = false;
    private bool _PowerupSpawning = false;
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play && !_PowerupSpawning)
        {
            StartCoroutine(SpawnPowerupCoroutine());
            Debug.Log("Powerup coroutine started");
            _PowerupSpawning = true;
        }
        else if (GameBehavior.Instance.State == Utilities.GameplayState.Pause && _PowerupSpawning)
        {
            StopAllCoroutines();
            Debug.Log("Powerup coroutine stopped");
            _PowerupSpawning = false;
        }
    }

    IEnumerator SpawnPowerupCoroutine()
    {
        _PowerupCoroutine = true; 
        
        yield return new WaitForSeconds(PowerupInterval);

        SpawnPowerup();
            
        _PowerupCoroutine = false;
    }
    
    public void SpawnPowerup()
    {
        Debug.Log("Spawning powerup");
        
        Vector3 spawnPowerupPosition = new Vector3(Random.Range(-1f, 1f), 5f, 0);
        GameObject newPowerup = Instantiate(powerupPrefab, spawnPowerupPosition, Quaternion.identity);
        
        PowerupBehavior movementScript = newPowerup.AddComponent<PowerupBehavior>();
        movementScript.SetSpeed(powerupSpeed);
    }
}