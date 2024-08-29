using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private CustomItemEvent _requestItemRemovedE;
    [SerializeField] private SimpleCustomEvent _requestInventoryClosedE;
    [SerializeField] private SimpleCustomEvent _requestCraftingOpenE;

    [Header("Connected Prefabs")]
    [SerializeField] private GameObject _inventorySlot;

    [Header("Interanl Prefabs")]
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Transform _inventorySlotsParent;

    private List<InventorySlotUI> _inventorySlots = new();
    private InventoryScript _bindedInventory;

    private void Awake()
    {
        HideInventory();
    }

    public void BindInventory(GameObject inventoryObject)
    {
        _bindedInventory = inventoryObject.GetComponent<InventoryScript>();
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
        if(inventoryObject == _bindedInventory.gameObject)
        {
            UpdateNrOfInventorySlots(_bindedInventory.GetInventorySize());
            DisplayItems();
        }
    }

    private void UpdateNrOfInventorySlots(int inventorySize)
    {
        if(inventorySize != _inventorySlots.Count)
        {
            ResetInventorySlots();
            for(int i = 0; i < inventorySize; ++i)
            {
                var newSlot = Instantiate(_inventorySlot, _inventorySlotsParent);
                _inventorySlots.Add(newSlot.GetComponent<InventorySlotUI>());
                newSlot.GetComponent<InventorySlotUI>().ConfigureSlot(_requestItemRemovedE);
            }
        }
    }

    private void ResetInventorySlots()
    {
        _inventorySlotsParent.DetachChildren();
        foreach(var slot in _inventorySlots)
        {
            Destroy(slot.gameObject);
        }
        _inventorySlots.Clear();
    }

    private void DisplayItems()
    {
        ResetIcons();
        int i = 0;
        var inventory = _bindedInventory.GetItemList();
        foreach(var itemStack in inventory)
        {
            _inventorySlots[i].SetItemIcon(itemStack.ItemType, itemStack.Amount);
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
        _requestInventoryClosedE.Invoke();
    }

    public void OnOpenCraftingPress()
    {
        _requestCraftingOpenE.Invoke();
    }

}
