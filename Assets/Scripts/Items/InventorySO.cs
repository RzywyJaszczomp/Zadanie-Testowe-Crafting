using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PersistentInventory", menuName = "ScriptableObjects/PersistentInventory")]
public class InventorySO : ScriptableObject
{
    [field: SerializeField]
    public int InventorySize {get; private set;}
    [field: SerializeField]
    private List<ItemStack> _inventory;

    public void AddToInventory(Item item, int amount=1)
    {
        if(HasItemType(item))
        {
            var itemStack = FindItem(item);
            itemStack.Amount+=amount;
        } else
        {
            _inventory.Add(new ItemStack(item, amount));
        }
        ExpandInventory();
    }

    public void RemoveFromInventory(Item item, int amount=1)
    {
        if(HasItemType(item))
        {
            var itemStack = FindItem(item);
                itemStack.Amount-=amount;
            if(itemStack.Amount < 1)
            {
                _inventory.Remove(itemStack);
            }
        }
    }
    
    private void ExpandInventory()
    {
        if(_inventory.Count > InventorySize)
            InventorySize += 10;
            
    }

    public ReadOnlyCollection<ItemStack> GetItemList()
    {
        return new ReadOnlyCollection<ItemStack>(_inventory);
    }

    public bool HasItemType(Item itemType)
    {
        return _inventory.Any(x=>x.ItemType==itemType);
    }   

    private ItemStack FindItem(Item item)
    {
        return _inventory.Find(x=>x.ItemType==item);
    }

    public bool HasItems(ReadOnlyCollection<ItemStack> requiredItems)
    {
        bool hasItems = true;
        foreach(var itemStack in requiredItems)
        {
            if(!_inventory.Any(x=>x.ItemType==itemStack.ItemType && x.Amount >=itemStack.Amount))
            {
                hasItems = false;
                break;
            }
        }
        return hasItems;
    }

    public void FinalizeRecipe(Recipe recipe)
    {
        foreach(var itemStack in recipe.GetIngredients())
        {
            RemoveFromInventory(itemStack.ItemType, itemStack.Amount);
        }
        AddToInventory(recipe.Result.ItemType, recipe.Result.Amount);
    }

}
