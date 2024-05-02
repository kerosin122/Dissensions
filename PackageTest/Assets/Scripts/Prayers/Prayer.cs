using UnityEngine;

[System.Serializable]
public abstract class Prayer : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected float ManaCost;
    [SerializeField] protected float GoldCost;
    [SerializeField] protected float CouldDown;

    public string NameG { get => Name; }
    public float ManaCostG { get => ManaCost; set => ManaCost = value; }
    public float GoldCostG { get => GoldCost; set => GoldCost = value; }
    public float CouldDownG { get => CouldDown; set => CouldDown = value; }

    public virtual void GetPrayer() { }
}
