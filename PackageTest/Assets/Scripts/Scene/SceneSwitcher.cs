using TMPro;
using ScriptsUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerData;

    public void SwitchGame(int sceneIndex) 
    {
        PlayerData.PlayerName = _playerData;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame() => Application.Quit();
}