using ScriptsInventory;
using ShopSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShopSystemManager : MonoBehaviour
{
    [Header("Shop components")]
    [SerializeField] private GameObject _shop;
    [SerializeField] private List<GameShopSlot> _shopSlots;

    [Header("Items")]
    [SerializeField, Tooltip("Все предметы для магазина")] private List <ItemScriptableObject> _allShopGameItems;
    [SerializeField, Tooltip("Отсортированные предметы по цене")] private List<ItemScriptableObject> _sortedItems;
    [SerializeField,Tooltip("Продающиеся предметы")] private List<ItemScriptableObject> _randomTakedItems;

    [Header("Configuration parameterth")]
    [SerializeField] private int _shopUpdateTime;
    [SerializeField] private int _minBuyPrice, _maxBuyPrice;
    [SerializeField] private bool _shopManagerActive = true;

    private void Start()
    {
        _sortedItems = SearchForItemsByPrice();
        StartCoroutine(UpdateItemTimer());
    }

    private IEnumerator UpdateItemTimer()
    {
        while (_shopManagerActive)
        {
            IssuanceOfNewItems();
            if (_shop.activeSelf)
            {
                for(int i = 0; i < _shopSlots.Count; i++)
                {
                    _shopSlots[i].SetItem(_randomTakedItems[i]);
                }
                Debug.Log("Предметы обновлены");
                yield return new WaitForSeconds(_shopUpdateTime);
            }
            yield return null;
        }
    }
    private void IssuanceOfNewItems()
    {
        _randomTakedItems.Clear();
        int randomNumber = 0;
        for (int i = 0; i < _shopSlots.Count; i++)
        {
            randomNumber = Random.Range(0, _sortedItems.Count);
            _randomTakedItems.Add(_sortedItems[randomNumber]);
        }
        Debug.Log("Список предметов обновлен");
    }

    private List<ItemScriptableObject> SearchForItemsByPrice()
    {
        List<ItemScriptableObject> result = new List<ItemScriptableObject>();
        foreach (ItemScriptableObject item in _allShopGameItems)
        {
            if (item.Cost >= _minBuyPrice && item.Cost <= _maxBuyPrice)
            {
                result.Add(item);
            }
        }
        return result;
    }
}
