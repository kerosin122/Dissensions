using Prayers;
using System.Collections;
using UnityEngine;

namespace TaskSystemMain.Task {
    [System.Serializable]
    public class PrayerTask : Task
    {
        private Prayer _prayer;
        private TimeMain.Time _timer;

        public void Initialization(Prayer prayer,int IdNumber)
        {
            _prayer = prayer;
            _timer = prayer.ActiveTimeGS;
            Id = IdNumber;
        }

        public IEnumerator TaskTimer()
        {
            while (_timer.hours != 0 & _timer.minets != 0)
            {
                if(_timer.hours > 0 && _timer.minets == 0)
                {
                    _timer.hours -= 1;
                    _timer.minets = 60;
                }else if (_timer.hours >= 0 && _timer.minets > 0)
                {
                    _timer.minets -= 1;
                }
                else
                {
                    Debug.Log("Ищи ошибку долбаеб");
                }
                yield return new WaitForSeconds(_timer.timeScaleToRealTime);
                //удаление
            }
        }

        public override void RemoveTask()
        {
            throw new System.NotImplementedException();
        }
    }
}