using UnityEngine;

namespace ScriptCharacteristics
{
    public class PlayerCharacteristics : MonoBehaviour
    {
        [SerializeField] private float _gold;

        [SerializeField] private CharacteristicsText _characteristicsText;

        private void Update() => _characteristicsText.Initialize(_gold);
    }
}