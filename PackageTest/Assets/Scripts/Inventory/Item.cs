using UnityEngine;

namespace ScriptsInventory
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private int amount;
        [SerializeField] private ItemScriptableObject _item;
    }
}