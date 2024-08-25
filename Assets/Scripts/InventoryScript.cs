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
}
