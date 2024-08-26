using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipePack", menuName = "ScriptableObjects/ReciepePack")]
public class RecipePack : ScriptableObject
{
    [field:SerializeField]
    private List<Recipe> _recipes;

    public ReadOnlyCollection<Recipe> GetRecepies()
    {
        return new ReadOnlyCollection<Recipe>(_recipes);
    }

    public void AddRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
    }
}
