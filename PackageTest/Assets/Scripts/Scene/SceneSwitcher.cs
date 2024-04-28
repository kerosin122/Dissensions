using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptsScene
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void SwitchGame(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

        public void ExitGame() => Application.Quit();
    }
}