using TMPro;
using UnityEngine;

namespace ScriptCharacteristics
{
    public class CharacteristicsText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;

        public void Initialize(float gold) => _goldText.text = $"Gold: {gold}$";
    }
}