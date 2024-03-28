using ScriptsInventory;
using ShopSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShopSystemManager : MonoBehaviour
{
    public static GameShopSystemManager instance;

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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _sortedItems = SearchForItemsByPrice();
        StartCoroutine(UpdateItemTimer());
    }

    public void ToggleShop()
    {
        _shop.SetActive(!_shop.activeSelf);
    }

    private IEnumerator UpdateItemTimer()
    {
        while (_shopManagerActive)
        {
            IssuanceOfNewItems();
            if (_shop.activeSelf && _sortedItems.Count > 0)
            {
                for(int i = 0; i < _shopSlots.Count; i++)
                {
                    _shopSlots[i].SetItem(_randomTakedItems[i]);
                }
                Debug.Log("Предметы обновлены");
                yield return new WaitForSeconds(_shopUpdateTime);
            }
            else
            {
                yield return new WaitForSeconds(_shopUpdateTime);
            }
            yield return null;
        }
    }
    private void IssuanceOfNewItems()
    {
        _randomTakedItems.Clear();
        if (_sortedItems.Count > 0)
        {
            int randomNumber = 0;
            for (int i = 0; i < _shopSlots.Count; i++)
            {
                randomNumber = Random.Range(0, _sortedItems.Count);
                if (_sortedItems[randomNumber] != null)
                {
                    _randomTakedItems.Add(_sortedItems[randomNumber]);
                }
                else
                {
                    i--;
                }
            }
            Debug.Log("Список предметов обновлен");
        }
        else
        {
            Debug.Log("Нет предметов для продажи");
        }
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
