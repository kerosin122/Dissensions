using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ScriptsInventory;
using System.Collections;

namespace ScriptsPlayer
{
    public class SelectionSubjects : MonoBehaviour
    {
        private readonly int AppearancePanel = Animator.StringToHash(nameof(AppearancePanel));

        private const float TimeDisappearText = 1f;

        [SerializeField] private Image _iconProduct;
        [SerializeField] private TextMeshProUGUI _hintText;
        [SerializeField] private InventoryPanel _inventoryPanel;

        [SerializeField] private Animator _animator;

        private void OnCollisionEnter2D(Collision2D collision) => Lifting(collision);

        private void Lifting(Collision2D collider)
        {
            if (collider.gameObject.TryGetComponent(out Weapon item))
            {
                _inventoryPanel.AddItem(collider.gameObject.GetComponent<Weapon>().Item, collider.gameObject.GetComponent<Weapon>().Amount);
                Destroy(collider.gameObject);

                _animator.SetTrigger(AppearancePanel);

                DrawInformationProduct(item);
                StartCoroutine(TransparencyWeaponText());
            }
        }

        private void DrawInformationProduct(Weapon item)
        {
            _hintText.text = $"You have picked up:   {item.tag}";
            _iconProduct.sprite = item.Item.Icon;
        }

        private IEnumerator TransparencyWeaponText()
        {
            yield return new WaitForSeconds(TimeDisappearText);
            _hintText.text = string.Empty;
        }
    }
}