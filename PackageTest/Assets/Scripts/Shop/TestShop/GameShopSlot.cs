using ScriptsInventory;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class GameShopSlot : ShopSlot
    {
        [SerializeField] private ItemScriptableObject _item;
        [SerializeField] private int _count;
        private Image _image;
        private bool _transactionConfirmation;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void SetItem(ItemScriptableObject item)
        {
            if (item != null)
            {
                _item = item;
                _price = item.Cost;
                _image.sprite = item.Icon;
                _itemTitle.text = item.NameItem;
                _priceText.text = _price.ToString();
            }
            else
            {

            }
        }
        public void ClearItem()
        {
            _item = null; // затычка, нужно что-то стандартное
            _price = 0;
            _image.sprite = null;
            _itemTitle.text = "Пусто";
            _priceText.text = "";
        }

        public override void Purchase()
        {
            if(_item != null && _count > 0)
            {
                GameShopSystemManager.instance.PurchaseItem(_item,out _transactionConfirmation);
                if (_transactionConfirmation)
                {
                    _count -= 1;
                    if (_count <= 0) ClearItem();
                }
            }
        }
    }
}