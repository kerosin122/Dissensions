using ScriptsUI;
using UnityEngine;

namespace ScriptsInventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private AnimationPanels _animationPanels;

        private bool _isOpenInventoryPanel = false;

        private void Awake() => _inventoryPanel.SetActive(true);

        private void Update() => OpenOrClosePanel();

        private void OpenOrClosePanel()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_isOpenInventoryPanel)
                {
                    _animationPanels.OpenPanel();
                    _isOpenInventoryPanel = true;
                }

                else
                {
                    _animationPanels.HidePanel();
                    _isOpenInventoryPanel = false;
                }
            }
        }   
    }
}   