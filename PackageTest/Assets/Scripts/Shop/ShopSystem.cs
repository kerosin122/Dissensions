using System.Collections.Generic;
using ShopSystem.Item;
using UnityEngine;

namespace ShopSystem
{
    [System.Serializable]
    public abstract class ShopSystem : MonoBehaviour
    {
        [SerializeField] protected int _valletCount;
        [SerializeField] protected List<ShopItem> _items = new List<ShopItem>();
        public virtual void Buy(ShopItem item) { }
        public virtual void Sell(ShopItem item) { }
        public virtual void UpdateItems(List<ShopItem> items) { }
    }

}