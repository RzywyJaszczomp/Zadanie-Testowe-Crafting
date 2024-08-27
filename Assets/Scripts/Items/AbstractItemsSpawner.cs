using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractItemsSpawner : ScriptableObject
{
    [SerializeField] protected ItemTypeToPrefab _table;

    public abstract void Spawn(Item ItemType, Transform location);

}
