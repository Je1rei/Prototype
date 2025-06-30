using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    private int _currentCoins;

    private void Awake()
    {
        ServiceLocator.Register<ScoreManager>(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<ScoreManager>();
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

    public void Init()
    {
        _currentCoins = 0;
        UpdateUI();
    }
}