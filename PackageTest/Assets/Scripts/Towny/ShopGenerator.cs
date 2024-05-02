using UnityEngine;

public class ShopGenerator : MonoBehaviour
{
    private Transform _shopContent;

    [SerializeField] private StoreAssortment _storeAssortment;
    [SerializeField] private GameObject _slot;
    void Start()
    {
        _shopContent = gameObject.transform;
        Generator();
    }
    private void Generator()
    {
        for (int i = 0; i < _storeAssortment.ItemShopCountInShop;i++) 
        {
            _storeAssortment.ShopSlots.Add(Instantiate(_slot, _shopContent).GetComponent<ShopSlot>());
        }
        _storeAssortment.UpdatingTheStore();
    }
}
