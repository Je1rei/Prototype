using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour, ServiceLocator.IService
{
    public event Action<int> OnCoinCollected;

    public void RegisterCoin(Coin coin)
    {
        coin.OnCollected += (value) => {
            OnCoinCollected?.Invoke(value);
        };
    }
}