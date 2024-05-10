using UnityEngine;

namespace ScriptsSaving
{
    public class CharacterModel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _charactersModel;

        private void Awake() => ChooseCharacterModel(SaveData.Instance.CurrentCharacterID);

        private void ChooseCharacterModel(int index)
        {
            Instantiate(_charactersModel[index], new Vector2(37.67f, 51.15f), Quaternion.identity, transform);
        }
    }
}