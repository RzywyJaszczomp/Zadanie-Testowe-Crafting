using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CraftingScript : MonoBehaviour
{
    [field:Header("Persistent Recipes")]
    [field:SerializeField]
    private RecipePack _knownRecipes;
    
    [Header("Events")]

    [SerializeField] private SimpleCustomEvent _craftingClosedE;
    [SerializeField] private SimpleCustomEvent _craftingOpenedE;
    [SerializeField] private SimpleCustomEvent _updateCraftingE;
    [SerializeField] private CustomEvent _craftingCreatedE;

    public void Start()
    {
        _craftingCreatedE.Invoke(gameObject);   
    }
    public void OnCloseCrafting()
    {
        _craftingClosedE.Invoke();
    }
    public void OnOpenCrafting()
    {
        _updateCraftingE.Invoke();
        _craftingOpenedE.Invoke();
    }

    public ReadOnlyCollection<Recipe> GetRecipes()
    {
        return _knownRecipes.GetRecipes();
    }
}
