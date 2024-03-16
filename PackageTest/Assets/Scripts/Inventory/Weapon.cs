using UnityEngine;

namespace ScriptsInventory
{
    public class Weapon : MonoBehaviour
    {
        public int Amount => _amount;
        public ItemScriptableObject Item => _item;

        [SerializeField] private int _amount;
        [SerializeField] private ItemScriptableObject _item;
    }
}