using UnityEngine;
using System.Collections.ObjectModel;

public class InventoryScript : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private CustomEvent _inventoryOpenedE;
    [SerializeField] private SimpleCustomEvent _inventoryClosedE;
    [SerializeField] private CustomEvent _inventoryChangedE;
    [SerializeField] private CustomEvent _inventoryCreatedE;

    [Header("Persistent Inventory")]
    [SerializeField] private InventorySO _inventory;
    [Header("Throwing away items")]
    [SerializeField] private AbstractItemsSpawner _spawner;
    [SerializeField] private Transform _throwAwayPoint;

    private void Start()
    {
        _inventoryCreatedE.Invoke(gameObject);
    }

    public void OnOpenInventory()
    {
        _inventoryOpenedE.Invoke(gameObject);
    }

    public void OnCloseInventory()
    {
        _inventoryClosedE.Invoke();
    }

    public void AddToInventory(Item item)
    {
        _inventory.AddToInventory(item);
        _inventoryChangedE.Invoke(gameObject);
    }

    public void RemoveFromInventory(Item item)
    {
        _inventory.RemoveFromInventory(item);
        _inventoryChangedE.Invoke(gameObject);
        _spawner.Spawn(item, _throwAwayPoint);
    }

    public int GetInventorySize()
    {
        return _inventory.InventorySize;
    }

    public ReadOnlyCollection<ItemStack> GetItemList()
    {
        return _inventory.GetItemList();
    }

    public bool HasItems(ReadOnlyCollection<ItemStack> requiredItems)
    {
        return _inventory.HasItems(requiredItems);
    }

    public void FinalizeRecipe(Recipe recipe)
    {
        _inventory.FinalizeRecipe(recipe);
        _inventoryChangedE.Invoke(gameObject);
    }
}
