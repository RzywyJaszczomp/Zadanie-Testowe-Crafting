using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBarUI : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private RecipeEvent _requestMakeRecipeE;

    [Header("Connected Prefabs")]
    [SerializeField] private GameObject _itemIcon;

    [Header("Interal Prefabs")]
    [SerializeField] private ItemSlotUI _resultIcon;
    [SerializeField] private TextMeshProUGUI _craftingChanceText;
    [SerializeField] private GameObject _ingredientsPanel;

    private Recipe _heldRecipe;

    public void SetRecipeBar(Recipe recipe)
    {
        _heldRecipe = recipe;
        SetItemSlot(_resultIcon, recipe.Result);
        _craftingChanceText.text = $"{recipe.Chance*100}%";
        foreach(var i in recipe.GetIngredients())
        {
            var ingredientIcon = Instantiate(_itemIcon, _ingredientsPanel.transform);
            SetItemSlot(ingredientIcon.GetComponent<ItemSlotUI>(), i);
        }
    }

    private void SetItemSlot(ItemSlotUI itemSlot, ItemStack itemStack)
    {
        itemSlot.SetItemSlot(itemStack.ItemType.Icon, itemStack.Amount);
    }

    public void RequestCrafting()
    {
        _requestMakeRecipeE.Invoke(_heldRecipe);
    }
}
