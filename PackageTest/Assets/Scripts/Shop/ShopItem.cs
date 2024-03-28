using ScriptsInventory;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem.Item
{
    [System.Serializable]
    public class ShopItem
    {
        [SerializeField] private int _cost;
        [SerializeField] private int _itemId;
        [SerializeField] private ItemScriptableObject _item;

        public int Cost => _cost;
        public int ItemID => _itemId;
        public ItemScriptableObject ItemParameters => _item;
    }
}
