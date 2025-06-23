using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuEntryPoint : MonoBehaviour
{
    [Header("Menu References")]
    [SerializeField] private Canvas _menuCanvas;
    [SerializeField] private Button _startButton;


    private void Start()
    {
        _startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Gameplay");
        });

        Debug.Log("All Main Menu Services loaded!");
    }
}
