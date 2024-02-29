using UnityEngine;

public class EnCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private float _timeScale;

    private void Awake() => _timeScale = Time.timeScale;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Exit()
    {
        _panel.SetActive(false);
        Time.timeScale = _timeScale;
    }
}