using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [field:SerializeField]
    public Item ItemType {get; private set;}
    public void Interact(GameObject interactionMaker)
    {
        if (interactionMaker.GetComponent<InteractionMaker>().Interact(this))
        {
            Destroy(gameObject);
        }
    }
}
