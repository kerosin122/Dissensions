
using ShopSystem.Item;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem.Game
{
    public class GameShop : ShopSystem
    {
        [SerializeField] private List<GameObject> _itemsButtons;
        [SerializeField] private List<Image> _buttonsSprites;
        [SerializeField] private List<TextMeshProUGUI> _buttonsTexts;

        private void Start()
        {
            for(int i = 0; i < _itemsButtons.Count; i++)
            {
                _buttonsSprites.Add(_itemsButtons[i].GetComponent<Image>());
                _buttonsTexts.Add(_itemsButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());
            } 
        }
        public override void UpdateItems(List<ShopItem> items)
        {
            _items = items;
            for (int i = 0; i < _items.Count; i++)
            {
                _buttonsSprites[i].sprite = _items[i].ItemParameters.Icon;
                _buttonsTexts[i].text = _items[i].Cost.ToString();
            }
        }
        public override void Buy(ShopItem item)
        {
            if(_valletCount >= item.Cost)
            {
                // Либо сделать привязку валюты напрямую у игрока, либо сделать ее обновление при октрытии магазина
                _valletCount -= item.Cost;
                /*
                 * Логика добавления в инвентарь
                 */
            }
        }
    }
}