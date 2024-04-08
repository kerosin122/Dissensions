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

        [SerializeField] private Animator _animator;
        [SerializeField] private Image _iconProduct;
        [SerializeField] private TextMeshProUGUI _hintText;
        [SerializeField] private InventoryPanel _inventoryPanel;

        private void OnCollisionEnter2D(Collision2D collision) => Lifting(collision);

        private void Lifting(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Weapon item))
            {
                _inventoryPanel.AddItem(collision.gameObject.GetComponent<Weapon>().Item, collision.gameObject.GetComponent<Weapon>().Amount);
                Destroy(collision.gameObject);

                DrawInformationProduct(item);

                _animator.SetTrigger(AppearancePanel);
            }
        }

        private void DrawInformationProduct(Weapon item)
        {
            _hintText.text = $"You have picked up:   {item.Item.NameItem}";
            _iconProduct.sprite = item.Item.Icon;
        }
    }
}