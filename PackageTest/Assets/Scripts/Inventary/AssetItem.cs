using UnityEngine;

[CreateAssetMenu(menuName = "Items")]
public class AssetItem : ScriptableObject, Items
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _uiIcon;

    public string Name => _name;
    public Sprite UIIcon => _uiIcon;
}