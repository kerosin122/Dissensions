using UnityEngine;

namespace CharacterStats
{
    public partial class CharacterStater : MonoBehaviour
    {
        public int characterID;
        [Header("Base Stats")]
        public int level = 1;
        public int Hits;
        public int mana;
        public CharacterTeams CharacterTeam;

        public DamageType damageType;
        public bool range;
        public int Attack;
        public int DefenceBlow;

        public int DefenceShot;
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
        public enum DamageType
        {
            Blow,
            Shot,
            Magic,
            Healing
        }

        private void Start()
        {
            currentHealth = Hits + HitsModifier;
            currentAttack = Attack + AttackModifier;
            currentDefenceBlow = DefenceBlow + DefenceBlowModifier;
            characterID = gameObject.GetInstanceID();
            currentDefenceShot = DefenceShot + DefenceShotModifier;
            currentProtectM = ProtectM + ProtectMModifir;
            currentManevres = Manevres + ManevresModifier;
            currentuklon = uklon + uklonModifier;
            currenttochnost = tochnost + tochnostModifier;
            currentregen = regen + regenModifier;
            currentvampiric = vampiric + vampiricModifier;
            currentIniative = Initiative + InitiativeModifier;
            currentMana = mana + manaModifier;



        }

        public void TakeDamage(DamageType damageType, int damage)
        {
            // Calculate the damage taken after defense
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

            // Subtract the damage taken from the current health
            currentHealth -= damageTaken;

            // Check if the character is dead
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(int healAmount)
        {
            // Add the heal amount to the current health
            currentHealth += healAmount;

            // Clamp the current health to the maximum value
            currentHealth = Mathf.Min(currentHealth, Hits + HitsModifier);
        }

        public void Die()
        {

            Debug.Log(gameObject.name + " has died.");
            Destroy(gameObject);
        }



        public void LevelUp()
        {
            // Increase the level
            level++;

            // Give the character some level-up points
            levelUpPoints += 5;

            // Add level-up logic here
            Debug.Log(gameObject.name + " has leveled up to level " + level);

            // Increase base stats based on level
            switch (level)
            {
                case 2:
                    Hits += 5;
                    break;
                case 3:
                    mana += 10;
                    break;
                case 4:
                    Attack += 3;
                    break;
                case 5:
                    DefenceBlow += 3;
                    break;

                case 8:
                    DefenceShot += 3;
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

            // Reset current stats to the new base stats and modifiers
            currentHealth = Hits + HitsModifier;
            currentMana = mana + manaModifier;
            currentAttack = Attack + AttackModifier;
            currentDefenceBlow = DefenceBlow + DefenceBlowModifier;

            currentDefenceShot = DefenceShot + DefenceShotModifier;
            currentProtectM = ProtectM + ProtectMModifir;
            currentIniative = Initiative + InitiativeModifier;
            currentManevres = Manevres + ManevresModifier;
            currentuklon = uklon + uklonModifier;
            currenttochnost = tochnost + tochnostModifier;
            currentregen = regen + regenModifier;
            currentvampiric = vampiric + vampiricModifier;
        }



        public void IncreaseStat(string statName, int amount)
        {
            // Check if the character has enough level-up points
            if (levelUpPoints >= amount)
            {
                // Subtract the cost from the level-up points
                levelUpPoints -= amount;

                // Increase the appropriate stat
                switch (statName)
                {
                    case "Hits":
                        Hits += amount;
                        break;
                    case "Mana":
                        mana += amount;
                        break;
                    case "Attack":
                        Attack += amount;
                        break;
                    case "DefenceBlow":
                        DefenceBlow += amount;
                        break;

                    case "DefenceShot":
                        DefenceShot += amount;
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

                // Update the current stat value
                switch (statName)
                {
                    case "Hits":
                        currentHealth = Hits + HitsModifier;
                        break;
                    case "Mana":
                        currentMana = mana + manaModifier;
                        break;
                    case "AttackBlow":
                        currentAttack = Attack + AttackModifier;
                        break;
                    case "DefenceBlow":
                        currentDefenceBlow = DefenceBlow + DefenceBlowModifier;
                        break;

                    case "DefenceShot":
                        currentDefenceShot = DefenceShot + DefenceShotModifier;
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
            // Обновляет текущие значения характеристик, когда меняются базовые значения в инспекторе
            currentHealth = Hits + HitsModifier;
            currentMana = mana + manaModifier;
            currentAttack = Attack + AttackModifier;
            currentDefenceBlow = DefenceBlow + DefenceBlowModifier;

            currentDefenceShot = DefenceShot + DefenceShotModifier;
            currentProtectM = ProtectM + ProtectMModifir;
            currentIniative = Initiative + InitiativeModifier;
            currentManevres = Manevres + ManevresModifier;
            currentuklon = uklon + uklonModifier;
            currenttochnost = tochnost + tochnostModifier;
            currentregen = regen + regenModifier;
            currentvampiric = vampiric + vampiricModifier;
        }

    }

}

