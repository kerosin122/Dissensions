using UnityEngine;
using System.Collections.Generic;

namespace ScriptsInventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private List<InventorySlot> _slots;
        [SerializeField] private Transform _inventoryTransform;

        private bool _isOpen;

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
                _isOpen = !_isOpen;

                _inventoryPanel.SetActive(_isOpen);
            }
        }

        public void CloseInventoryPanelButton() => _inventoryPanel.SetActive(false);
    }
}