using UnityEngine;
using System.Collections.Generic;

namespace ScriptsInventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private Transform _inventoryTransform;
        [SerializeField] private List<InventorySlot> _slots = new List<InventorySlot>();

        private bool _isOpenPanel;

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
                _isOpenPanel = !_isOpenPanel;

                if (_isOpenPanel)
                    _inventoryPanel.SetActive(true);

                else
                    _inventoryPanel.SetActive(false);
            }
        }

        public void ClosePanelButton() => _inventoryPanel.SetActive(false);
    }
}