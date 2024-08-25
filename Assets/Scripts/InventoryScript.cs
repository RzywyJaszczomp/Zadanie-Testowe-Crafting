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
    public void OnOpenInventory()
    {
        _inventoryOpenedE.Invoke(gameObject);
    }

    public void OnCloseInventory()
    {
        _inventoryClosedE.Invoke();
    }
}
