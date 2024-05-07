using UnityEngine;

namespace ScriptCharacteristics
{
    public class PlayerCharacteristics : MonoBehaviour
    {
        [SerializeField] private float _gold;

        [SerializeField] private CharacteristicsText _characteristicsText;

        private void Update()
        {
            if (_characteristicsText != null)
                _characteristicsText.Initialize(_gold);
        }
    }
}