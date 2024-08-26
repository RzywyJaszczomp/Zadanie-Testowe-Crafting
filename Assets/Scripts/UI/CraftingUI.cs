using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] private GameObject _craftingPanel;
    [SerializeField] private SimpleCustomEvent _requestCraftingClosedE;

    public void CloseCraftingUI()
    {
        _craftingPanel.SetActive(false);
    }
    public void OpenCraftingUI()
    {
        _craftingPanel.SetActive(true);
    }

    public void RequestCloseCrafting()
    {
        _requestCraftingClosedE.Invoke();
    }

    private void Awake()
    {
        _craftingPanel.SetActive(false);
    }
}
