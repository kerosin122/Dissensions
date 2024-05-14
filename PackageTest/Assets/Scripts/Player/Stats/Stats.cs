using UnityEngine;

[System.Serializable]
public abstract class Stats : MonoBehaviour
{
    [Header("Main characteristics")]
    [SerializeField] protected Strenght Strenght;          // сила
    [SerializeField] protected Dexterity Dexterity;        // ловкость
    [SerializeField] protected Durability Durability;      // выносливость
    [SerializeField] protected Intelligence Intelligence;  // интеллект
    [SerializeField] protected Speed Speed;                // скорость
    [SerializeField] protected Agility Agility;            // проворство
    [SerializeField] protected Accuracy Accuracy;          // точность
    [SerializeField] protected Evasion Evasion;            // уклонение
    [SerializeField] protected Initiative Initiative;      // инициатива
    
    [Header("Secondary characteristics")]
    [SerializeField] protected Health Health;              // здоровье
    [SerializeField] protected float Damage;               // урон
    [SerializeField] protected Mana Mana;                  // мана
    [SerializeField] protected float MagicEffectiveness;   // эффективность магии

    #region Getters and setters
    public Strenght StrenghtGS { get { return Strenght; } set { Strenght = value; } }
    public Dexterity DexterityGS { get { return Dexterity; } set { Dexterity = value; } }
    public Durability DurabilityGS { get { return Durability; } set { Durability = value; } }
    public Intelligence IntelligenceGS { get { return Intelligence; } set { Intelligence = value; } }
    public Speed SpeedGS { get { return Speed; } set { Speed = value; } }
    public Agility AgilityGS { get { return Agility; } set { Agility = value; } }
    public Accuracy AccuracyGS { get { return Accuracy; } set { Accuracy = value; } }
    public Evasion EvasionGS { get { return Evasion; } set { Evasion = value; } }
    public Initiative InitiativeGS { get { return Initiative; } set { Initiative = value; } }
    public Health HealthGS { get { return Health; } set { Health = value; } }
    public float DamageGS { get { return Damage; } set { Damage = value; } }
    public Mana ManaGS { get { return Mana; } set { Mana = value; } }
    public float MagicEffectivenessGS { get { return MagicEffectiveness; } set { MagicEffectiveness = value; } }
    #endregion

    public virtual void AddStrenghtPoint(int count)
    {
        StrenghtGS.strenght += count;
        HealthGS.health += StrenghtGS.healthScale * count;
        DamageGS += StrenghtGS.damageScale * count;
    }

    public virtual void AddDexterityPoint(int count)
    {
        DexterityGS.dexterity += count;
        DamageGS += DexterityGS.damageScale * count;
        EvasionGS.evasion += DexterityGS.evasionScale * count;
    }

    public virtual void AddDurabilityPoint(int count)
    {
        DurabilityGS.durability += count;
        HealthGS.health += DurabilityGS.healthScale * count;
        AccuracyGS.accuracy += DurabilityGS.accuraceScale * count;
    }

    public virtual void AddIntelligencePoint(int count)
    {
        IntelligenceGS.intelligence += count;
        ManaGS.mana += IntelligenceGS.manaScale * count;
        MagicEffectivenessGS += IntelligenceGS.magicEffectivenessScale * count;
    }

    public virtual void AddSpeedPoint(int count)
    {
        SpeedGS.speed += count;
        EvasionGS.evasion += SpeedGS.evasionScale * count;
        InitiativeGS.initiative += SpeedGS.initiativeScale * count;
    }

    public virtual void AddAgilityPoiny(int count)
    {
        AgilityGS.agility += count;
        AccuracyGS.accuracy += AgilityGS.accuracyScale * count;
        InitiativeGS.initiative += AgilityGS.initiativeScale * count;
    }
}