using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<InteractionMaker>().DetectInteractable(other.transform.parent.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.GetComponent<InteractionMaker>().LoseInteractable(other.transform.parent.gameObject);
    }
}
