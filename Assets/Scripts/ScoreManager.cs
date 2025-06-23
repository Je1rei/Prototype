using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _coinsText;
    private int _currentCoins;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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