using ScriptsInventory;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
    public class GameShopSlot : ShopSlot
    {
        [SerializeField] private ItemScriptableObject _item;
        [SerializeField] private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            SetItem(_item);
        }

        public void SetItem(ItemScriptableObject item)
        {
            if(item != null) {
            _item = item;
            _price = item.Cost;
            _image.sprite = item.Icon;
            _itemTitle.text = item.NameItem;
            _priceText.text = _price.ToString();
            }
            else
            {
                _price = 0;
                _itemTitle.text = "Пусто";
                _priceText.text = _price.ToString();
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
            bool acceptOperation = false;
            GameShopSystemManager.instance.PurchaseItem(_item, out acceptOperation);

            if (acceptOperation) ClearItem();
        }
    }
}