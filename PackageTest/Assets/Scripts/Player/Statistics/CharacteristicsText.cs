using TMPro;
using UnityEngine;

namespace ScriptCharacteristics
{
    public class CharacteristicsText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _manaText;
        [SerializeField] private TextMeshProUGUI _goldText;

        public void Initialize(float health, float mana, float gold)
        {
            _healthText.text = $"Health: {health}";
            _manaText.text = $"Mana: {mana}";
            _goldText.text = $"Gold: {gold}$";
        }
    }
}