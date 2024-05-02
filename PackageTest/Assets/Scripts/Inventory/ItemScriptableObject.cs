using UnityEngine;

namespace ScriptsInventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "InventoryItem/Items", order = 51)]
    public class ItemScriptableObject : ScriptableObject
    {
        public string NameItem => _nameItem;
        public float Cost => _cost;
        public int MaximumAmount => _maximumAmount;
        public string DescriptionItem => _descriptionItem;
        public ItemType Type => _itemType;
        public GameObject PrefabItem => _prefabItem;
        public Sprite Icon => _icon;
        public float ChangeHealth => _changeHealth;
        public bool IsConsumable => _isConsumable;

        [SerializeField] private string _nameItem;
        [SerializeField] private float _cost;
        [SerializeField, Range(1, 10)] private int _maximumAmount;
        [SerializeField] private string _descriptionItem;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private GameObject _prefabItem;
        [SerializeField] private Sprite _icon;

        [Header("FoodFunctions")]
        [SerializeField] private float _changeHealth;
        [SerializeField] private bool _isConsumable;
    }
}   