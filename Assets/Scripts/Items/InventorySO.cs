using System.Collections;
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
    public void AddToInventory(Item item)
    {
        if(HasItemType(item))
        {
            var itemStack = FindItem(item);
            itemStack.Amount++;
        } else
        {
            _inventory.Add(new ItemStack(item, 1));
        }
    }

    public void RemoveFromInventory(Item item)
    {
        if(HasItemType(item))
        {
            var itemStack = FindItem(item);
            if(itemStack.Amount > 1)
            {
                itemStack.Amount--;
            } else
            {
                _inventory.Remove(itemStack);
            }
        }
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

}
