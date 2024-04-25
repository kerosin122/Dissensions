using UnityEngine;

[System.Serializable]
public abstract class Stats : MonoBehaviour
{
    [Header("Main characteristics")]
    [SerializeField] protected Strenght _strenght;          // ����
    [SerializeField] protected Dexterity _dexterity;        // ��������
    [SerializeField] protected Durability _durability;      // ������������
    [SerializeField] protected Intelligence _intelligence;  // ���������
    [SerializeField] protected Speed _speed;                // ��������
    [SerializeField] protected Agility _agility;            // ����������
    [SerializeField] protected Accuracy _accuracy;          // ��������
    [SerializeField] protected Evasion _evasion;            // ���������
    [SerializeField] protected Initiative _initiative;      // ����������
    [Header("Secondary characteristics")]
    [SerializeField] protected float _health;               // ��������
    [SerializeField] protected float _damage;               // ����
    [SerializeField] protected Mana _mana;                  // ����
    [SerializeField] protected float _magicEffectiveness;   //������������� �����

    #region Getters and setters
    public Strenght Strenght { get { return _strenght; } set { _strenght = value; } }
    public Dexterity Dexterity { get { return _dexterity; } set { _dexterity = value; } }
    public Durability Durability { get { return _durability; } set { _durability = value; } }
    public Intelligence Intelligence { get { return _intelligence; } set { _intelligence = value; } }
    public Speed Speed { get { return _speed; } set { _speed = value; } }
    public Agility Agility { get { return _agility; } set { _agility = value; } }
    public Accuracy Accuracy { get { return _accuracy; } set { _accuracy = value; } }
    public Evasion Evasion { get { return _evasion; } set { _evasion = value; } }
    public Initiative Initiative { get { return _initiative; } set { _initiative = value; } }
    public float Health { get { return _health; } set { _health = value; } }
    public float Damage { get { return _damage; } set { _damage = value; } }
    public Mana Mana { get { return _mana; } set { _mana = value; } }
    public float MagicEffectiveness { get { return _magicEffectiveness; } set { _magicEffectiveness = value; } }
    #endregion

    public virtual void AddStrenghtPoint(int count)
    {
        Strenght._strenght += count;
        Health += Strenght._healthScale * count;
        Damage += Strenght._damageScale * count;
    }
    public virtual void AddDexterityPoint(int count)
    {
        Dexterity._dexterity += count;
        Damage += Dexterity._damageScale * count;
        Evasion._evasion += Dexterity._evasionScale * count;
    }
    public virtual void AddDurabilityPoint(int count)
    {
        Durability._durability += count;
        Health += Durability._healthScale * count;
        Accuracy._accuracy += Durability._accuraceScale * count;
    }
    public virtual void AddIntelligencePoint(int count)
    {
        Intelligence._intelligence += count;
        Mana._mana += Intelligence._manaScale * count;
        MagicEffectiveness += Intelligence._magicEffectivenessScale * count;
    }
    public virtual void AddSpeedPoint(int count)
    {
        Speed._speed += count;
        Evasion._evasion += Speed._evasionScale * count;
        Initiative._initiative += Speed._initiativeScale * count;
    }
    public virtual void AddAgilityPoiny(int count)
    {
        Agility._agility += count;
        Accuracy._accuracy += Agility._accuracyScale * count;
        Initiative._initiative += Agility._initiativeScale * count;
    }
}
