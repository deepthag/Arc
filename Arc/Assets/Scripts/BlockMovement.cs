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
        
        if (transform.position.y < -6f) // replace w collision
        {
            Destroy(gameObject);
        }
    }
}

