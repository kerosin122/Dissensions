using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsInventory
{
    public class InventorySlot : MonoBehaviour
    {
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public bool IsEmpty
        {
            get { return _isEmpty; }
            set { _isEmpty = value; }
        }

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

        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        [SerializeField] int _amount;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _itemAmountText;
        [SerializeField] ItemScriptableObject _item;
        [SerializeField] private bool _isEmpty = true;

        private void Awake()
        {
            _icon = transform.GetChild(0).GetChild(0).GetComponent<Image>();
            _itemAmountText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        public void SetIcon(Sprite icon)
        {
            _icon.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            _icon.sprite = icon;
        }
    }
}