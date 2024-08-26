using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public struct ItemStack
{
    [field:SerializeField]
    public Item Item {get; private set;}
    [field:SerializeField]
    public int Amount {get; private set;}
}

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Reciepe")]
public class Recipe : ScriptableObject
{
    [field:SerializeField]
    public ItemStack Result {get; private set;}
    [field:SerializeField]
    private List<ItemStack> _ingredients = new();
    [field:SerializeField]
    public float Chance {get; private set;}

    public ReadOnlyCollection<ItemStack> GetIngredients()
    {
        return new ReadOnlyCollection<ItemStack>(_ingredients);
    }
}
