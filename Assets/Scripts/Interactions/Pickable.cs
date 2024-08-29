using UnityEngine;

public class Pickable : AbstractInteractable
{
    [field:SerializeField]
    public Item ItemType {get; private set;}

    private void Awake()
    {
        TypeOfInteraction = Resources.Load<InteractionType>("PickUpInteractionSO");
    }

    public override void Interact(GameObject interactionMaker)
    {
        if (interactionMaker.GetComponent<InteractionMaker>().Interact(this))
        {
            Destroy(gameObject);
        }
    }
}
