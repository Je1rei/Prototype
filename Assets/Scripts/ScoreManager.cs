using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour, ServiceLocator.IService
{
    private TextMeshProUGUI _coinsText;
    private int _currentCoins;

    public void Init(TextMeshProUGUI coinsText)
    {
        _coinsText = coinsText;
        _currentCoins = 0;
        UpdateUI();
    }
    
    public void AddCoins(int amount)
    {
        _currentCoins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_coinsText != null)
            _coinsText.text = $"Score: {_currentCoins}";
    }

    public void ResetScore()
    {
        _currentCoins = 0;
        UpdateUI();
    }
}