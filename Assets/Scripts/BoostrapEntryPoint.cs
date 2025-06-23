using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    
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
}