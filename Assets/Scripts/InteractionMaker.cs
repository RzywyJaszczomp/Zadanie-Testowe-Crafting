using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionMaker : MonoBehaviour
{
    private List<IInteractable> _interactablesInRadius = new();
    
    public void DetectInteractable(IInteractable interactable)
    {
        _interactablesInRadius.Add(interactable);
        // Debug.Log($"Interactables in radius: {_interactablesInRadius.Count}");
    }

    public void LoseInteractable(IInteractable interactable)
    {
        _interactablesInRadius.Remove(interactable);
        // Debug.Log($"Interactables in radius: {_interactablesInRadius.Count}");
    }

    [ContextMenu("TestInteraction")]
    public void InteractWithNewest()
    {
        if(_interactablesInRadius.Count != 0)
        {
            // Debug.Log("Test interaction");
            _interactablesInRadius.Last().Interact(gameObject);
        // } else 
        // {
        //     Debug.Log("Nothing to interact with");
        }
    }

    public void Interact(Pickable pickable)
    {
        LoseInteractable(pickable);
    }

}
