using System.Collections;
using System.Collections.Generic;
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
}
