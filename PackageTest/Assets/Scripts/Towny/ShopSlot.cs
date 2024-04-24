using ScriptsInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public GameObject _soldOut;

    [SerializeField] private ItemScriptableObject _item;
    [SerializeField] private float _cost;
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemCost;

    public void SetItem(ItemScriptableObject item)
    {
        _item = item;
        _cost = item.Cost;
        _itemImage.sprite = item.Icon;
        _itemName.text = item.NameItem;
        _itemCost.text = _cost.ToString();
    }
    public void SoldOut()
    {
        _soldOut.SetActive(!_soldOut.activeSelf);
    }
    public void Purchase()
    {
        if (_soldOut.activeSelf == false)
        {
            Shop.instantiate.Purchase(_item, out bool answer);

            if (answer)
            {
                SoldOut();
            }
        }
        else
        {
            Debug.Log("Товар продан!");
        }
    }
}
