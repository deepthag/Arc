using UnityEngine;
using TMPro;
public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Utilities.GameplayState State;
    [SerializeField] private TextMeshProUGUI _pauseMessage;
    
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
        State = Utilities.GameplayState.Play;
        _pauseMessage.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            State = State == Utilities.GameplayState.Play 
                ? Utilities.GameplayState.Pause 
                : Utilities.GameplayState.Play;
            
            _pauseMessage.enabled = !_pauseMessage.enabled; // switch on to off
        }
    }
}
