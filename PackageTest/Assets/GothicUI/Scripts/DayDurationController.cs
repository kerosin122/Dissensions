using UnityEngine;

namespace ScriptsUI
{
    public class DayDurationController : MonoBehaviour
    {
        [SerializeField] private GameObject _sky;
        [SerializeField] private GameObject _glow;

        [SerializeField, Header("Day Duration in seconds")] private float _duration;

        private void Awake()
        {
            if (_sky == null || _glow == null || _duration <= 0)
                return;

            _sky.GetComponent<Animator>().speed = 1 / _duration;
            _glow.GetComponent<Animator>().speed = 1 / _duration;
        }
    }
}
