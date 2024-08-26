using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private CustomItemEvent _requestItemRemovedE;
    [SerializeField] private SimpleCustomEvent _requestInventoryClosedE;
    [SerializeField] private GameObject _inventorySlot;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Transform _inventorySlotsParent;
    private List<InventorySlotUI> _inventorySlots = new();


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
                _inventorySlots.Add(newSlot.GetComponent<InventorySlotUI>());
                newSlot.GetComponent<InventorySlotUI>().ConfigureSlot(_requestItemRemovedE);
            }
        }
    }

    private void DisplayItems(InventoryScript inventory)
    {
        ResetIcons();
        int i = 0;
        foreach(var itemType in inventory.Inventory.Keys)
        {
            var amountOfItems = inventory.Inventory[itemType];
            _inventorySlots[i].SetItemIcon(itemType, amountOfItems);
            ++i;
        }
    }

    private void ResetIcons()
    {
        foreach(var slot in _inventorySlots)
        {
            slot.ResetIcon();
        }
    }

    public void OnExitPress()
    {
        _requestInventoryClosedE.Invoke();;
    }

}
