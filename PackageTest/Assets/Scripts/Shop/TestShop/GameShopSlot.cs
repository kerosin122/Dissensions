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
        }

        public void SetItem(ItemScriptableObject item)
        {
            _item = item;
            _price = item.Cost;
            _image.sprite = item.Icon;
            _itemTitle.text = item.NameItem;
            _priceText.text = _price.ToString();
        }
        public void ClearItem()
        {
            _item = null; // �������, ����� ���-�� �����������
            _price = 0;
            _image.sprite = null;
            _itemTitle.text = "�����";
            _priceText.text = "";
        }

        public override void Purchase()
        {
            if(_item != null)
            {
                ClearItem();
                Debug.Log("�������");
            }
            else
            {
                Debug.Log("������� ��� ������");
            }
        }
    }
}