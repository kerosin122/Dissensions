using UnityEngine;

[CreateAssetMenu(fileName = "Military", menuName = "MilitaryObject/Military", order = 51)]
public class Military : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField] protected int _cost;

    [SerializeField] protected float _health;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackSpeed;

    [SerializeField] protected GameObject _weapon;
    [SerializeField] protected GameObject _militaryPrefab;

    public string Name => _name;
    public int Cost => _cost;
    public float Health => _health;
    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    public GameObject Weapon => _weapon;
    public GameObject MilitaryPrefab => _militaryPrefab;
}
