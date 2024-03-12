using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
            ClickEffector(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void ClickEffector(Vector2 position)
    {
        Instantiate(_effectPrefab, position, Quaternion.identity, transform);
    }
}