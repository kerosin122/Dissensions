using UnityEngine;
using System.Collections.Generic;

namespace ScriptsInventory
{
    public class AddingInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private Transform _inventoryTransformPanel;
        [SerializeField] private List<InventorySlot> _slots = new List<InventorySlot>();

        private void Start()
        {
            for (int index = 0; index < _inventoryTransformPanel.childCount; index++)
            {
                if (_inventoryTransformPanel.GetChild(index).GetComponent<InventorySlot>() != null)
                    _slots.Add(_inventoryTransformPanel.GetChild(index).GetComponent<InventorySlot>());
            }

            _inventoryPanel.SetActive(false);
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

                        return;
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