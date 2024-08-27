using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : AbstractInteractable
{

    private void Awake()
    {
        TypeOfInteraction = Resources.Load<InteractionType>("ClickInteractionSO");
    }
    public override void Interact(GameObject interactionMaker)
    {
        Debug.Log($"{interactionMaker.gameObject} clicked the obelisk");
    }
}
