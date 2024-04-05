using UnityEngine;
using System.Collections.Generic;

namespace ScriptsInventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private List<InventorySlot> _slots = new List<InventorySlot>();
        [SerializeField] private Transform _inventoryTransformPanel;

        private bool _isOpenInventoryPanel;

        private void Awake() => _inventoryPanel.SetActive(true);

        private void Start()
        {
            for (int index = 0; index < _inventoryTransformPanel.childCount; index++)
            {
                if (_inventoryTransformPanel.GetChild(index).GetComponent<InventorySlot>() != null)
                    _slots.Add(_inventoryTransformPanel.GetChild(index).GetComponent<InventorySlot>());
            }

            _inventoryPanel.SetActive(false);
        }

        private void Update() => OpenOrClosePanel();

        private void OpenOrClosePanel()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpenInventoryPanel = !_isOpenInventoryPanel;
                _inventoryPanel.SetActive(_isOpenInventoryPanel);
            }
        }

        public void AddItem(ItemScriptableObject item, int amount)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot.Item == item)
                {
                    if (slot.Amount + amount <= item.MaximumAmount)
                    {
                        slot.Amount += amount;
                        slot.ItemAmountText.text = slot.Amount.ToString();
                    }

                    break;
                }
            }

            foreach (InventorySlot slot in _slots)
            {
                if (slot.IsEmpty == true)
                {
                    slot.Item = item;
                    slot.Amount = amount;
                    slot.IsEmpty = false;
                    slot.SetIcon(item.Icon);
                    slot.ItemAmountText.text = amount.ToString();


                    break;
                }
            }
        }
    }
}