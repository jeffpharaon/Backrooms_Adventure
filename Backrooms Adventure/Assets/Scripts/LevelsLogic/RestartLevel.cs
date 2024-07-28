using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private int scene = 1;
    private bool isStart = false;

    IEnumerator RestartScene(float delay) 
    { 
        yield return new WaitForSeconds(delay); 
        isStart = true;
    }

    private void Update()
    {
        StartCoroutine(RestartScene(6f));
        
        if (isStart) SceneManager.LoadScene(scene);
    }
}
