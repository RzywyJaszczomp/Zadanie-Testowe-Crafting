using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class InteractionMaker : MonoBehaviour
{
    [SerializeField] private CustomEvent _newInteractionAvaliableE;
    [SerializeField] private SimpleCustomEvent _noInteractionAvaliableE;
    [SerializeField] private CustomEvent _pickedUpItemE;

    private List<GameObject> _interactablesInRadius = new();
    
    public void DetectInteractable(GameObject interactable)
    {
        _interactablesInRadius.Add(interactable);
        _newInteractionAvaliableE.Invoke(interactable);
    }

    public void LoseInteractable(GameObject interactable)
    {
        _interactablesInRadius.Remove(interactable);
        if(_interactablesInRadius.Count > 0)
        {
            _newInteractionAvaliableE.Invoke(_interactablesInRadius.Last());
        } else
        {
            _noInteractionAvaliableE.Invoke();
        }
    }

    public void InteractWithNewest()
    {
        if(_interactablesInRadius.Count != 0)
        {
            _interactablesInRadius.Last().GetComponent<IInteractable>().Interact(gameObject);
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
            LoseInteractable(pickable.gameObject);
            return true;
        } 
        return false;
    }

    public void OnInteract()
    {
        InteractWithNewest();
    }
}
