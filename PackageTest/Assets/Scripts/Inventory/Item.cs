using UnityEngine;

namespace ScriptsInventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "InventoryItem", order = 51)]
    public class Item : ScriptableObject
    {
        protected string NameItem => _nameItem;
        protected int MaximumAmount => _maximumAmount;
        protected string DescriptionItem => _descriptionItem;
        protected ItemType Type => _itemType;
        protected GameObject PrefabItem => _prefabItem;

        [SerializeField] private string _nameItem;
        [SerializeField] private int _maximumAmount;
        [SerializeField] private string _descriptionItem;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private GameObject _prefabItem;
    }
}