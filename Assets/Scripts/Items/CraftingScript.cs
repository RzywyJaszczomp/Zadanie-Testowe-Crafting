using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingScript : MonoBehaviour
{
    [field:Header("Persistent Recipes")]
    [field:SerializeField]
    public RecipePack KnownRecipes {get; private set;}
    
    [Header("Events")]

    [SerializeField] private SimpleCustomEvent _craftingClosedE;
    [SerializeField] private CustomEvent _craftingOpenedE;

    public void OnCloseCrafting()
    {
        _craftingClosedE.Invoke();
    }
    public void OnOpenCrafting()
    {
        _craftingOpenedE.Invoke(gameObject);
    }
}
