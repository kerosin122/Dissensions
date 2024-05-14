using System.Collections;
using TMPro;
using UnityEngine;

namespace TimeMain.WorldTime
{
    [System.Serializable]
    public class WorldTime : MonoBehaviour
    {
        public static WorldTime Instance;
        public TextMeshProUGUI timerText;

        private bool _worldTimerActive = true;

        [SerializeField] private Time _time = new Time();
        [SerializeField] private int _day = 0;

        public Time TimeGS { get => _time; set { _time = value; } }
        public int DayG { get => _day; }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = new WorldTime();
            }
            else
            {
                Destroy(this);
            }
            StartCoroutine(WorldTimer());
        }
        private IEnumerator WorldTimer()
        {
            while (_worldTimerActive)
            {
                TimeUpdate();
                yield return new WaitForSeconds(_time.timeScaleToRealTime);
                _time.minets += 1;
                if (_time.minets >= 60)
                {
                    _time.hours += 1;
                    _time.minets = 0;
                    if (_time.hours >= 24)
                    {
                        _time.hours = 0;
                        _day += 1;
                    }
                }
            }
        }
        private void TimeUpdate()
        {
            if (_time.hours < 10 && _time.minets < 10)
            {
                timerText.text = $"0{_time.hours}:0{_time.minets}";
            }
            else if (_time.hours >= 10 && _time.minets < 10)
            {
                timerText.text = $"{_time.hours}:0{_time.minets}";
            }
            else if (_time.hours < 10 && _time.minets >= 10)
            {
                timerText.text = $"0{_time.hours}:{_time.minets}";
            }
            else
            {
                timerText.text = $"{_time.hours}:{_time.minets}";
            }
        }
    }
}