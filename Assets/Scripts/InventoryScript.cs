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
    [SerializeField] private CustomEvent _inventoryCreatedE;

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

    private void OnEnable()
    {
        StartCoroutine(NotifyOfCreation());
    }

    private IEnumerator NotifyOfCreation()
    {
        yield return 0;
        _inventoryCreatedE.Invoke(gameObject);

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
    }

    public void PickUpItem(GameObject itemObject)
    {
        var item = itemObject.GetComponent<Pickable>().ItemType;
        AddToInventory(item);
    }
}
