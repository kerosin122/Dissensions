using TMPro;
using ScriptsUI;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ScriptsScene
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private Image _loadBarImage;
        [SerializeField] private TextMeshProUGUI _loadBarText;

        [SerializeField] private int _sceneID;

        private AsyncOperation _asyncOperation;

        public void LoadingScene() => StartCoroutine(LoadScene());

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(0.7f);

            _asyncOperation = SceneManager.LoadSceneAsync(_sceneID);

            while (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress / 0.9f;

                _loadBarImage.fillAmount = progress;
                _loadBarText.text = "Loading " + string.Format("{0:0}%", progress * 100f);

                yield return 0;
            }
        }

        public void ExitGame() => Application.Quit();
    }
}   