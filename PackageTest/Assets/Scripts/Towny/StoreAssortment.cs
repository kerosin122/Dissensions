using ScriptsInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreAssortment : MonoBehaviour
{
    [SerializeField] private List<ItemScriptableObject> _sortedItems = new List<ItemScriptableObject>();
    [SerializeField] private List<ItemScriptableObject> _itemsAssortment = new List<ItemScriptableObject>();

    [Header("Items sorted configuration")]
    [SerializeField] private float _minCost;
    [SerializeField] private float _maxCost;
    [SerializeField] private int _time;
    [SerializeField] private bool _activeUpdateItems = true;
    [Header("The number of items in the store")]
    [SerializeField] private int _itemsCountInShop;
    [Header("Items data base")]
    [SerializeField] private List<ItemScriptableObject> _itemDataBase = new List<ItemScriptableObject>(); // После написания базы предметов подключить сюда
    [Header("Shop item slots")]
    [SerializeField] private List<ShopSlot> _shopSlots;

    public int ItemShopCountInShop { get => _itemsCountInShop; set => _itemsCountInShop = value; }
    public List<ShopSlot> ShopSlots { get => _shopSlots; set => _shopSlots = value; }

    private void Start()
    {
        StartCoroutine(UpdateTheListOfItems());
    }
    private void SortedItems()
    {
        if (_itemDataBase.Count > 0)
        {
            for (int i = 0; i < _itemDataBase.Count - 1; i++)
            {
                if (_itemDataBase[i].Cost >= _minCost && _itemDataBase[i].Cost <= _maxCost)
                {
                    _sortedItems.Add(_itemDataBase[i]);
                }
            }
        }
        else
        {
            Debug.Log("Предметы не загруженны");
        }
    }
    private void UpdatingTheAssortment()
    {
        _itemsAssortment.Clear();
        int number = 0;
        for (int i = 0; i < _itemsCountInShop; i++)
        {
            number = Random.Range(0, _sortedItems.Count - 1);
            _itemsAssortment.Add(_sortedItems[number]);
        }
        Debug.Log("Ассортимент обновлен");
    }
    private IEnumerator UpdateTheListOfItems()
    {
        SortedItems();
        while (_activeUpdateItems) 
        {
            UpdatingTheAssortment();
            yield return new WaitForSecondsRealtime(_time);
        } 
    }
    public void UpdatingTheStore()
    {
        for (int i = 0; i < _itemsCountInShop; i++)
        {
            _shopSlots[i].SetItem(_itemsAssortment[i]);

            if (_shopSlots[i]._soldOut.activeSelf == true)
                _shopSlots[i].SoldOut();
        }
    }
}