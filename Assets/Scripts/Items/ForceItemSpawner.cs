using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ForceItemSpawner", menuName = "ScriptableObjects/ForceItemSpawner")]
public class ForceItemSpawner : AbstractItemsSpawner
{
    public float force = 10;
    public override void Spawn(Item ItemType, Transform location)
    {
        var newObject = Instantiate(_table.GetPrefab(ItemType), location.position, location.rotation);
        newObject.GetComponent<Rigidbody>().AddForce(location.forward*10, ForceMode.Impulse);
    }
}
