using UnityEngine;
using System.Collections;

namespace ScriptsUI
{
    public class AnimationPanels : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 0.5f)] private float _animationDuration;
        [SerializeField] private GameObject _panel;
        [SerializeField] private CanvasGroup _canvasGroup;

        public void OpenPanel()
        {
            CheckingForNull();
            
            _panel.SetActive(true);
            StartCoroutine(AnimatePanel(true));
        }

        public void HidePanel()
        {
            CheckingForNull();
            StartCoroutine(AnimatePanel(false));
        }

        private IEnumerator AnimatePanel(bool isOpening)
        {
            float startAlpha = isOpening ? 0f : 1f;
            float endAlpha = isOpening ? 1f : 0f;

            float time = 0f;

            while (time < _animationDuration)
            {
                time += Time.deltaTime;

                float alpha = Mathf.Lerp(startAlpha, endAlpha, time / _animationDuration);
                _canvasGroup.alpha = alpha;

                yield return null;
            }

            _canvasGroup.alpha = endAlpha;

            if (!isOpening)
                _panel.SetActive(false);
        }

        private void CheckingForNull()
        {
            if (_canvasGroup == null || _panel == null)
            {
                Debug.LogWarning("CanvasGroup or panel is not assigned.");
                return;
            }
        }
    }
}