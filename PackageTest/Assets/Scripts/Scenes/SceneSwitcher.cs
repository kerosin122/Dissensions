using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;

    public void SwitchGame() => SceneManager.LoadScene(_sceneIndex);
    public void ExitGame()  => Application.Quit();
}