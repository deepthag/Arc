using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Debug.Log("Block Destroyed");
        }
    }
}

