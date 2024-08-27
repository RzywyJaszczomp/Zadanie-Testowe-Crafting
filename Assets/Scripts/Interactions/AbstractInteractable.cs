using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    public InteractionType TypeOfInteraction {get; protected set;}
    
    public abstract void Interact(GameObject gameObject);
}
