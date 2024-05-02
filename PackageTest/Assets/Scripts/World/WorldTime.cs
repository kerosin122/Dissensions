using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public class WorldTime : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private bool _worldTimerActive = true;

    [SerializeField] private int _hours;
    [SerializeField] private int _minets;
    [SerializeField] private float _timeScaleToRealTime = 1f;

    private void Start()
    {
        
    }

    private IEnumerator WorldTimer()
    {
        while (_worldTimerActive)
        {
            yield return new WaitForSeconds(_timeScaleToRealTime);
            _minets += 1;
            if (_minets >= 60)
            {
                _hours += 1;
                _minets = 0;
                if(_hours >= 24)
                {
                    _hours = 0;
                }
            }
        }
    }
}
