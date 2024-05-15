using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using static Assets.Scripts.UI.StartMenu;

namespace ScriptsScene
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Image _loadBarImage;
        [SerializeField] private TextMeshProUGUI _loadBarText;
        [SerializeField] private GameObject _backgroundLoadingScenePanel;

        private AsyncOperation _asyncOperation;

        private const string SCENE_NAME = "GamingScene";

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void LoadingScene(CharacterType type) => StartCoroutine(LoadScene(type));

        private IEnumerator LoadScene(CharacterType type)
        {
            _backgroundLoadingScenePanel.SetActive(true);

            yield return new WaitForSeconds(0.7f);

            _asyncOperation = SceneManager.LoadSceneAsync(SCENE_NAME);

            while (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress / 0.9f;

                _loadBarImage.fillAmount = progress;
                _loadBarText.text = "Loading " + string.Format("{0:0}%", progress * 100f);

                yield return 0;
            }

            CreateWorld createWorld = GameObject.FindObjectOfType<CreateWorld>();

            createWorld.CreateCharacter(type, () =>
            {
                _backgroundLoadingScenePanel.SetActive(false);
            });  
        }

        public void ExitGame() => Application.Quit();
    }
}   