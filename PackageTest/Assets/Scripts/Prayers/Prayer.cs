using System.Collections;
using UnityEngine;

[System.Serializable]
public abstract class Prayer : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected float FaithCost;
    [SerializeField] protected float GoldCost;
    [SerializeField] protected float CouldDown;

    public string NameG { get => Name; }
    public float FaithCostGS { get => FaithCost; set => FaithCost = value; }
    public float GoldCostGS { get => GoldCost; set => GoldCost = value; }
    public float CouldDownGS { get => CouldDown; set => CouldDown = value; }

    public virtual void GetPrayer() { }
    public virtual IEnumerator PrayerTimer()
    {
        yield return null;
    }
}
