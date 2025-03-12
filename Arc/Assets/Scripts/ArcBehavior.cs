using UnityEngine;

public class ArcBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationRadius = 1f;
    private float _currentAngle = -Mathf.PI / 2f;

    public KeyCode RightDirection = KeyCode.RightArrow; 
    public KeyCode LeftDirection = KeyCode.LeftArrow; 
    
    public Vector3 CenterPoint = new Vector3(0f, -3f, 0f);  
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKey(RightDirection))
        {
            _currentAngle -= _speed * Time.deltaTime;
            UpdatePosition();  
        }
        if (Input.GetKey(LeftDirection))
        {
            _currentAngle += _speed * Time.deltaTime;
            UpdatePosition(); 
        }
    }
    
    private void UpdatePosition()
    {
        float x = CenterPoint.x + Mathf.Cos(_currentAngle) * _rotationRadius; 
        float y = CenterPoint.y + Mathf.Sin(_currentAngle) * _rotationRadius; 
        float z = transform.position.z; 
        
        transform.position = new Vector3(x, y, z);
        
        Vector3 directionToCenter = CenterPoint - transform.position;
        transform.up = directionToCenter.normalized;
    }
}
