using UnityEngine;

namespace ScriptsInventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;

        private bool _isOpenInventoryPanel;

        private void Awake() => _inventoryPanel.SetActive(true);

        private void Update() => OpenOrClosePanel();

        private void OpenOrClosePanel()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpenInventoryPanel = !_isOpenInventoryPanel;
                _inventoryPanel.SetActive(_isOpenInventoryPanel);
            }
        }
    }
}