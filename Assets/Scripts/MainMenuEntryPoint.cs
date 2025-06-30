using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuEntryPoint : MonoBehaviour
{
    [Header("Menu References")]
    [SerializeField] private Canvas _menuCanvas;
    [SerializeField] private Button _startButton;

    private ScoreManager _scoreManager;

    private void Awake()
    {
        Compose();
    }

    private void Compose()
    {
        _scoreManager = ServiceLocator.Current.Get<ScoreManager>();
    }
    
    private void Start()
    {
        Debug.Log(_scoreManager.name);
        
        _startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Gameplay");
        });

        Debug.Log("All Main Menu Services loaded!");
    }
}
