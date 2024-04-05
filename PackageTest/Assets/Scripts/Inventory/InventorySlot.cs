using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsInventory
{
    public class InventorySlot : MonoBehaviour
    {
        public int Amount { get; set; }
        public bool IsEmpty { get; set; }

        public ItemScriptableObject Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public TextMeshProUGUI ItemAmountText
        {
            get { return _itemAmountText; }
            set { _itemAmountText = value; }
        }

        [SerializeField] int _amount;
        [SerializeField] private GameObject _icon;
        [SerializeField] private TextMeshProUGUI _itemAmountText;
        [SerializeField] ItemScriptableObject _item;
        [SerializeField] private bool _isEmpty = true;

        private void Awake()
        {
            _icon = transform.GetChild(0).gameObject;
            _itemAmountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        public void SetIcon(Sprite icon)
        {
            _icon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            _icon.GetComponent<Image>().sprite = icon;
        }
    }
}