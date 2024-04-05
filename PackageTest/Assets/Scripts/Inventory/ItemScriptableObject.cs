using UnityEngine;

namespace ScriptsInventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "InventoryItem/Items", order = 51)]
    public class ItemScriptableObject : ScriptableObject
    {
        public string NameItem => _nameItem;
        public int MaximumAmount => _maximumAmount;
        public string DescriptionItem => _descriptionItem;
        public ItemType Type => _itemType;
        public GameObject PrefabItem => _prefabItem;
        public Sprite Icon => _icon;

        [SerializeField] private string _nameItem;
        [SerializeField, Range(1, 10)] private int _maximumAmount;
        [SerializeField] private string _descriptionItem;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private GameObject _prefabItem;
        [SerializeField] private Sprite _icon;
    }
}