using TMPro;
using UnityEngine;

namespace ShopSystem
{
    [System.Serializable]
    public abstract class ShopSlot : MonoBehaviour
    {
        [Header("Button components")]
        [SerializeField] protected TextMeshProUGUI _itemTitle;
        [SerializeField] protected TextMeshProUGUI _priceText;
        [Header("Items components")]
        [SerializeField] protected int _price;
        public abstract void Purchase();
    }
}