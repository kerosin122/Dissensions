using TMPro;
using UnityEngine;

namespace ScriptCharacteristics
{
    public class CharacteristicsText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;

        public void Initialize(float gold)
        {
            if (_goldText == null)
                return;

            _goldText.text = $"Gold: {gold}$";
        }
    }
}