using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        _serviceLocator = new ServiceLocator();

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
        SceneManager.LoadScene("Menu");
    }

    private void RegisterServices()
    {
        // Регистрация сервисов
        _serviceLocator.Register(_scoreManager);
    }
}