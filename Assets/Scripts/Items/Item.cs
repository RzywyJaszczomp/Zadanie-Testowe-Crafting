using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField]
    public String Name {get; private set;}
    [field: SerializeField]
    public Sprite Icon {get; private set;}
}
