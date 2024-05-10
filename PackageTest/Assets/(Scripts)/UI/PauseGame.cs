using ScriptsUI;
using UnityEngine;

namespace ScriptSettings
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private AnimationPanels _animationPanels;

        private bool _isPaused = false;

        private void Update()
        {
            OpenOrClosePanel();
        }

        private void OpenOrClosePanel()
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
        }
    }
}