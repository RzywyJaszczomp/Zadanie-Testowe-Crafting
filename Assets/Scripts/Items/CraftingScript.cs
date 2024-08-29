using System.Collections.ObjectModel;
using UnityEngine;

[RequireComponent(typeof(InventoryScript))]
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
    [SerializeField] private RecipeEvent _recipeCraftedE;
    [SerializeField] private SimpleCustomEvent _notEnoughMaterialsE;
    [SerializeField] private SimpleCustomEvent _recipeFailedE;

    private InventoryScript _inventory;

    public void Start()
    {
        _craftingCreatedE.Invoke(gameObject); 
        _inventory = GetComponent<InventoryScript>();
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

    public void CraftIfPossible(Recipe recipe)
    {
        if(_inventory.HasItems(recipe.GetIngredients()))
        {
            if(WasCraftingSuccessful(recipe.Chance))
            {
                _recipeCraftedE.Invoke(recipe);
            } else
            {
                _recipeFailedE.Invoke();
            }
        } else
        {
            _notEnoughMaterialsE.Invoke();
        }
    }

    private bool WasCraftingSuccessful(float chance)
    {
        return Random.value<=chance;
    }

}
