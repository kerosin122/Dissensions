using TMPro;
using UnityEngine;

namespace ShopSystem
{
    [System.Serializable]
    public abstract class ShopSlot : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _itemTitle;
        [SerializeField] protected int _price;
        [SerializeField] protected TextMeshProUGUI _priceText;

        public virtual void Purchase()
        {

        }
    }
}