using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactionMaker)
    {
        Debug.Log($"{interactionMaker.name} picked up {name}");
        interactionMaker.GetComponent<InteractionMaker>().Interact(this);
        Destroy(gameObject);
    }
}
