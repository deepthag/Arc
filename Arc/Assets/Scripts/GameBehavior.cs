using UnityEngine;
using TMPro;
public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Utilities.GameplayState State;
    [SerializeField] private TextMeshProUGUI _pauseMessage;
    [SerializeField] private TextMeshProUGUI _gameOverMessage;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {
        ResetGame();
    }
    
    void Update()
    {
        // PAUSE
        
        if ((Input.GetKeyDown(KeyCode.Space)) && State != Utilities.GameplayState.GameOver)
        {
            State = State == Utilities.GameplayState.Play 
                ? Utilities.GameplayState.Pause 
                : Utilities.GameplayState.Play;
            
            _pauseMessage.enabled = !_pauseMessage.enabled; // switch on to off
        }
    }

    void ResetGame()
    {
        // RESET TO DEFAULT CONDITIONS 
        
        State = Utilities.GameplayState.Play;
        _pauseMessage.enabled = false;
        _gameOverMessage.enabled = false;
    }
    
    public void GameOver()
    {
        State = Utilities.GameplayState.GameOver;
        _gameOverMessage.enabled = true;
        _pauseMessage.enabled = false; // Hide pause message if it's on
        Debug.Log("Game Over!");
    }
}
