using UnityEngine;
using System.Collections;

public class ArcBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _boostedSpeed = 5f;
    [SerializeField] private float _powerUpDuration = 5f; 
    
    [SerializeField] private float _rotationRadius = 1f;
    private float _currentAngle = -Mathf.PI / 2f;

    public KeyCode RightDirection = KeyCode.RightArrow; 
    public KeyCode LeftDirection = KeyCode.LeftArrow; 
    
    private Vector3 defaultPosition = new Vector3(0f, -3f, 0f); 
    private Quaternion defaultRotation = Quaternion.Euler(0f, 0f, 0f); 
    
    public Vector3 CenterPoint = new Vector3(0f, -3f, 0f);  
    
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalSprite;  
    [SerializeField] private Sprite powerUpSprite; 
    
    private bool isPoweredUp = false;
    
    public Utilities.GameplayState State;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetArc();
    }
    
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            float _currentSpeed = isPoweredUp ? _boostedSpeed : _speed;
            
            if (Input.GetKey(RightDirection))
            {
                _currentAngle -= _currentSpeed * Time.deltaTime;
                UpdatePosition();  
            }
            if (Input.GetKey(LeftDirection))
            {
                _currentAngle += _currentSpeed * Time.deltaTime;
                UpdatePosition(); 
            }
        }

        if (GameBehavior.Instance.State == Utilities.GameplayState.GameOver)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                Debug.Log("Restarting");
                ResetGame();
            }
        }
    }
    
    void ResetArc()
    {
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;
        isPoweredUp = false;
        spriteRenderer.sprite = normalSprite;
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
    
    private void ResetGame()
    {
        ResetArc(); 
        DeleteAllBlocks(); 
        GameBehavior.Instance.State = Utilities.GameplayState.Play;
        GameBehavior.Instance._gameOverMessage.enabled = false;
    }

    private void DeleteAllBlocks()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            if (GameBehavior.Instance != null)
            {
                GameBehavior.Instance.GameOver(); 
            }
        }
        
        if (other.gameObject.CompareTag("PowerUp"))
        {
            StartCoroutine(ActivatePowerUp());
            Destroy(other.gameObject);
        }
    }
    
    private IEnumerator ActivatePowerUp()
    {
        isPoweredUp = true;
        spriteRenderer.sprite = powerUpSprite;
        yield return new WaitForSeconds(_powerUpDuration);
        isPoweredUp = false;
        spriteRenderer.sprite = normalSprite;
    }
}
