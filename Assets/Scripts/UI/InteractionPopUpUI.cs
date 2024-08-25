using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private String _message = "Press E to interact with";

    public void SetInteractionText(GameObject interactable)
    {
        _text.text = $"{_message} {interactable.name}";
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
