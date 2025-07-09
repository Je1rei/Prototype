using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private CoinCollector _coinCollector;

    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        _serviceLocator = new ServiceLocator();
        _scoreManager = new ScoreManager();
        _coinCollector = new CoinCollector();

        RegisterServices();
        DontDestroyOnLoad(gameObject);

        // Переключаемся на сцену следующую
    }

    private IEnumerator Start()
    {
        float loadingDuration = 3f;
        
        while (loadingDuration > 0)
        {
            loadingDuration -= Time.deltaTime;
            Debug.Log("Loading...");
            yield return null;
        }

        Debug.Log("Done!");
        SceneManager.LoadScene(1);
    }

    private void RegisterServices()
    {
        // Регистрация сервисов
        _serviceLocator.Register(_scoreManager);
        _serviceLocator.Register(_coinCollector);
    }
}