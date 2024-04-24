using ScriptCharacteristics;
using ScriptsInventory;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instantiate;

    [Header("Dependent objects")]
    [SerializeField] private PlayerCharacteristics _player;
    [SerializeField] private AddingInventory _inventory;
    [SerializeField] private GameObject _store;
    [SerializeField] private GameObject _storeCloseButton;
    
    
    private void Start()
    {
        if (instantiate == null) instantiate = GetComponent<Shop>();
        else Destroy(this);
    }

    public void Purchase(ItemScriptableObject _item,out bool answer)
    {
        if(_player.Gold >= _item.Cost)
        {
            answer = true;
            _player.Gold -= _item.Cost;
            _inventory.AddItem(_item,1);
        }
        else
        {
            answer = false;
            Debug.Log("Недостаточно средств");
        }
    }
    public void UsingTheStore()
    {
        _store.SetActive(!_store.activeSelf);
        _storeCloseButton.SetActive(!_storeCloseButton.activeSelf);
    }
}
