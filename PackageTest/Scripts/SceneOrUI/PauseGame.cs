using ScriptsUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AnimationPanels _animationPanels;

    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isPaused)
            {
                _animationPanels.OpenPanel();
                _isPaused = true;
            }

            else
            {
                _animationPanels.HidePanel();
                _isPaused = false;
            }
        }

        IsExitGame();
    }

    private void IsExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}