using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public struct ItemPrefabPair
{
    [field:SerializeField]
    public Item itemType {get; private set;}
    [field:SerializeField]
    public GameObject prefab {get; private set;}
}

[CreateAssetMenu(fileName = "ItemTypeToPrefab", menuName = "ScriptableObjects/ItemTypeToPrefab")]
public class ItemTypeToPrefab : ScriptableObject
{
    [field:SerializeField]
    private List<ItemPrefabPair> _list;

    public ReadOnlyCollection<ItemPrefabPair> GetList()
    {
        return new ReadOnlyCollection<ItemPrefabPair>(_list);
    }

    public GameObject GetPrefab(Item itemType)
    {
        return _list.Find(x=>x.itemType==itemType).prefab;
    }

}
