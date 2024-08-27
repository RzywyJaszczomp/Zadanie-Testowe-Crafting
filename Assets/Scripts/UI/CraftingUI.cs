using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    [Header("Internal Prefabs")]
    [SerializeField] private GameObject _craftingPanel;
    [SerializeField] private GameObject _slotsParent;
    [Header("Connected Prefabs")]
    [SerializeField] private GameObject _slot;
    [Header("Events")]
    [SerializeField] private SimpleCustomEvent _requestCraftingClosedE;

    private CraftingScript _bindedCrafting;
    private List<GameObject> _slots = new();
    

    public void BindCrafting(GameObject craftingObject)
    {
        _bindedCrafting = craftingObject.GetComponent<CraftingScript>();
    }

    public void UpdateCraftingUI()
    {
        var recipes = _bindedCrafting.GetRecipes();
        if(recipes.Count != _slots.Count)
        {
            _slots.Clear();
            foreach(var r in recipes)
            {
                var newSlot = Instantiate(_slot, _slotsParent.transform);
                _slots.Add(newSlot);
                newSlot.GetComponent<RecipeBarUI>().SetRecipeBar(r);
            }
        }

    }

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
