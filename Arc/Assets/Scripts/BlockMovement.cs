using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    
    private void OnCollisionEnter2D(Collision2D other) // if using box collider 2D, use 2D notification
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Debug.Log("Block Destroyed");
        }
    }
}

