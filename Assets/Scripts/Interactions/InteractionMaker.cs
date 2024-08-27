using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class InteractionMaker : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private CustomEvent _newInteractionAvaliableE;
    [SerializeField] private SimpleCustomEvent _noInteractionAvaliableE;
    [SerializeField] private CustomEvent _pickedUpItemE;
    [Header("Allowed Interactions")]
    [SerializeField]
    private List<InteractionType> _allowedInteractions = new();


    private List<AbstractInteractable> _interactablesInRadius = new();
    
    public void DetectInteractable(AbstractInteractable interactable)
    {
        if(_allowedInteractions.Contains(interactable.TypeOfInteraction))
        {
            _interactablesInRadius.Add(interactable);
            _newInteractionAvaliableE.Invoke(interactable.gameObject);
        }
    }


    public void LoseInteractable(AbstractInteractable interactable)
    {
        _interactablesInRadius.Remove(interactable);
        if(_interactablesInRadius.Count > 0)
        {
            _newInteractionAvaliableE.Invoke(_interactablesInRadius.Last().gameObject);
        } else
        {
            _noInteractionAvaliableE.Invoke();
        }
    }

    public void InteractWithNewest()
    {
        if(_interactablesInRadius.Count != 0)
        {
            _interactablesInRadius.Last().GetComponent<AbstractInteractable>().Interact(gameObject);
        } else 
        {
            Debug.Log("Nothing to interact with");
        }
    }

    public bool Interact(Pickable pickable)
    {
        var inventory = GetComponentInChildren<InventoryScript>();
        if(inventory != null)
        {
            _pickedUpItemE.Invoke(pickable.gameObject);
            inventory.AddToInventory(pickable.ItemType);
            LoseInteractable(pickable);
            return true;
        } 
        return false;
    }

    public void OnInteract()
    {
        InteractWithNewest();
    }
}
