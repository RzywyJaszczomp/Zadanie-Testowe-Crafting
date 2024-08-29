using System;
using UnityEngine;

[Serializable]
public class ItemStack
{
    [field:SerializeField]
    public Item ItemType {get; set;}
    [field:SerializeField]
    public int Amount {get; set;}

    public ItemStack(Item item, int amount)
    {
        ItemType = item;
        Amount = amount;
    }
}
