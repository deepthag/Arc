using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
    private float powerupSpeed;

    public void SetSpeed(float newSpeed)
    {
        powerupSpeed = newSpeed;
    }

    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            transform.position += Vector3.down * powerupSpeed * Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}