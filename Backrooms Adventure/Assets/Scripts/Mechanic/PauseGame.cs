using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private bool pauseGame;
    [SerializeField] private GameObject pauseMenu;
    private int scene = 0;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseGame)
                Resume();

            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
