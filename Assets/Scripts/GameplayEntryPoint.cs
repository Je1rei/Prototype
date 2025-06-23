using UnityEngine;
using TMPro;

public class GameplayEntryPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Coin[] _coins;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private void Start()
    {
        _player.Init();
        
        foreach (var coin in _coins)
        {
            coin.Init();
        }
        
        _scoreManager.Init();
        Debug.Log("Gameplay initialized!");
    }
}