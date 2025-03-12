using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private float speed;
    private float _speedMultiplier = 1.1f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Debug.Log("Block Destroyed");
            speed *= _speedMultiplier;
            Debug.Log($"Current Block Speed: {speed}");

        }
    }
    
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}

