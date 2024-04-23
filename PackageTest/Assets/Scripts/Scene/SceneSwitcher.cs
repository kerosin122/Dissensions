using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchGame(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

    public void ExitGame()  => Application.Quit();
}