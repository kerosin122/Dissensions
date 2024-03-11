using System.Linq;
using UnityEngine;

public class Items : MonoBehaviour, IPickUpItems
{
    [SerializeField] private GameObject[] _foodPrefabs;

    public static Items _item;

    private void Awake() => _item = GetComponent<Items>();

    public void PickUpFood(GameObject gameObj)
    {
        if (_foodPrefabs.Contains(gameObj))
            gameObj.SetActive(false);
    }
}