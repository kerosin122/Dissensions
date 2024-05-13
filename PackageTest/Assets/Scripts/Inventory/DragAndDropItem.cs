using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ScriptsInventory
{
    public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Transform _player;

        private InventorySlot _inventorySlot;

        private void Start() => _inventorySlot = transform.GetComponentInParent<InventorySlot>();

        public void OnDrag(PointerEventData eventData)
        {
            if (_inventorySlot.IsEmpty)
                return;

            GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_inventorySlot.IsEmpty)
                return;

            else
            {
                ChangeColorAndRecastTarget(0.5f, false);
                transform.SetParent(transform.parent.parent.parent);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_inventorySlot.IsEmpty)
                return;

            else
            {
                ChangeColorAndRecastTarget(1f, true);
                transform.SetParent(_inventorySlot.transform);
                transform.position = _inventorySlot.transform.position;
            }

            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("ClearSlotInventory"))
            {
                GameObject item = Instantiate(_inventorySlot.Item.PrefabItem, _player.position + Vector3.down + _player.right, Quaternion.identity);
                item.GetComponent<Weapon>().Amount = _inventorySlot.Amount;

                NullifySlotData();
            }

            else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent == null)
                return;

            else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
                ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
        }

        private void ExchangeSlotData(InventorySlot newSlot)
        {
            ItemScriptableObject item = newSlot.Item;
            int amount = newSlot.Amount;
            bool isEmpty = newSlot.IsEmpty;
            Image icon = newSlot.Icon;

            newSlot.Item = _inventorySlot.Item;
            newSlot.Amount = _inventorySlot.Amount;

            if (_inventorySlot.IsEmpty == false)
            {
                newSlot.SetIcon(_inventorySlot.Icon.sprite);
                newSlot.ItemAmountText.text = _inventorySlot.Amount.ToString();
            }

            else
            {
                newSlot.Icon.color = new Color(0.5f, 0.5f, 0.5f, 0f);
                newSlot.Icon.sprite = null;
                newSlot.ItemAmountText.text = string.Empty;
            }

            newSlot.IsEmpty = _inventorySlot.IsEmpty;

            _inventorySlot.Item = item;
            _inventorySlot.Amount = amount;

            if (isEmpty == false)
            {
                _inventorySlot.SetIcon(item.Icon);
                _inventorySlot.ItemAmountText.text = amount.ToString();
            }

            else
            {
                _inventorySlot.Icon.color = new Color(0.5f, 0.5f, 0.5f, 0f);
                _inventorySlot.Icon.sprite = null;
                _inventorySlot.ItemAmountText.text = string.Empty;
            }

            _inventorySlot.IsEmpty = isEmpty;
        }

        private void ChangeColorAndRecastTarget(float transparency, bool isActive)
        {
            GetComponentInChildren<Image>().color = new Color(0.5f, 0.5f, 0.5f, transparency);
            GetComponentInChildren<Image>().raycastTarget = isActive;
        }

        public void NullifySlotData()
        {
            _inventorySlot.Item = null;
            _inventorySlot.Amount = 0;
            _inventorySlot.IsEmpty = true;
            _inventorySlot.Icon.color = new Color(0.5f, 0.5f, 0.5f, 0f);
            _inventorySlot.Icon.sprite = null;
            _inventorySlot.ItemAmountText.text = string.Empty;
        }
    }
}