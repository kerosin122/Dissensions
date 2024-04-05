using UnityEngine;

namespace ScriptsInventory
{
    public class Weapon : MonoBehaviour
    {
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public ItemScriptableObject Item => _item;

        [SerializeField] private int _amount;
        [SerializeField] private ItemScriptableObject _item;
    }
}