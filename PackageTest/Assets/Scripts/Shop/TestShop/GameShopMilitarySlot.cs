using ShopSystem;
using UnityEngine;
using UnityEngine.UI;

public class GameShopMilitarySlot : ShopSlot
{
    [SerializeField] private Military _military; // назначить префаб или заменить на ScriptableObject и назначить;
    [SerializeField] private int _count;
    [SerializeField] private Image _image;
    private bool _transactionConfirmation;
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetMilitary()
    {
        /*
        _military = 
        _price = item.Cost;
        _image.sprite = item.Icon;
        _itemTitle.text = item.NameItem;
        _priceText.text = _price.ToString();
        */
    }
    public void ClearMilitary()
    {
        /*
        _item = null; // затычка, нужно что-то стандартное
        _price = 0;
        _image.sprite = null;
        _itemTitle.text = "Пусто";
        _priceText.text = "";
        */
    }
    public override void Purchase()
    {
        if (_count > 0)
        {
            GameShopSystemManager.instance.PurchaseMilitary(_military,out _transactionConfirmation);
            if(_transactionConfirmation)
            {
                _count -= 1;
                if (_count <= 0) ClearMilitary();
            }
        }
    }
}
