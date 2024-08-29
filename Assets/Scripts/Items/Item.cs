using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField]
    public String Name {get; private set;}
    [field: SerializeField]
    public Sprite Icon {get; private set;}
}
