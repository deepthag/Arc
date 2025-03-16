using UnityEngine;
using TMPro; 

public class Player : MonoBehaviour
{
    private int _score = 0;
    
    [SerializeField] private TextMeshProUGUI _scoreUI;
    
    public int Score
    {
        get
        {
            return _score;
        }
        
        set
        {
            _score = value;
            Debug.Log("Score: " + _score);
            _scoreUI.text = _score.ToString();
        }
    }

    private void Start()
    {
        Score = 0; 
    }
}