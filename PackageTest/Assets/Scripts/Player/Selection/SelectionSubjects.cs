using UnityEngine;
using ScriptsInventory;

namespace ScriptsPlayer
{
    public class SelectionSubjects : MonoBehaviour
    {
        [SerializeField] private InventoryPanel _inventoryPanel;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (collision.TryGetComponent(out Weapon item))
                {
                    _inventoryPanel.AddItem(collision.GetComponent<Weapon>().Item, collision.GetComponent<Weapon>().Amount);
                    Destroy(gameObject);
                }
            }
        }
    }
}