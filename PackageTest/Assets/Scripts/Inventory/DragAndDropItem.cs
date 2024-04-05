using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ScriptsInventory
{
    public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private InventorySlot _inventorySlot;
        [SerializeField] private Transform _player;

        private void Start()
        {
            _player = GetComponent<Transform>();
            _inventorySlot = transform.GetComponentInParent<InventorySlot>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            CheckGameObjectIsEmpty();

            GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            CheckGameObjectIsEmpty();

            ChangeColorAndRecastTarget(false);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            CheckGameObjectIsEmpty();

            ChangeColorAndRecastTarget(true);

            transform.position = _inventorySlot.transform.position;

            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("InventoryPanel"))
            {
                GameObject item = Instantiate(_inventorySlot.Item.PrefabItem, _player.position + Vector3.up + _player.forward, Quaternion.identity);

                item.GetComponent<Weapon>().Amount = _inventorySlot.Amount;

                NullifySlotData();
            }

            else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>() != null)
            {
                ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InventorySlot>());
            }
        }

        private void NullifySlotData()
        {
            _inventorySlot.Item = null;
            _inventorySlot.Amount = 0;
            _inventorySlot.IsEmpty = true;
            _inventorySlot.Icon.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            _inventorySlot.Icon.sprite = null;
            _inventorySlot.ItemAmountText.text = "";
        }

        private void ExchangeSlotData(InventorySlot newSlot)
        {
            ItemScriptableObject item = newSlot.Item;
            int amount = newSlot.Amount;
            bool isEmpty = newSlot.IsEmpty;
            Image icon = newSlot.Icon;
            TextMeshProUGUI amountText = newSlot.ItemAmountText;

            newSlot.Item = _inventorySlot.Item;
            newSlot.Amount = _inventorySlot.Amount;

            if (_inventorySlot.IsEmpty == false)
            {
                newSlot.SetIcon(_inventorySlot.Icon.GetComponent<Image>().sprite);
                newSlot.ItemAmountText.text = _inventorySlot.Amount.ToString();
            }

            else
            {
                newSlot.Icon.color = new Color(0.5f, 0.5f, 0.5f, 1f);
                newSlot.Icon.sprite = null;

                newSlot.ItemAmountText.text = "";
            }

            newSlot.IsEmpty = _inventorySlot.IsEmpty;

            _inventorySlot.Item = item;
            _inventorySlot.Amount = amount;

            if (isEmpty == false)
            {
                _inventorySlot.SetIcon(icon.sprite);
                _inventorySlot.ItemAmountText.text = amount.ToString();
            }

            else
            {
                _inventorySlot.Icon.color = new Color(0.5f, 0.5f, 0.5f, 1f);
                _inventorySlot.Icon.sprite = null;
                _inventorySlot.ItemAmountText.text = "";
            }

            _inventorySlot.IsEmpty = isEmpty;
        }

        private void CheckGameObjectIsEmpty()
        {
            if (_inventorySlot.IsEmpty)
                return;
        }

        private void ChangeColorAndRecastTarget(bool isActive)
        {
            GetComponentInChildren<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
            GetComponentInChildren<Image>().raycastTarget = isActive;

            transform.SetParent(transform.parent.parent);
        }
    }
}