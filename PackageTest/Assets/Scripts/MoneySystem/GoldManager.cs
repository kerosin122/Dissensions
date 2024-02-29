using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private int _startingGold = 100;
    [SerializeField] private int _currentGold;

    private static GoldManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    private void Start() => _currentGold = _startingGold;

    public void AddGold(int amount) => _currentGold += amount;

    public void SpendGold(int amount)
    {
        if (_currentGold >= amount)
            _currentGold -= amount;

        else
            Debug.Log("Not enough gold to spend!");
    }

    public int GetCurrentGold() => _currentGold;
}