using UnityEngine;
using UnityEngine.UI;

namespace ScriptsInventory
{
    [RequireComponent(typeof(QuickSlotInventory))]
    [RequireComponent(typeof(ChangeCharacteristics))]
    public class ItemUsed : MonoBehaviour
    {
        [SerializeField] private Transform _quickSlotParent;
        [SerializeField] private InventoryPanel _inventoryPanel;

        private QuickSlotInventory _quickPanel;
        private ChangeCharacteristics _changeCharacteristics;

        private void Start()
        {
            _quickPanel = GetComponent<QuickSlotInventory>();
            _changeCharacteristics = GetComponent<ChangeCharacteristics>();
        }

        private void Update() => Using();

        private void Using()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<InventorySlot>().Item != null)
                {
                    if (_quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<InventorySlot>().Item.IsConsumable && _quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<Image>().sprite == _quickPanel.ActivatedQuickSlot)
                    {
                        _changeCharacteristics.ChangeHealthValue();

                        if (_quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<InventorySlot>().Amount <= 1)
                        {
                            _quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                        }

                        else
                        {
                            _quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<InventorySlot>().Amount--;
                            _quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<InventorySlot>().ItemAmountText.text = _quickSlotParent.GetChild(_quickPanel.CurrentQuickSlotID).GetComponent<InventorySlot>().Amount.ToString();
                        }
                    }
                }
            }
        }
    }
}