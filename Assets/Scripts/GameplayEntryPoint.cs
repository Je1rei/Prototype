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
        var collector = ServiceLocator.Current.Get<CoinCollector>();
        var scoreManager = ServiceLocator.Current.Get<ScoreManager>();
        
        scoreManager.Init(_scoreText, collector);
        
        foreach (var coin in _coins)
        {
            collector.RegisterCoin(coin);
        }
        
        Debug.Log("Gameplay initialized!");
    }
}