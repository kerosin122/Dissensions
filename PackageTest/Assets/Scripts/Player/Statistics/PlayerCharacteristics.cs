using UnityEngine;

namespace ScriptCharacteristics
{
    public class PlayerCharacteristics : MonoBehaviour
    {
        public float Gold { get => _gold; set => _gold = value; }

        [SerializeField] private float _health;
        [SerializeField] private float _mana;
        [SerializeField] private float _gold;

        [SerializeField] private CharacteristicsText _characteristicsText;

        private void Update() => _characteristicsText.Initialize(_health, _mana, _gold);
    }
}