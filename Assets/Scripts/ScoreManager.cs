using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour, ServiceLocator.IService
{
    private TextMeshProUGUI _scoreText;
    private int _currentScore;

    public void Init(TextMeshProUGUI scoreText, CoinCollector collector)
    {
        _scoreText = scoreText;
        collector.OnCoinCollected += AddCoins;
    }

    private void AddCoins(int amount)
    {
        _currentScore += amount;
        _scoreText.text = $"Score: {_currentScore}";
    }
}