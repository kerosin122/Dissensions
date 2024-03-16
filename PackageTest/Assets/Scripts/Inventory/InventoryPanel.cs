using UnityEngine;
using System.Collections.Generic;

namespace ScriptsInventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private List<InventorySlot> _slots;
        [SerializeField] private Transform _inventoryTransform;

        private bool _isOpenInventoryPanel;

        private void Awake() => _inventoryPanel.SetActive(true);

        private void Start()
        {
            for (int index = 0; index < _inventoryTransform.childCount; index++)
            {
                if (_inventoryTransform.GetChild(index).GetComponent<InventorySlot>() != null)
                    _slots.Add(_inventoryTransform.GetChild(index).GetComponent<InventorySlot>());
            }
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
                    slot.Amount += amount;
                    slot.ItemAmountText.text = slot.Amount.ToString();
                    return;
                }
            }

            foreach (InventorySlot slot in _slots)
            {
                if (slot.IsEmpty == false)
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