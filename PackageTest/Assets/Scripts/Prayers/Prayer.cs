using UnityEngine;

namespace Prayers
{
    [System.Serializable]
    public abstract class Prayer : ScriptableObject
    {
        [SerializeField] protected int PrayerID;
        [SerializeField] protected Sprite Icon;
        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        [SerializeField] protected float FaithCost;
        [SerializeField] protected float GoldCost;
        [SerializeField] protected TimeMain.Time ActiveTime;

        public int PtayerId { get => PrayerID; }
        public string NameG { get => Name; }
        public string DescriptionG { get => Description; }
        public Sprite IconGS { get => Icon; set => Icon = value; }
        public float FaithCostGS { get => FaithCost; set => FaithCost = value; }
        public float GoldCostGS { get => GoldCost; set => GoldCost = value; }
        public TimeMain.Time ActiveTimeGS { get => ActiveTime; set => ActiveTime = value; }

        public abstract void AddProperties(Stats stats);
        public abstract void RemoveProperties(Stats stats);
    }
}
