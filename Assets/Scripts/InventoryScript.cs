using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Rendering;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [field: SerializeField]
    public int InventorySize {get; private set;}
    [SerializeField] private CustomEvent _inventoryOpenedE;
    [SerializeField] private SimpleCustomEvent _inventoryClosedE;
    [SerializeField] private CustomEvent _inventoryChangedE;

    public Dictionary<Item, int> Inventory {get; private set;}

    private void Start()
    {
        Inventory = new();
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
        if(Inventory.ContainsKey(item))
        {
            Inventory[item]++;
        } else
        {
            Inventory[item] = 1;
        }
        _inventoryChangedE.Invoke(gameObject);
    }

    public void RemoveFromInventory(Item item)
    {
        if(Inventory.ContainsKey(item))
        {
            if(Inventory[item] > 1)
            {
                Inventory[item]--;
            } else
            {
                Inventory.Remove(item);
            }
            _inventoryChangedE.Invoke(gameObject);
        }
    }
}
