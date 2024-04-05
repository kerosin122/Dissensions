using ScriptCharacteristics;
using ScriptsInventory;
using ShopSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameShopSystemManager : MonoBehaviour
{
    public static GameShopSystemManager instance;

    [Header("Player")]
    [SerializeField] private PlayerCharacteristics _player;
    [SerializeField] private float _gold;
    [Header("Shop components")]
    [SerializeField] private GameObject _townShop;
    [SerializeField,Tooltip("Вкладка предметов")] private GameObject _itemShop;
    [SerializeField] private List<GameShopSlot> _itemShopSlots;
    [SerializeField, Tooltip("Вкладка найма")] private GameObject _militaryShop;
    [SerializeField] private List<GameShopMilitarySlot> _militaryShopSlots;

    [Header("Items")]
    [SerializeField, Tooltip("Все предметы для магазина")] private List <ItemScriptableObject> _allShopGameItems;
    [SerializeField, Tooltip("Отсортированные предметы по цене")] private List<ItemScriptableObject> _sortedItems;
    [SerializeField,Tooltip("Продающиеся предметы")] private List<ItemScriptableObject> _randomTakedItems;

    [Header("Configuration parameterth Items")]
    [SerializeField] private int _shopUpdateTime;
    [SerializeField] private int _minBuyPrice, _maxBuyPrice;
    [SerializeField] private bool _shopitemsUpdateActive = true;
    
    private bool _firstOpen = true,_shopUpdateOption = true;

    [Header("Military")]
    private List<GameObject> _allShopGameMilitary;

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
    #region Shop toggle methods
    public void ToggleShop() => _townShop.SetActive(!_townShop.activeSelf);
    public void ToggleItemShop()
    {
        _itemShop.SetActive(!_itemShop.activeSelf);
        if (_firstOpen)
        {
            UpdateItems();
            _firstOpen = false;
        }
    }
    public void ToggleMilitaryShop() => _militaryShop.SetActive(!_militaryShop.activeSelf);
    public void OffAllShops()
    {
        _itemShop.SetActive(false);
        _militaryShop.SetActive(false);
    }
    #endregion
    public void GoldUpdate() => _gold = _player.Gold;
    public bool PurchaseItem(ItemScriptableObject item,out bool transactionConfirmation)
    {
        if (item != null)
        {
            if (_gold >= item.Cost)
            {
                _gold -= item.Cost;
                // добавляем в инвентарь
                transactionConfirmation = true;
                GoldUpdate();
            }
            else
            {
                Debug.Log("Недостаточно средств");
                transactionConfirmation = false;
            }
        }
        else
        {
            transactionConfirmation = false;
        }
        return transactionConfirmation;
    }
    public bool PurchaseMilitary(Military solder, out bool transactionConfirmation)
    {
        if (_gold >= solder.Cost)
        {
            _gold -= solder.Cost;
            // добавляем в инвентарь
            transactionConfirmation = true;
        }
        else
        {
            Debug.Log("Недостаточно средств");
            transactionConfirmation = false;
        }
        GoldUpdate();
        return transactionConfirmation;
    }
    #region Items department
    private IEnumerator UpdateItemTimer()
    {
        IssuanceOfNewItems();
        while (_shopitemsUpdateActive)
        {
            yield return new WaitForSeconds(_shopUpdateTime);
            IssuanceOfNewItems();
            _shopUpdateOption = true;
        }
    }
    private void IssuanceOfNewItems()
    {
        _randomTakedItems.Clear();
        if (_sortedItems.Count > 0)
        {
            int randomNumber = 0;
            for (int i = 0; i < _itemShopSlots.Count; i++)
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
    public void UpdateItems()
    {
        if (_shopUpdateOption)
        {
            for (int i = 0; i < _itemShopSlots.Count; i++)
            {
                _itemShopSlots[i].SetItem(_randomTakedItems[i]);
            }
            _shopUpdateOption = false;
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
    #endregion
    #region Military department

    #endregion
}
