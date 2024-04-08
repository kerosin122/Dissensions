using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ScriptsInventory;

namespace ScriptsPlayer
{
    [RequireComponent(typeof(Animator))]
    public class SelectionSubjects : MonoBehaviour
    {
        private readonly int AppearancePanel = Animator.StringToHash(nameof(AppearancePanel));
        private readonly int AppearanceAmountItem = Animator.StringToHash(nameof(AppearanceAmountItem));

        [SerializeField] private Animator _animatorInformationProduct;
        [SerializeField] private Animator _animatorAddAmountItem;
        [SerializeField] private Image _iconProduct;
        [SerializeField] private TextMeshProUGUI _hintText;
        [SerializeField] private InventoryPanel _inventoryPanel;

        private void OnCollisionEnter2D(Collision2D collision) => LiftingItem(collision);

        private void LiftingItem(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Weapon item))
            {
                _inventoryPanel.AddItem(collision.gameObject.GetComponent<Weapon>().Item, collision.gameObject.GetComponent<Weapon>().Amount);

                Destroy(collision.gameObject);

                DrawInformationProduct(item);
                _animatorInformationProduct.SetTrigger(AppearancePanel);
                _animatorAddAmountItem.SetTrigger(AppearanceAmountItem);
            }
        }

        private void DrawInformationProduct(Weapon item)
        {
            _iconProduct.sprite = item.Item.Icon;
            _hintText.text = $"You have picked up:   {item.Item.NameItem}";
        }
    }
}