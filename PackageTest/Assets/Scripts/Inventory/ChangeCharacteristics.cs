using UnityEngine;
using UnityEngine.UI;

namespace ScriptsInventory
{
    [RequireComponent(typeof(QuickSlotInventory))]
    public class ChangeCharacteristics : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Transform _quickParent;

        private QuickSlotInventory _quickSlot;

        private void Start() => _quickSlot = GetComponent<QuickSlotInventory>();

        public void ChangeHealthValue()
        {
            _slider.value += _quickParent.GetChild(_quickSlot.CurrentQuickSlotID).GetComponent<InventorySlot>().Item.ChangeHealth;
        }
    }
}