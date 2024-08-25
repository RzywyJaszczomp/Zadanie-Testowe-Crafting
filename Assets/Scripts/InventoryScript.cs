using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private CustomEvent _inventoryOpenedE;
    [SerializeField] private SimpleCustomEvent _inventoryClosedE;
    public void OnOpenInventory()
    {
        _inventoryOpenedE.Invoke(gameObject);
        Debug.Log("open");
    }

    public void OnCloseInventory()
    {
        _inventoryClosedE.Invoke();
        Debug.Log("close");
    }
}
