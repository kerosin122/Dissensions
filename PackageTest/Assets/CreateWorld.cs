using System;
using UnityEngine;
using static Assets.Scripts.UI.StartMenu;

public class CreateWorld : MonoBehaviour
{
    [SerializeField] private GameObject _swordMan;
    [SerializeField] private GameObject _archer;
    [SerializeField] private GameObject _mag;

    [SerializeField] private Transform _playerSpawnPoint;

    public void CreateCharacter(CharacterType type, Action callback)
    {
        switch (type)
        {
            case CharacterType.SwordMan:
                InstantiateCharacter(_swordMan, callback);
                break;
            case CharacterType.Archer:
                InstantiateCharacter(_archer, callback);
                break;
            case CharacterType.Mag:
                InstantiateCharacter(_mag, callback);
                break;
        }
    }

    private void InstantiateCharacter(GameObject prefab, Action callback)
    {
        Instantiate(prefab, _playerSpawnPoint);

        callback?.Invoke();
    }
}
