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
            _panel.SetActive(true);
            StartCoroutine(ActivePanels());
        } 
            
        public void HidePanel() => StartCoroutine(HidePanels());

        private IEnumerator ActivePanels()
        {
            float time = 0f;

            while (time < _animationDuration)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, time / _animationDuration);
                _canvasGroup.alpha = alpha;

                yield return null;
            }
        }

        private IEnumerator HidePanels()
        {
            float time = 0f;

            while (time < _animationDuration)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, time / _animationDuration);
                _canvasGroup.alpha = alpha;

                yield return null;
            }

            _panel.SetActive(false);
        }
    }
}