using UnityEngine;

public class CharacterStater : MonoBehaviour
{
    [SerializeField] private int _characterID;

    public int CharacterId => _characterID;

    [Header("Standard Stats")]
    [SerializeField] private int level = 1;
    public int _hits;
    public int _mana;

    public CharacterTeams CharacterTeam;

    public DamageType _damageType;
    public bool _range;
    public int _attack;
    public int _defenceBlow;

    public int _defenceShot;
    public int ProtectM;

    public int Initiative;
    public int Manevres;
    public int uklon;
    public int tochnost;
    public int regen;
    public int cost;
    public int vampiric;

    public int levelUpPoints = 0;

    [Header("Current Stats")]
    public int currentHealth;

    public int currentAttack;
    public int currentDefenceBlow;

    public int currentDefenceShot;
    public int currentProtectM;
    public int currentManevres;
    public int currentuklon;
    public int currenttochnost;
    public int currentregen;
    public int currentvampiric;

    public int currentIniative;
    public int currentMana;

    [Header("Modifiers")]

    public int HitsModifier;
    public int manaModifier;

    public int AttackModifier;
    public int DefenceBlowModifier;

    public int DefenceShotModifier;
    public int ProtectMModifir;

    public int InitiativeModifier;
    public int ManevresModifier;
    public int uklonModifier;
    public int tochnostModifier;
    public int regenModifier;
    public int vampiricModifier;

    private void Start()
    {
        currentHealth = _hits + HitsModifier;
        currentAttack = _attack + AttackModifier;
        currentDefenceBlow = _defenceBlow + DefenceBlowModifier;
        _characterID = gameObject.GetInstanceID();
        currentDefenceShot = _defenceShot + DefenceShotModifier;
        currentProtectM = ProtectM + ProtectMModifir;
        currentManevres = Manevres + ManevresModifier;
        currentuklon = uklon + uklonModifier;
        currenttochnost = tochnost + tochnostModifier;
        currentregen = regen + regenModifier;
        currentvampiric = vampiric + vampiricModifier;
        currentIniative = Initiative + InitiativeModifier;
        currentMana = _mana + manaModifier;
    }

    public void TakeDamage(DamageType damageType, int damage)
    {
        int defense = 0;

        switch (damageType)
        {
            case DamageType.Blow:
                defense = currentDefenceBlow;
                break;
            case DamageType.Shot:
                defense = currentDefenceShot;
                break;
            case DamageType.Magic:
                defense = currentProtectM;
                break;
            default:
                defense = currentDefenceBlow;
                break;
            case DamageType.Healing:
                Heal(damage);
                return;
        }

        int damageTaken = Mathf.Max(damage - defense, 0);
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        currentHealth -= damageTaken;

        if (currentHealth <= 0)
            Die();
    }

    private void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, _hits + HitsModifier);
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject);
    }

    public void LevelUp()
    {
        level++;

        levelUpPoints += 5;

        Debug.Log(gameObject.name + " has leveled up to level " + level);

        switch (level)
        {
            case 2:
                _hits += 5;
                break;
            case 3:
                _mana += 10;
                break;
            case 4:
                _attack += 3;
                break;
            case 5:
                _defenceBlow += 3;
                break;

            case 8:
                _defenceShot += 3;
                break;
            case 9:
                ProtectM += 3;
                break;
            case 10:
                Initiative += 3;
                break;
            case 11:
                Manevres += 3;
                break;
            case 12:
                uklon += 3;
                break;
            case 13:
                tochnost += 3;
                break;
            case 14:
                regen += 3;
                break;
            case 15:
                vampiric += 3;
                break;
            default:
                break;
        }

        currentHealth = _hits + HitsModifier;
        currentMana = _mana + manaModifier;
        currentAttack = _attack + AttackModifier;
        currentDefenceBlow = _defenceBlow + DefenceBlowModifier;

        currentDefenceShot = _defenceShot + DefenceShotModifier;
        currentProtectM = ProtectM + ProtectMModifir;
        currentIniative = Initiative + InitiativeModifier;
        currentManevres = Manevres + ManevresModifier;
        currentuklon = uklon + uklonModifier;
        currenttochnost = tochnost + tochnostModifier;
        currentregen = regen + regenModifier;
        currentvampiric = vampiric + vampiricModifier;
    }

    private void IncreaseStat(string statName, int amount)
    {
        if (levelUpPoints >= amount)
        {
            levelUpPoints -= amount;

            switch (statName)
            {
                case "Hits":
                    _hits += amount;
                    break;
                case "Mana":
                    _mana += amount;
                    break;
                case "Attack":
                    _attack += amount;
                    break;
                case "DefenceBlow":
                    _defenceBlow += amount;
                    break;

                case "DefenceShot":
                    _defenceShot += amount;
                    break;
                case "ProtectM":
                    ProtectM += amount;
                    break;
                case "Initiative":
                    Initiative += amount;
                    break;
                case "Manevres":
                    Manevres += amount;
                    break;
                case "Uklon":
                    uklon += amount;
                    break;
                case "Tochnost":
                    tochnost += amount;
                    break;
                case "Regen":
                    regen += amount;
                    break;
                case "Vampiric":
                    vampiric += amount;
                    break;
                default:
                    Debug.LogError("Invalid stat name: " + statName);
                    break;
            }

            switch (statName)
            {
                case "Hits":
                    currentHealth = _hits + HitsModifier;
                    break;
                case "Mana":
                    currentMana = _mana + manaModifier;
                    break;
                case "AttackBlow":
                    currentAttack = _attack + AttackModifier;
                    break;
                case "DefenceBlow":
                    currentDefenceBlow = _defenceBlow + DefenceBlowModifier;
                    break;

                case "DefenceShot":
                    currentDefenceShot = _defenceShot + DefenceShotModifier;
                    break;
                case "ProtectM":
                    currentProtectM = ProtectM + ProtectMModifir;
                    break;
                case "Initiative":
                    currentIniative = Initiative + InitiativeModifier;
                    break;
                case "Manevres":
                    currentManevres = Manevres + ManevresModifier;
                    break;
                case "Uklon":
                    currentuklon = uklon + uklonModifier;
                    break;
                case "Tochnost":
                    currenttochnost = tochnost + tochnostModifier;
                    break;
                case "Regen":
                    currentregen = regen + regenModifier;
                    break;
                case "Vampiric":
                    currentvampiric = vampiric + vampiricModifier;
                    break;
                default:
                    Debug.LogError("Invalid stat name: " + statName);
                    break;
            }
        }

        else
        {
            Debug.LogError("Not enough level-up points to increase stat.");
        }
    }

    private void OnValidate()
    {
        currentHealth = _hits + HitsModifier;
        currentMana = _mana + manaModifier;
        currentAttack = _attack + AttackModifier;
        currentDefenceBlow = _defenceBlow + DefenceBlowModifier;

        currentDefenceShot = _defenceShot + DefenceShotModifier;
        currentProtectM = ProtectM + ProtectMModifir;
        currentIniative = Initiative + InitiativeModifier;
        currentManevres = Manevres + ManevresModifier;
        currentuklon = uklon + uklonModifier;
        currenttochnost = tochnost + tochnostModifier;
        currentregen = regen + regenModifier;
        currentvampiric = vampiric + vampiricModifier;
    }
}