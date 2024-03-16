using UnityEngine;

namespace ScriptsInventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "InventoryItem", order = 51)]
    public class ItemScriptableObject : ScriptableObject
    {
        public string NameItem => _nameItem;
        public int MaximumAmount => _maximumAmount;
        public string DescriptionItem => _descriptionItem;
        public ItemType Type => _itemType;
        public GameObject PrefabItem => _prefabItem;
        public Sprite Icon => _icon;

        [SerializeField] private string _nameItem;
        [SerializeField] private int _maximumAmount;
        [SerializeField] private string _descriptionItem;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private GameObject _prefabItem;
        [SerializeField] private Sprite _icon;
    }
}