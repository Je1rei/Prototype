using System;
using UnityEngine;
using TMPro;

public class GameplayEntryPoint : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Coin[] _coins;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private ServiceLocator _serviceLocator;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Current;

        Compose();
    }
    
    private void Compose()
    {
        _scoreManager = _serviceLocator.Get<ScoreManager>();
        _scoreManager.Init(_scoreText);
        
        _player.Init();
        
        foreach (var coin in _coins)
        {
            coin.Init();
        }
        
        Debug.Log("Gameplay initialized!");
    }
}