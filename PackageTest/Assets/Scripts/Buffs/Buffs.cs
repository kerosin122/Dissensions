using System.Collections.Generic;
using UnityEngine;
using Prayers;

namespace Buffs
{
    public class Buffs : MonoBehaviour
    {
        public static Buffs Instance;

        [SerializeField] private Stats _stats;

        [SerializeField] private List<Prayer> _prayers = new List<Prayer>();

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            _stats = GetComponent<Stats>();
        }

        public void AddPayer(Prayer prayer)
        {

        }
    }
}
