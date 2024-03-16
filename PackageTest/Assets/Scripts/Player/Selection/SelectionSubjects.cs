using UnityEngine;
using ScriptsInventory;

namespace ScriptsPlayer
{
    public class SelectionSubjects : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Item item))
                item.gameObject.SetActive(false);
        }
    }
}