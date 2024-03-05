using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isPaused)
                IsOpenPanelPause(true);

            else
                IsOpenPanelPause(false);
        }

        IsExitGame();
    }

    private void IsOpenPanelPause(bool isActivePanel)
    {
        Time.timeScale = isActivePanel ? 0f : 1f;
        _isPaused = isActivePanel;
        _pausePanel.SetActive(isActivePanel);
    }

    private void IsExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}