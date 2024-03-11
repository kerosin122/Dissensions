using UnityEngine;
using System.Collections.Generic;

public class FightSystems : MonoBehaviour
{
    [SerializeField] private List<GameObject> _heroes;
    [SerializeField] private PlayerRPG _enCollisionDetector;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private CharacterStater _characterStater;
    [SerializeField] private GameObject _currentCharacter;
    [SerializeField] private int _turn = 0;

    private void Start()
    {
        _heroes = new List<GameObject>
        {
            gameObject
        };

        GameObject[] heroObjs = GameObject.FindGameObjectsWithTag("Hero");

        foreach (GameObject hero in heroObjs)
            _heroes.Add(hero);

        _enemies = new List<GameObject>();

        GameObject[] enemyObjs = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemyObjs)
            _enemies.Add(enemy);
    }

    private void Update()
    {
        if (_currentCharacter.GetComponent<CharacterStater>().Manevres <= 0)
            _turn = 1;

        if (_heroes.Count == 0 && _enemies.Count == 0)
            GameOver();

        foreach (GameObject target in _enemies)
        {
            if (target.GetComponent<CharacterStater>().currentHealth <= 0)
                _enemies.Remove(target);
        }

        foreach (GameObject target in _heroes)
        {
            if (target.GetComponent<CharacterStater>().currentHealth <= 0)
                _heroes.Remove(target);
        }

        GameObject characterWithHighestInitiative = null;
        float highestInitiative = float.MinValue;

        if (_heroes.Count > 0)
        {
            characterWithHighestInitiative = _heroes[0];
            highestInitiative = _heroes[0].GetComponent<CharacterStater>().Initiative;
        }

        if (_enemies.Count > 0 && highestInitiative < _enemies[0].GetComponent<CharacterStater>().Initiative)
        {
            _currentCharacter = characterWithHighestInitiative;
            highestInitiative = _enemies[0].GetComponent<CharacterStater>().Initiative;
        }

        if (characterWithHighestInitiative != null)
        {
            _currentCharacter = characterWithHighestInitiative;

            if (_currentCharacter.GetComponent<CharacterStater>().currentHealth > 0)
            {
                if (_currentCharacter.GetComponent<CharacterStater>().Manevres > 0)
                {
                    if (_currentCharacter.GetComponent<CharacterStater>().CharacterTeam == CharacterTeams.Team1)
                    {
                        _turn = 0;
                    }

                    else
                    {
                        _turn = 1;
                    }
                }

                else
                {
                    _turn = 1;
                }
            }
            else
            {
                if (_currentCharacter.GetComponent<CharacterStater>().CharacterTeam == CharacterTeams.Team1)
                {
                    _heroes.Remove(_currentCharacter);
                }

                else
                {
                    _enemies.Remove(_currentCharacter);
                }
            }
        }

        if (_turn == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject target = GetClosestCharacter(mousePos, _heroes);

                if (target != null && target.GetComponent<CharacterStater>().CharacterTeam != CharacterTeams.Team1)
                {
                    Attack(_currentCharacter, target);
                }
            }

            if (_currentCharacter.GetComponent<CharacterStater>().Manevres <= 0)
            {
                _turn = 1;
            }
        }

        else
        {
            EnemyTurn();
        }

        _turn = (_turn + 1) % 2;
    }

    private void GameOver()
    {
        _enCollisionDetector.Exit();
    }

    private void Attack(GameObject attacker, GameObject target)
    {
        if (attacker.GetComponent<CharacterStater>().CharacterTeam == target.GetComponent<CharacterStater>().CharacterTeam)
        {
            return;
        }

        if (attacker.GetComponent<CharacterStater>().currentHealth <= 0)
        {
            return;
        }

        if (attacker.GetComponent<CharacterStater>().CharacterId == target.GetComponent<CharacterStater>().CharacterId)
        {
            return;
        }

        attacker.GetComponent<CharacterStater>().Manevres -= 1;

        int damage = attacker.GetComponent<CharacterStater>()._attack;

        target.GetComponent<CharacterStater>().TakeDamage(_currentCharacter.GetComponent<CharacterStater>()._damageType, damage);

        if (target.GetComponent<CharacterStater>().CharacterTeam == CharacterTeams.Team2)
        {
            target.GetComponent<CharacterStater>().Manevres -= 1;
        }

        if (attacker.GetComponent<CharacterStater>().Manevres <= 0)
        {
            if (_heroes.Count > 0)
            {
                CharacterStater heroStats = _heroes[0].GetComponent<CharacterStater>();
                float highestInitiative = heroStats.Initiative;
                GameObject characterWithHighestInitiative = _heroes[0];
                for (int i = 1; i < _heroes.Count; i++)
                {
                    CharacterStater stats = _heroes[i].GetComponent<CharacterStater>();
                    if (stats.Initiative > highestInitiative)
                    {
                        highestInitiative = stats.Initiative;
                        characterWithHighestInitiative = _heroes[i];
                    }
                }

                _currentCharacter = characterWithHighestInitiative;
                _turn = 0;
            }

            else if (_enemies.Count > 0)
            {
                {
                    CharacterStater enemyStats = _enemies[0].GetComponent<CharacterStater>();
                    float highestInitiative = enemyStats.Initiative;
                    GameObject characterWithHighestInitiative = _enemies[0];
                    for (int i = 1; i < _enemies.Count; i++)
                    {
                        CharacterStater stats = _enemies[i].GetComponent<CharacterStater>();

                        if (stats.Initiative > highestInitiative)
                        {
                            highestInitiative = stats.Initiative;
                            characterWithHighestInitiative = _enemies[i];
                        }

                        _currentCharacter = characterWithHighestInitiative;
                        _turn = 1;
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

    private void EnemyTurn()
    {
        GameObject enemy = GetRandomEnemy(_enemies);

        GameObject target = GetClosestCharacters(enemy.transform.position, _heroes);

        if (target != null && target.GetComponent<CharacterStater>().CharacterTeam != CharacterTeams.Team2)
            Attack(enemy, target);
    }

    GameObject GetRandomEnemy(List<GameObject> enemies)
    {
        int randomIndex = Random.Range(0, enemies.Count - 1);
        return enemies[randomIndex];
    }

    GameObject GetClosestCharacters(Vector2 position, List<GameObject> characters)
    {
        GameObject closestCharacter = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject character in characters)
        {
            float distance = Vector2.Distance(character.transform.position, position);

            if (distance < closestDistance && character.GetComponent<CharacterStater>().CharacterTeam != CharacterTeams.Team2)
            {
                closestDistance = distance;
                closestCharacter = character;
            }
        }

        return closestCharacter;
    }
}