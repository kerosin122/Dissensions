using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsInventory
{
    public class InventorySlot : MonoBehaviour
    {
        public int Amount { get; set; }
        public ItemScriptableObject Item { get; set; }
        public bool IsEmpty { get; set; }
        public TextMeshProUGUI ItemAmountText { get; set; }

        [SerializeField] int _amount;
        [SerializeField] ItemScriptableObject _item;
        [SerializeField] private bool _isEmpty = true;
        [SerializeField] private GameObject _icon;
        [SerializeField] private TextMeshProUGUI _itemAmountText;

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