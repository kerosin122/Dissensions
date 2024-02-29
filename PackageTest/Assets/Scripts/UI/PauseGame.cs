using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private const float PauseTimeScale = 0f;
    private const float ResumeTimeScale = 1f;

    [SerializeField] private GameObject _pausePanel;

    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isPaused)
                IsOpenPanelPause(PauseTimeScale, true);

            else
                IsOpenPanelPause(ResumeTimeScale, false);
        }

        IsExitGame();
    }

    private void IsOpenPanelPause(float stopTime, bool isActivePanel)
    {
        Time.timeScale = stopTime;
        _isPaused = isActivePanel;
        _pausePanel.SetActive(isActivePanel);
    }

    private void IsExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}