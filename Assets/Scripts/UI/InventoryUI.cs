using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventorySlot;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Transform _inventorySlotsParent;
    private List<GameObject> _inventorySlots = new();


    private void Awake()
    {
        HideInventory();
    }

    public void ShowInventory()
    {
        _inventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        _inventoryPanel.SetActive(false);
    }

    public void UpdateInventoryUI(GameObject inventoryObject)
    {
        var inventory = inventoryObject.GetComponent<InventoryScript>();
        UpdateNrOfInventorySlots(inventory.InventorySize);
        DisplayItems(inventory);
    }

    private void UpdateNrOfInventorySlots(int inventorySize)
    {
        if(inventorySize != _inventorySlots.Count)
        {
            _inventorySlots.Clear();
            for(int i = 0; i < inventorySize; ++i)
            {
                var newSlot = Instantiate(_inventorySlot, _inventorySlotsParent);
                _inventorySlots.Add(newSlot);
            }
        }
    }

    private void DisplayItems(InventoryScript inventory)
    {
        int i = 0;
        foreach(var itemType in inventory.Inventory.Keys)
        {
            Debug.Log("a");
            var amountOfItems = inventory.Inventory[itemType];
            _inventorySlots[i].GetComponent<InventorySlotUI>().SetItemIcon(itemType.Icon, amountOfItems);
            ++i;
        }
    }
}
