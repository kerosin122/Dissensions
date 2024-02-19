using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterStats;
using System.Linq;

public class BattleSystems : MonoBehaviour
{
    public List<GameObject> heroes;
    public EnCollisionDetector EnCollisionDetector;
    public List<GameObject> enemies;
 public CharacterStater CharacterStater;
    public GameObject currentCharacter;
    public int turn = 0;

    void Start()
    {
        heroes = new List<GameObject>();
        heroes.Add(gameObject);

        // Добавление чарактёров игрока в список
        GameObject[] heroObjs = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroObjs)
        {
            heroes.Add(hero);
        }

        enemies = new List<GameObject>();
        GameObject[] enemyObjs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemyObjs)
        {
            enemies.Add(enemy);
        }
    }

    void Update()
    { if (currentCharacter.GetComponent<CharacterStater>().Manevres <= 0)
{
    turn = 1;
}
        // Проверка, есть ли ещё хотя бы один чарактёр
        if (heroes.Count == 0 && enemies.Count == 0)
        {
            GameOver();
        }

        foreach (GameObject target in enemies)
        {
            if (target.GetComponent<CharacterStater>().currentHealth <= 0)
            {
                enemies.Remove(target);
            }
        }

        foreach (GameObject target in heroes)
        {
            if (target.GetComponent<CharacterStater>().currentHealth <= 0)
            {
                heroes.Remove(target);
            }
        }

        // Найдите чарактёра с наибольшей инициативой
       GameObject characterWithHighestInitiative = null;
float highestInitiative = float.MinValue;

if (heroes.Count > 0)
{
    characterWithHighestInitiative = heroes[0];
    highestInitiative = heroes[0].GetComponent<CharacterStater>().Initiative;
}

if (enemies.Count > 0 && highestInitiative < enemies[0].GetComponent<CharacterStater>().Initiative)
{
    currentCharacter = characterWithHighestInitiative;
    highestInitiative = enemies[0].GetComponent<CharacterStater>().Initiative;
}

        if (characterWithHighestInitiative != null)
        {
            currentCharacter = characterWithHighestInitiative;

            if (currentCharacter.GetComponent<CharacterStater>().currentHealth > 0)
            {
                if (currentCharacter.GetComponent<CharacterStater>().Manevres > 0)
                  {
                      if (currentCharacter.GetComponent<CharacterStater>().CharacterTeam == CharacterStater.CharacterTeams.Team1)
                      {
                          turn = 0;
                      }
                      else
                      {
                          turn = 1;
                      }
                  }
                  else
                  {
                      turn = 1;
                  }
            }
            else
            {
                if (currentCharacter.GetComponent<CharacterStater>().CharacterTeam == CharacterStater.CharacterTeams.Team1)
                {
                      heroes.Remove(currentCharacter);
                  }
                else
                  {
                      enemies.Remove(currentCharacter);
                  }
            }
        }

        if (turn == 0)
        {
            // Player's turn
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject target = GetClosestCharacter(mousePos, heroes);
                if (target != null && target.GetComponent<CharacterStater>().CharacterTeam != CharacterStater.CharacterTeams.Team1)
                {
                    Attack(currentCharacter, target);
                }
            }

            // Spend manevres and switch turns if exhausted
            if (currentCharacter.GetComponent<CharacterStater>().Manevres <= 0)
            {
                turn = 1;
            }
        }
        else
        {
            // Enemy's turn
            EnemyTurn();
        }

        turn = (turn + 1) % 2;
    }

    void GameOver()
    {
        EnCollisionDetector.exit();
    }

      void Attack(GameObject attacker, GameObject target)
{
   // Проверка, может ли персонаж атаковать себя или другого персонажа с тем же ID
   if (attacker.GetComponent<CharacterStats.CharacterStater>().CharacterTeam == target.GetComponent<CharacterStats.CharacterStater>().CharacterTeam)
 {
   return;
 }

 if (attacker.GetComponent<CharacterStats.CharacterStater>().currentHealth <= 0)
 {
   return;
 }

 if (attacker.GetComponent<CharacterStats.CharacterStater>().characterID == target.GetComponent<CharacterStats.CharacterStater>().characterID)
 {
   return;
 }

// Уменьшаем маневры у атакующего персонажа
 attacker.GetComponent<CharacterStats.CharacterStater>().Manevres -= 1;

// Вычисляем урон
 int damage = attacker.GetComponent<CharacterStats.CharacterStater>().Attack;

// Наносим урон цели
 target.GetComponent<CharacterStats.CharacterStater>().TakeDamage(currentCharacter.GetComponent<CharacterStats.CharacterStater>().damageType, damage);

// Если цель - враг, уменьшаем ее маневры
 if (target.GetComponent<CharacterStats.CharacterStater>().CharacterTeam == CharacterStats.CharacterStater.CharacterTeams.Team2)
 {
   target.GetComponent<CharacterStats.CharacterStater>().Manevres -= 1;
 }

// Если у текущего персонажа закончились маневры, начинается ход следующего персонажа с наибольшей инициативой
 if (attacker.GetComponent<CharacterStats.CharacterStater>().Manevres <= 0)
 {
   // Если еще остались живые персонажи, начинается ход следующего персонажа с наибольшей инициативой
   if (heroes.Count > 0)
   {
       CharacterStater heroStats = heroes[0].GetComponent<CharacterStater>();
       float highestInitiative = heroStats.Initiative;
       GameObject characterWithHighestInitiative = heroes[0];
       for (int i = 1; i < heroes.Count; i++)
       {
           CharacterStater stats = heroes[i].GetComponent<CharacterStater>();
           if (stats.Initiative > highestInitiative)
           {
               highestInitiative = stats.Initiative;
               characterWithHighestInitiative = heroes[i];
           }
       }

       currentCharacter = characterWithHighestInitiative;
       turn = 0;
   }
   else if (enemies.Count > 0)
  {
   {
       CharacterStater enemyStats = enemies[0].GetComponent<CharacterStater>();
       float highestInitiative = enemyStats.Initiative;
       GameObject characterWithHighestInitiative = enemies[0];
       for (int i = 1; i < enemies.Count; i++)
      {
       {
           CharacterStater stats = enemies[i].GetComponent<CharacterStater>();
           if (stats.Initiative > highestInitiative)
          {
           {
               highestInitiative = stats.Initiative;
               characterWithHighestInitiative = enemies[i];
           }
          }

       currentCharacter = characterWithHighestInitiative;
       turn = 1;
      }
     }
   } 
 }
    }
   }
   

    GameObject GetClosestCharacter(Vector2 position, List<GameObject> characters)
    {
        GameObject closestCharacter = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject character in characters)
        {
            float distance = Vector2.Distance(character.transform.position, position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCharacter = character;
            }
        }

        return closestCharacter;
    }

    void EnemyTurn()
    {
        // Выберите случайного врага из списка персонажей
        GameObject enemy = GetRandomEnemy(enemies);

        // Найдите ближайшего персонажа, которого можно атаковать
        GameObject target = GetClosestCharacters(enemy.transform.position, heroes);

        // Выполните атаку на выбранного персонажа
        if (target != null && target.GetComponent<CharacterStater>().CharacterTeam != CharacterStater.CharacterTeams.Team2)
        {
            Attack(enemy, target);
        }
    }

    GameObject GetRandomEnemy(List<GameObject> enemies)
    {
       int randomIndex = UnityEngine.Random.Range(0, enemies.Count - 1);
       return enemies[randomIndex];
    }

    GameObject GetClosestCharacters(Vector2 position, List<GameObject> characters)
    {
        GameObject closestCharacter = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject character in characters)
        {
            float distance = Vector2.Distance(character.transform.position, position);
            if (distance < closestDistance && character.GetComponent<CharacterStater>().CharacterTeam != CharacterStater.CharacterTeams.Team2)
            {
                closestDistance = distance;
                closestCharacter = character;
            }
        }

        return closestCharacter;
    }
  }
  
  
  












