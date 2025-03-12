using UnityEngine;

public class ArcBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationRadius = 5f;
    private float _currentAngle = -Mathf.PI / 2f;

    public KeyCode RightDirection = KeyCode.RightArrow; 
    public KeyCode LeftDirection = KeyCode.LeftArrow; 
    
    public Vector3 CenterPoint = new Vector3(0f, 0f, 0f);  
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKey(RightDirection))
        {
            _currentAngle -= _speed * Time.deltaTime;  // Increase angle for right rotation
            UpdatePosition();  
        }
        if (Input.GetKey(LeftDirection))
        {
            _currentAngle += _speed * Time.deltaTime;  // Decrease angle for left rotation
            UpdatePosition(); 
        }
    }
    
    private void UpdatePosition()
    {
        // Calculate new x and y positions using trigonometry for circular motion
        float x = CenterPoint.x + Mathf.Cos(_currentAngle) * _rotationRadius; 
        float y = CenterPoint.y + Mathf.Sin(_currentAngle) * _rotationRadius; 
        float z = transform.position.z; // Maintain the original z position

        // Set the new position of the object
        transform.position = new Vector3(x, y, z);
        
        Vector3 directionToCenter = CenterPoint - transform.position; // Vector pointing towards the center
        transform.up = directionToCenter.normalized;
    }
}
