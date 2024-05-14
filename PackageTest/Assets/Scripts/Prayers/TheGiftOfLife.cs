using System.Collections;
using UnityEngine;
using Prayers;

[CreateAssetMenu(fileName = "TheGiftOfLife", menuName = "Prayers/��� �����", order = 1)]
public class TheGiftOfLife : Prayer
{
    [SerializeField] protected float Regeneration = 3;
    [SerializeField] protected float MaxHealthPercent = 30;
    [SerializeField] protected float AddHealth = 0;

    void Awake()
    {
        Description = $"���������� ��������� �� {MaxHealthPercent}% �� ������������� ��������, � ����� ��������� {Regeneration}% � ����������� �������� �� ����� �������� �������.";
    }

    public override void AddProperties(Stats stats)
    {
        stats.HealthGS.health += AddHealth;
        stats.HealthGS.healthRegeneration += Regeneration;
    }

    public override void RemoveProperties(Stats stats)
    {
        stats.HealthGS.health -= AddHealth;
        stats.HealthGS.healthRegeneration -= Regeneration;
    }
}
