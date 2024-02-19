using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using CharacterStats;

public class Inventory : MonoBehaviour
{    public CharacterStater characterStater;
    [SerializeField] private List<AssetItem> allItems;
    [SerializeField] private List<AssetItem> characterItems;
    [SerializeField] private List<AssetItem> characterInventoryItems;
    [SerializeField] private inventoryprescent  allItemsPresenter;
    [SerializeField] private inventoryprescent  characterItemsPresenter;
    [SerializeField] private inventoryprescent  characterInventoryPresenter;
    [SerializeField] private CharacterStater character;
    [SerializeField] private Transform allItemsContainer;
    [SerializeField] private Transform characterItemsContainer;
    [SerializeField] private Transform characterInventoryContainer;

    public void OnEnable()
    {
        RenderAllItems(allItems);
        RenderCharacterItems(characterItems);
        RenderCharacterInventoryItems(characterInventoryItems);
    }

    public void RenderAllItems(List<AssetItem> items)
    {
        foreach (Transform child in allItemsContainer)
        {
            Destroy(child.gameObject);
        }

        items.ForEach(item =>
        {
            var cell = Instantiate(allItemsPresenter, allItemsContainer);
            cell.Render(item);
        });
    }

    public void RenderCharacterItems(List<AssetItem> items)
    {
        foreach (Transform child in characterItemsContainer)
        {
            Destroy(child.gameObject);
        }

        items.ForEach(item =>
        {
            var cell = Instantiate(characterItemsPresenter, characterItemsContainer);
            cell.Render(item);
        });
    }

    public void RenderCharacterInventoryItems(List<AssetItem> items)
    {
        foreach (Transform child in characterInventoryContainer)
        {
            Destroy(child.gameObject);
        }

        items.ForEach(item =>
        {
            var cell = Instantiate(characterInventoryPresenter, characterInventoryContainer);
            cell.Render(item);
        });
    }

    public void AddItemToAllItems(AssetItem item)
    {
        allItems.Add(item);
        RenderAllItems(allItems);
    }

    public void AddItemToCharacterItems(AssetItem item)
    {
        characterItems.Add(item);
        RenderCharacterItems(characterItems);
    }

    public void AddItemToCharacterInventory(AssetItem item)
    {
        characterInventoryItems.Add(item);
        RenderCharacterInventoryItems(characterInventoryItems);
    }

    public void RemoveItemFromAllItems(AssetItem item)
    {
        allItems.Remove(item);
        RenderAllItems(allItems);
    }

    public void RemoveItemFromCharacterItems(AssetItem item)
    {
        characterItems.Remove(item);
        RenderCharacterItems(characterItems);
    }

    public void RemoveItemFromCharacterInventory(AssetItem item)
    {
        characterInventoryItems.Remove(item);
        RenderCharacterInventoryItems(characterInventoryItems);
    }
}
