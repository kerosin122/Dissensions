using ShopSystem.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem.TaskSystem
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private int _countSaleItems;
        [SerializeField] private int _shopUpdateTime;
        [SerializeField] private bool _shopManagerActive;

        [SerializeField] private GameObject _shopGameObject;
        [SerializeField] private ShopSystem _shopSystem;

        [SerializeField] private List<ShopItem> _allShopItems;
        [SerializeField] private List<ShopItem> _randomItems;
        [SerializeField] private List<ShopItem> _saleItems = new List<ShopItem>();

        private void Start()
        {
            _shopSystem = _shopGameObject.GetComponent<ShopSystem>();
            _randomItems = SearchForItemsByPrice();

            StartCoroutine(UpdateItemTimer());
        }

        private IEnumerator UpdateItemTimer()
        {
            while (_shopManagerActive)
            {
                IssuanceOfNewItems();
                if (_shopGameObject.activeSelf)
                {
                    _shopSystem.UpdateItems(_saleItems);
                    Debug.Log("Предметы обновлены");
                }
                yield return new WaitForSeconds(_shopUpdateTime);
            }
        }

        private void IssuanceOfNewItems()
        {
            _saleItems.Clear();
            int randomNumber = 0;
            for (int i = 0; i < _countSaleItems;i++)
            {
                randomNumber = Random.Range(0, _randomItems.Count);
                _saleItems.Add(_randomItems[randomNumber]);
            }
            Debug.Log("Список предметов обновлен");
        }

        private List<ShopItem> SearchForItemsByPrice()
        {
            List<ShopItem> result = new List<ShopItem>();
            foreach (ShopItem item in _allShopItems) 
            { 
                if(item.Cost >= 100 && item.Cost <= 1000)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
