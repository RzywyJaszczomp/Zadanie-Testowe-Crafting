using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventorySlot;
    [SerializeField] private GameObject _inventoryPanel;


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

    public void UpdateInventoryUI(GameObject inventory)
    {

    }
}
